namespace SACFiscalIO.Tributacao.ViewModels.Icms
{
    public class Icms51ViewModel
    {
        public ItemIcms51[] Itens { get; set; }
    }
    public class ItemIcms51
    {
        public ItemIcms51()
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
        public decimal vIcmsOp { get; set; }
        public decimal pDif { get; set; }
        public decimal vIcmsDif { get; set; }
        public decimal pFcp { get; set; }
        public decimal vBCFcp { get; set; }
        public decimal vFcp { get; set; }
        public decimal pFcpDif { get; set; }
        public decimal vFcpDif { get; set; }
        public decimal vFcpEfet { get; set; }
    }
}
