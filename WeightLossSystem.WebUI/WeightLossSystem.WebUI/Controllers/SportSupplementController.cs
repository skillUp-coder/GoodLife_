using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeightLossSystem.BL.DTO;
using WeightLossSystem.BL.Interface;
using AutoMapper;
using WeightLossSystem.WebUI.Models;
using WeightLossSystem.WebUI.Models.DatasForView;

namespace WeightLossSystem.WebUI.Controllers
{
    public class SportSupplementController : Controller
    {
        private ISportSupplementService service;
        public SportSupplementController(ISportSupplementService _service)
        {
            this.service = _service;
        }

        [HttpGet]
        public ActionResult DisplaySportSuplement(string category, int page = 1 , string cost = null) 
        {   
            int PageSize = 1;
            IEnumerable<SportSupplementDTO> datas;
            switch (cost) 
            {
                    case "to-cheap":
                        datas = service.SortedDatas();
                        break;
                    default:
                        datas = service.DatasMatchingCategories(page, PageSize, category);
                        break;
            }      
                
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<SportSupplementDTO, SportSupplementViewModel>()).CreateMapper();

            var model = new SportCategoryViewModel<SportSupplementViewModel>
            {
                SportSuplements = mapper.Map<IEnumerable<SportSupplementDTO>, IList<SportSupplementViewModel>>(datas),
                info = new InfoOfPage
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = service.Count(category)
                },
                CurrentCategory = category
            };    
                return View(model); 
        }

        protected override void Dispose(bool disposing)
        {
            this.service.Dispose();
            base.Dispose(disposing);
        }
    }
}