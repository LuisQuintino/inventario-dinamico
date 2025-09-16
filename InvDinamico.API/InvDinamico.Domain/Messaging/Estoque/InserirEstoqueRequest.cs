namespace InvDinamico.Domain.Messaging.Estoque
{
    public class InserirEstoqueRequest
    {
        public Guid CodigoCategoria { get; set; }
        public int QtdEmEstoque { get; set; }
        public string Nome { get; set; }
        public bool Perecivel { get; set; }
        public DateTime DtValidadeMedia { get; set; }
    }
}
