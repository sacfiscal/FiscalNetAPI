namespace SACFiscalIO.Tributacao.ViewModels.Icms
{
    public class BaseIcmsProprioViewModel
    {
        public ItemBaseIcmsProprio[] Itens { get; set; }
    }

    public class ItemBaseIcmsProprio
    {
        public int nItem { get; set; }
        public decimal vProd { get; set; }
        public decimal vFrete { get; set; }
        public decimal vSeg { get; set; }
        public decimal vOutro { get; set; }
        public decimal vDesc { get; set; }
        public decimal vIpi { get; set; }
        public decimal pRedBc { get; set; }
        public decimal vBC { get; set; }
    }
}
