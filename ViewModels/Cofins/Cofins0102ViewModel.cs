namespace SACFiscalIO.Tributacao.ViewModels.Cofins
{
    public class Cofins0102ViewModel
    {
        public ItemCofins0102[] Itens { get; set; }
    }

    public class ItemCofins0102
    {
        public ItemCofins0102()
        {

        }

        public int nItem { get; set; }
        public decimal vProd { get; set; }
        public decimal vFrete { get; set; }
        public decimal vSeg { get; set; }
        public decimal vOutro { get; set; }
        public decimal vDesc { get; set; }
        public decimal pCofins { get; set; }
        public decimal vIcms { get; set; }
        public decimal vBC { get; set; }
        public decimal vCofins { get; set; }
    }
}
