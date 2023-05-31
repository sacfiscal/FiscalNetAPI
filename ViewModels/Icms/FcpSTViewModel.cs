namespace SACFiscalIO.Tributacao.ViewModels.Icms
{
    public class FcpSTViewModel
    {
        public ItemFcpST[] Itens { get; set; }
    }

    public class ItemFcpST
    {
        public ItemFcpST()
        {

        }

        public int nItem { get; set; }
        public decimal vBCFcpST { get; set; }
        public decimal pFcpST { get; set; }
        public decimal vFcpST { get; set; }
    }
}
