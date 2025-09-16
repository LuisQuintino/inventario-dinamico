namespace InvDinamico.Domain.Repositories.Categoria
{
    public interface ICategoriaRepository
    {
        public void Inserir(Entidades.Categoria entidade);
        public void Atualizar(Entidades.Categoria entidade);
        public Entidades.Categoria Obter(Guid codigoCategoria);
        public List<Entidades.Categoria> ListarCategorias();
    }
}
