namespace SACFiscalIO.Tributacao.ViewModels.Icms
{
    public class Icms20ViewModel
    {
        public ItemIcms20[] Itens { get; set; }
    }
    public class ItemIcms20
    {
        public ItemIcms20()
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
        public decimal pRedBc { get; set; }
        public decimal vIcms { get; set; }
        public decimal pFcp { get; set; }
        public decimal vBCFcp { get; set; }
        public decimal vFcp { get; set; }
        public decimal vIcmsDeson { get; set; }
    }
}
