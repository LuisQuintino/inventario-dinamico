using api_domain.Config;
using api_domain.Extensions;
using InvDinamico.Domain.Repositories.Categoria;
using InvDinamico.Domain.Repositories.Estoque;
using InvDinamico.Domain.Repositories.Movimento;
using InvDinamico.Domain.Repositories.Operador;
using InvDinamico.Domain.Services.Autenticacao;
using InvDinamico.Domain.Services.Categoria;
using InvDinamico.Domain.Services.Estoque;
using InvDinamico.Domain.Services.Operador;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddDbContext<BdContext>();

builder.Services.AddScoped<IOperadorRepository, OperadorRepository>();
builder.Services.AddScoped<IOperadorService, OperadorService>();
builder.Services.AddScoped<IAutenticacaoService, AutenticacaoService>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IMovimentoRepository, MovimentoRepository>();
builder.Services.AddScoped<IEstoqueRepository, EstoqueRepository>();
builder.Services.AddScoped<IEstoqueService, EstoqueService>();
builder.Services.AddScoped<ICategoriaService, CategoriaService>();

var key = Encoding.ASCII.GetBytes(JwtExtensions.JwtSecretKey);
services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false
    };
});

services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "JWTAuthAuthentication", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "Bearer"
                              }
                          },
                         new string[] {}
                    }
                });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CORS",
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:3000", "https://inventario-dinamico.vercel.app")
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CORS");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
