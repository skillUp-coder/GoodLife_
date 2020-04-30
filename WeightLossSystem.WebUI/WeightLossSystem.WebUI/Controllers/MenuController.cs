using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeightLossSystem.BL.Interface;
using WeightLossSystem.WebUI.Models.DatasForView;

namespace WeightLossSystem.WebUI.Controllers
{
    public class MenuController : Controller
    {
        private ISportSupplementService service;
        public MenuController(ISportSupplementService _service)
        {
            this.service = _service;
        }

        [HttpGet]
        public PartialViewResult Menu(string category = null,string cost =null)
        {
            ViewBag.SelectedCategory = category;
            ViewBag.SelectedCost = cost;

            MenuViewModel model = new MenuViewModel
            {
                CategoryNames = service.GetByCategoryName(),
            };

            return PartialView(model);
        }
    }
}