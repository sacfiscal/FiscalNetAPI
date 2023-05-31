namespace SACFiscalIO.Tributacao.ViewModels.Pis
{
    public class Pis0102ViewModel
    {
        public ItemPis0102[] Itens { get; set; }
    }

    public class ItemPis0102
    {
        public ItemPis0102()
        {

        }

        public int nItem { get; set; }
        public decimal vProd { get; set; }
        public decimal vFrete { get; set; }
        public decimal vSeg { get; set; }
        public decimal vOutro { get; set; }
        public decimal vDesc { get; set; }
        public decimal pPis { get; set; }
        public decimal vIcms { get; set; }
        public decimal vBC { get; set; }
        public decimal vPis { get; set; }
    }
}
