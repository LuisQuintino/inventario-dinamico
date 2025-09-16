using InvDinamico.Domain.Messaging.Base;
using InvDinamico.Domain.Messaging.Estoque;
using InvDinamico.Domain.Repositories.Categoria;
using InvDinamico.Domain.Repositories.Estoque;
using InvDinamico.Domain.Repositories.Movimento;
using Microsoft.EntityFrameworkCore.Query;

namespace InvDinamico.Domain.Services.Estoque
{
    public class EstoqueService(
        ICategoriaRepository categoriaRepository,
        IEstoqueRepository estoqueRepository,
        IMovimentoRepository movimentoRepository) : IEstoqueService
    {
        public void InserirNovoEstoque(InserirEstoqueRequest request, Guid codigoOperador)
        {
            var categoria = categoriaRepository.Obter(request.CodigoCategoria)
                ?? throw new InvDinamicoException("Categoria inválida");

            if (categoria.Situacao != Entidades.Enums.SituacaoGenerica.Habilitado)
                throw new InvDinamicoException("Categoria inativa, por favor escolha uma categoria ativa");

            var estoque = new Entidades.Estoque
            {
                Codigo = Guid.NewGuid(),
                CodigoCategoria = categoria.Codigo.Value,
                DtInclusao = DateTime.Now,
                DtUltimaAtualizacao = DateTime.Now,
                DtValidadeMedia = request.DtValidadeMedia,
                Nome = request.Nome,
                Perecivel = request.Perecivel,
                QtdEmEstoque = request.QtdEmEstoque
            };

            estoqueRepository.Inserir(estoque);
            movimentoRepository.Inserir(new(estoque, codigoOperador, estoque.QtdEmEstoque, "Inserção de item ao estoque"));
        }
    }
}
