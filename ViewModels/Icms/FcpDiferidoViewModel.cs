namespace SACFiscalIO.Tributacao.ViewModels.Icms
{
    public class FcpDiferidoViewModel
    {
        public ItemFcpDiferido[] Itens { get; set; }
    }

    public class ItemFcpDiferido
    {
        public ItemFcpDiferido()
        {

        }

        public int nItem { get; set; }
        public decimal vBCFcp { get; set; }
        public decimal pFcp { get; set; }
        public decimal vFcp { get; set; }
        public decimal pFcpDif { get; set; }
        public decimal vFcpDif { get; set; }
    }
}
