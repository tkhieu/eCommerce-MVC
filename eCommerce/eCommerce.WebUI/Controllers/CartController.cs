using System;
using System.Linq;
using System.Web.Mvc;
using eCommerce.Model;
using eCommerce.Model.Abstract;
using eCommerce.Utility;
using eCommerce.WebUI.Models;
using eCommerce.WebUI.Models.Shopping;

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

        public ViewResult Index(Cart cart,string returnUrl)
        {
            ViewData["ImageCDN"] = _imageCDN;
            return View(new CartIndexViewModel
                            {
                                Cart = cart,
                                ReturnUrl = returnUrl
                            });
        }

        public RedirectToRouteResult AddToCart(Cart cart,int ID, string returnUrl)
        {
            FOOD food = _repository.Foods.FirstOrDefault(p => p.ID == ID);
            if (food !=null)
            {
                cart.AddItem(food, 1);
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToRouteResult UpdateQuantity(Cart cart, int ID,int quantity, string returnUrl)
        {

            FOOD food = _repository.Foods.FirstOrDefault(p => p.ID == ID);
            cart.UpdateQuantity(food,quantity);
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart,int foodId,string returnUrl)
        {
            FOOD food = _repository.Foods.FirstOrDefault(p => p.ID == foodId);
            if (food != null)
            {
                cart.RemoveItem(food);
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        public ViewResult Summary(Cart cart)
        {
            return View(cart);
        }

    }
}