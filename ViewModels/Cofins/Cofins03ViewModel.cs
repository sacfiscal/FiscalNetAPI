namespace SACFiscalIO.Tributacao.ViewModels.Cofins
{
    public class Cofins03ViewModel
    {
        public ItemCofins03[] Itens { get; set; }
    }

    public class ItemCofins03
    {
        public ItemCofins03()
        {

        }
        public int nItem { get; set; }
        public decimal qTrib { get; set; }
        public decimal vUnid { get; set; }
        public decimal vCofins { get; set; }
    }
}
