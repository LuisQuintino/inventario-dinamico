using InvDinamico.Domain.Messaging.Categoria;
using InvDinamico.Domain.Repositories.Categoria;

namespace InvDinamico.Domain.Services.Categoria
{
    public class CategoriaService(ICategoriaRepository categoriaRepository) : ICategoriaService
    {
        public void Inserir(InserirCategoriaRequest categoriaRequest)
        {
            Entidades.Categoria categoria = new(categoriaRequest.Nome);
            categoriaRepository.Inserir(categoria);
        }

        public void Atualizar(AtualizarCategoriaRequest atualizarCategoriaRequest)
        {
            var categoria = categoriaRepository.Obter(atualizarCategoriaRequest.Codigo);
            categoria.Nome = atualizarCategoriaRequest.Nome ?? categoria.Nome;
            categoria.Situacao = atualizarCategoriaRequest.Situacao ?? categoria.Situacao;

            categoriaRepository.Atualizar(categoria);
        }

        public List<Entidades.Categoria> ListarCategorias() => categoriaRepository.ListarCategorias();
    }
}
