namespace SACFiscalIO.Tributacao.ViewModels.Ipi
{
    public class Ipi50AeViewModel
    {
        public ItemIpi50Ae[] Itens { get; set; }
    }

    public class ItemIpi50Ae
    {
        public ItemIpi50Ae()
        {

        }
        public int nItem { get; set; }
        public decimal qTrib { get; set; }
        public decimal vUnid { get; set; }
        public decimal vIpi { get; set; }
    }
}
