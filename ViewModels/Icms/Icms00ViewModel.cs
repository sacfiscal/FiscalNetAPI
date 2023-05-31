namespace SACFiscalIO.Tributacao.ViewModels.Icms
{
    public class Icms00ViewModel
    {
        public ItemIcms00[] Itens { get; set; }
    }

    public class ItemIcms00
    {
        public ItemIcms00()
        {

        }

        public int nItem { get; set; }
        public decimal vProd { get; set; }
        public decimal vFrete { get; set; }
        public decimal vSeg { get; set; }
        public decimal vOutro { get; set; }
        public decimal vDesc { get; set; }
        public decimal vIpi { get; set; }
        public decimal vBC { get; set; }
        public decimal pIcms { get; set; }
        public decimal vIcms { get; set; }
        public decimal pFcp { get; set; }
        public decimal vFcp { get; set; }
    }
}


