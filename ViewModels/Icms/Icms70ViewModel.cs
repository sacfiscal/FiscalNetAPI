namespace SACFiscalIO.Tributacao.ViewModels.Icms
{
    public class Icms70ViewModel
    {
        public ItemIcms70[] Itens { get; set; }
    }

    public class ItemIcms70
    {
        public ItemIcms70()
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
        public decimal pMVAST { get; set; }
        public decimal pRedBcST { get; set; }
        public decimal vBCST { get; set; }
        public decimal pIcmsST { get; set; }
        public decimal vIcmsST { get; set; }
        public decimal pFcpST { get; set; }
        public decimal vBCFcpST { get; set; }
        public decimal vFcpST { get; set; }
        public decimal vIcmsSTDeson { get; set; }
    }
}
