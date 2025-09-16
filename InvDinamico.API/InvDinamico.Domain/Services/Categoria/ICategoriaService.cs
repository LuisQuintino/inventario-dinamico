using InvDinamico.Domain.Messaging.Categoria;

namespace InvDinamico.Domain.Services.Categoria
{
    public interface ICategoriaService
    {
        void Inserir(InserirCategoriaRequest categoriaRequest);
        void Atualizar(AtualizarCategoriaRequest atualizarCategoriaRequest);
        List<Entidades.Categoria> ListarCategorias();
    }
}
