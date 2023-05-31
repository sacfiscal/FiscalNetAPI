namespace SACFiscalIO.Tributacao.ViewModels.Icms
{
    public class Icms101ViewModel
    {
        public ItemIcms101[] Itens { get; set; }
    }

    public class ItemIcms101
    {
        public ItemIcms101()
        {

        }

        public int nItem { get; set; }
        public decimal vProd { get; set; }
        public decimal vFrete { get; set; }
        public decimal vSeg { get; set; }
        public decimal vOutro { get; set; }
        public decimal vDesc { get; set; }
        public decimal vBC { get; set; }
        public decimal pCredSN { get; set; }
        public decimal vCredSN { get; set; }

    }
}
