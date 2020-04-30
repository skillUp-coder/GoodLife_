

using System.Web.Mvc;
using WeightLossSystem.BL.Services;

namespace WeightLossSystem.WebUI.Infrastructure.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";
        public object BindModel(ControllerContext controllerContext,
           ModelBindingContext bindingContext)
        {
            CartService cart = null;
            if (controllerContext.HttpContext.Session != null) 
            {
                cart = (CartService)controllerContext.HttpContext.Session[sessionKey];
            }
            if (cart == null) 
            {
                cart = new CartService();
                if (controllerContext.HttpContext.Session!=null) 
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }
            return cart;
        }
    }
}