using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeightLossSystem.BL.DTO;
using WeightLossSystem.BL.Interface;
using AutoMapper;
using WeightLossSystem.WebUI.Models;

namespace WeightLossSystem.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryService categoryService;
        public HomeController(ICategoryService service)
        {
            this.categoryService = service;
        }
        public ActionResult DisplayCategory() 
        {
            IEnumerable<CategoryDTO> categ = categoryService.GetCategories();
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<CategoryDTO, CategoryViewModel>()).CreateMapper();
            var category = mapper.Map<IEnumerable<CategoryDTO>,IList<CategoryViewModel>>(categ);
            return View(category);
        }


        protected override void Dispose(bool disposing)
        {
            categoryService.Dispose();
            base.Dispose(disposing);
        }
    }
}