using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using WeightLossSystem.BL.DTO;
using WeightLossSystem.BL.Interface;
using WeightLossSystem.WebUI.Models.DatasForView;

namespace WeightLossSystem.WebUI.Controllers
{
    public class NutritionBlogController : Controller
    {
        private INutritionBlogService service;
        public NutritionBlogController(INutritionBlogService _service)
        {
            this.service = _service;
        }


        public ActionResult DisplayPage()
        {
            var mapper = new MapperConfiguration(cfg=>cfg.CreateMap<NutritionBlogDTO, NutritionBlogViewModel>()).CreateMapper();
            var model = mapper.Map<IEnumerable<NutritionBlogDTO>, IList<NutritionBlogViewModel>>(service.GetBlogs());
            return View(model);
        }
        public ActionResult ReadPage(int id) 
        {
            var data = service.GetBlog(id);
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<NutritionBlogDTO, NutritionBlogViewModel>()).CreateMapper();
            var model = mapper.Map<NutritionBlogDTO, NutritionBlogViewModel>(service.GetBlog(id));
            return View(model);
        }

        protected override void Dispose(bool disposing)
        {
            service.Dispose();
            base.Dispose(disposing);
        }
    }
}