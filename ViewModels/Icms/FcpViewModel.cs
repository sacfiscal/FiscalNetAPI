namespace SACFiscalIO.Tributacao.ViewModels.Icms
{
    public class FcpViewModel
    {
        public ItemFcp[] Itens { get; set; }
    }

    public class ItemFcp
    {
        public ItemFcp()
        {

        }

        public int nItem { get; set; }
        public decimal vBCFcp { get; set; }
        public decimal pFcp { get; set; }
        public decimal vFcp { get; set; }
    }
}
