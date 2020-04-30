using WeightLossSystem.BL.Services;

namespace WeightLossSystem.WebUI.Models.DatasForView
{
    public class CartViewModel
    {
        public CartService Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}