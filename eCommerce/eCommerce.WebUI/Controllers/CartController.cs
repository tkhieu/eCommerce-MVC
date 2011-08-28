using System;
using System.Linq;
using System.Web.Mvc;
using eCommerce.Model;
using eCommerce.Model.Abstract;
using eCommerce.Model.Entities;
using eCommerce.Utility;
using eCommerce.WebUI.Models;

namespace eCommerce.WebUI.Controllers
{
    public class CartController : Controller
    {
        private String _imageCDN = Configuration.IMAGE_CDN_HOST;

        private IFoodRepository _repository;
        public CartController(IFoodRepository repository)
        {
            this._repository = repository;
        }

        public ViewResult Index(string returnUrl)
        {
            ViewData["ImageCDN"] = _imageCDN;
            return View(new CartIndexViewModel
                            {
                                Cart = GetCart(),
                                ReturnUrl = returnUrl
                            });
        }

        public RedirectToRouteResult AddToCart(int ID, string returnUrl)
        {
            FOOD food = _repository.Foods.FirstOrDefault(p => p.ID == ID);
            if (food !=null)
            {
                GetCart().AddItem(food, 1);
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToRouteResult RemoveFromCart(int foodId,string returnUrl)
        {
            FOOD food = _repository.Foods.FirstOrDefault(p => p.ID == foodId);
            if (food != null)
            {
                GetCart().RemoveItem(food);
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}