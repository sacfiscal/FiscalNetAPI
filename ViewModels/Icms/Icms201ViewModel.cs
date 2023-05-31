namespace SACFiscalIO.Tributacao.ViewModels.Icms
{
    public class Icms201ViewModel
    {
        public ItemIcms201[] Itens { get; set; }
    }

    public class ItemIcms201
    {
        public ItemIcms201()
        {

        }

        public int nItem { get; set; }
        public decimal vProd { get; set; }
        public decimal vFrete { get; set; }
        public decimal vSeg { get; set; }
        public decimal vOutro { get; set; }
        public decimal vDesc { get; set; }
        public decimal pIcms { get; set; }
        public decimal pRedBC { get; set; }
        public decimal vBC { get; set; }
        public decimal vIcms { get; set; }
        public decimal pMVAST { get; set; }
        public decimal pRedBcST { get; set; }
        public decimal vBCST { get; set; }
        public decimal pIcmsST { get; set; }
        public decimal vIcmsST { get; set; }
        public decimal pFcpST { get; set; }
        public decimal vBCFcpST { get; set; }
        public decimal vFcpST { get; set; }
        public decimal pCredSN { get; set; }
        public decimal vCredSN { get; set; }
    }
}
