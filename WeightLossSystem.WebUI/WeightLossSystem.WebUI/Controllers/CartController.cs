using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using WeightLossSystem.BL.DTO;
using WeightLossSystem.BL.Infrastructure;
using WeightLossSystem.BL.Interface;
using WeightLossSystem.BL.Services;
using WeightLossSystem.WebUI.Models.DatasForView;

namespace WeightLossSystem.WebUI.Controllers
{
    public class CartController : Controller
    {
        ISportSupplementService service;
        IOrderProcessor orderProcessor;
        public CartController(ISportSupplementService _service, IOrderProcessor order)
        {
            this.service = _service;
            this.orderProcessor = order;
        }

        public RedirectToRouteResult AddToCart(CartService cart,int id)
        {
            var item = service.GetSportSupplement(id);
            SportSupplementDTO data = new SportSupplementDTO 
            {
                SportSupplementId = item.SportSupplementId,
                CategoryName = item.CategoryName,
                Date = item.Date,
                Description = item.Description,
                Name = item.Name,
                Price = item.Price
            };
            if (data == null)
                throw new ValidationException("Don`t found datas","");
            
            else cart.AddItem(data, 1);

            return RedirectToAction("DisplaySportSuplement", "SportSupplement");
        }

        public RedirectToRouteResult RemoveFromCart(CartService cart, int id) 
        {
            var item = service.GetSportSupplement(id);
            SportSupplementDTO data = new SportSupplementDTO
            {
                SportSupplementId = item.SportSupplementId,
                CategoryName = item.CategoryName,
                Date = item.Date,
                Description = item.Description,
                Name = item.Name,
                Price = item.Price
            };
            if (data == null)
                throw new ValidationException("Don`t found data", "");
            else
                cart.ReamoveLine(data);

            return RedirectToAction("DisplayCart", "Cart");
        }

        public ViewResult DisplayCart(CartService cart) 
        {
            return View(new CartViewModel 
            {
                 Cart = cart,
                
            });
        }

        public PartialViewResult Summary(CartService cart) 
        {
            return PartialView(cart);
        }

        public ViewResult Checkout() 
        {
            return View(new ShippingViewModel());
        }

        [HttpPost]
        public ActionResult Checkout(CartService cart, ShippingViewModel model)
        {
            if (ModelState.IsValid)
            {
                ShippingDTO shipping = new ShippingDTO
                {
                    City = model.City,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName  = model.LastName,
                    GiftWrap = model.GiftWrap
                };

                if (cart.Lines.Count() == 0)
                    ModelState.AddModelError("", "You cart is empty!");

                orderProcessor.ProcessOrder(cart, shipping);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(model);
            }
        } 
    }
}