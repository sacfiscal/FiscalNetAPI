namespace SACFiscalIO.Tributacao.ViewModels.Ipi
{
    public class Ipi50AdViewModel
    {
        public ItemIpi50Ad[] Itens { get; set; }
    }

    public class ItemIpi50Ad
    {
        public ItemIpi50Ad()
        {

        }

        public int nItem { get; set; }
        public decimal vProd { get; set; }
        public decimal vFrete { get; set; }
        public decimal vSeg { get; set; }
        public decimal vOutro { get; set; }
        public decimal pIpi { get; set; }
        public decimal vBC { get; set; }
        public decimal vIpi { get; set; }

    }
}
