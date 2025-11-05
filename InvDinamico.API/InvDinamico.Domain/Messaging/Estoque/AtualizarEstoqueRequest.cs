namespace InvDinamico.Domain.Messaging.Estoque
{
    public class AtualizarEstoqueRequest
    {
        public Guid Codigo { get; set; }
        public Guid CodigoCategoria { get; set; }
        public int NovaQtdEmEstoque { get; set; }
        public string Nome { get; set; }
        public bool? Perecivel { get; set; }
        public string MotivoMovimento { get; set; }
        public DateTime? DtValidadeMedia { get; set; }
    }
}
