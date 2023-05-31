namespace SACFiscalIO.Tributacao.ViewModels.Icms
{
    public class FcpEfetivoViewModel
    {
        public ItemFcpEfetivo[] Itens { get; set; }
    }

    public class ItemFcpEfetivo
    {
        public ItemFcpEfetivo()
        {

        }

        public int nItem { get; set; }
        public decimal vBCFcp { get; set; }
        public decimal pFcp { get; set; }
        public decimal vFcp { get; set; }
        public decimal pFcpDif { get; set; }
        public decimal vFcpDif { get; set; }
        public decimal vFcpEfet { get; set; }
    }
}
