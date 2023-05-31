namespace SACFiscalIO.Tributacao.ViewModels.Icms
{
    public class BaseIcmsSTViewModel
    {
        public ItemBaseIcmsST[] Itens { get; set; }
    }

    public class ItemBaseIcmsST
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
        public decimal pMVAST { get; set; }
        public decimal pRedBcST { get; set; }
        public decimal vBCST { get; set; }        
    }
}
