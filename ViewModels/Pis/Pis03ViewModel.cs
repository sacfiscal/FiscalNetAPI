namespace SACFiscalIO.Tributacao.ViewModels.Pis
{
    public class Pis03ViewModel
    {
        public ItemPis03[] Itens { get; set; }
    }

    public class ItemPis03
    {
        public ItemPis03()
        {

        }
        public int nItem { get; set; }
        public decimal qTrib { get; set; }
        public decimal vUnid { get; set; }
        public decimal vPis { get; set; }
    }
}
