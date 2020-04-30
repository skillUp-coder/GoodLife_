using Ninject.Modules;
using System.Configuration;
using WeightLossSystem.BL.DTO;
using WeightLossSystem.BL.Interface;
using WeightLossSystem.BL.Services;

namespace WeightLossSystem.WebUI.Util
{
    public class ServiceModuleWebUI : NinjectModule
    {
        EmailSettings EmailSettings = new EmailSettings
        {
            WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
        };


        public override void Load()
        {
            Bind<ICategoryService>().To<CategoryService>();
            Bind<IUserService>().To<UserService>();
            Bind<ISportSupplementService>().To<SportSupplementService>();
            Bind<INutritionBlogService>().To<NutritionBlogService>();
            Bind<ICartService<SportSupplementDTO>>().To<CartService>();
            Bind<IShippingService>().To<ShippingService>();
            Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", EmailSettings);
        }
    }
}