using System;
using System.Collections.Generic;
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

        private readonly IFoodRepository _repository;

        public CartController(IFoodRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            ViewData["ImageCDN"] = _imageCDN;
            return View(new CartIndexViewModel
                            {
                                Cart = cart,
                                ReturnUrl = returnUrl
                            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int ID, string returnUrl)
        {
            FOOD food = _repository.Foods.FirstOrDefault(p => p.ID == ID);
            if (food != null)
            {
                cart.AddItem(food, 1);
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToRouteResult UpdateQuantity(Cart cart, int ID, int quantity, string returnUrl)
        {
            FOOD food = _repository.Foods.FirstOrDefault(p => p.ID == ID);
            cart.UpdateQuantity(food, quantity);
            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int foodId, string returnUrl)
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

        public ActionResult Checkout()
        {
            if (Session["login"] == null || (bool) Session["login"] != true)
            {
                return RedirectToAction("Login", "Account");
            }
            ACCOUNT account = Model.Controller.AccountController.GetById((int) Session["id"]);
            ViewData["account"] = account;


            var list = new List<Address>();
            IQueryable<ORDER> orders = _repository.Orders.Where(p => p.ACCOUNT.ID == account.ID);
            foreach (ORDER order in orders)
            {
                string fullAdd = order.Name + " - " + order.Tel + " - " + order.Address + " - " +
                                 order.DISTRICT.Name + " - " + order.CITY.Name;
                bool flag = true;
                foreach (Address address in list)
                {
                    if (address.FullAdd == fullAdd)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    var address = new Address
                                      {
                                          Id = order.ID,
                                          Name = order.Name,
                                          Add = order.Address,
                                          City = order.CITY.ID,
                                          District = order.DISTRICT.ID,
                                          Tel = order.Tel,
                                          FullAdd = fullAdd
                                      };
                    list.Add(address);
                }
            }

           

            return View(new ShippingDetail {ListAddress = list,NewAddress = true,PaymentMethod = 3});
        }

        [HttpPost]
        public ActionResult Checkout(ShippingDetail shipping)
        {
            if (ModelState.IsValid)
            {
                CheckoutConfirmModel confirm = new CheckoutConfirmModel();
                confirm.Cart = (Cart)Session["Cart"];
                confirm.Shipping = new ShippingDetail();
                if (shipping.NewAddress)
                {
                    confirm.Shipping.Name = shipping.Name;
                    confirm.Shipping.Email = shipping.Email;
                    confirm.Shipping.SocialId = shipping.SocialId;
                    confirm.Shipping.Tel = shipping.Tel;
                    confirm.Shipping.Address = shipping.Address;
                    confirm.Shipping.District = shipping.District;
                    confirm.Shipping.City = shipping.City;
                    confirm.Shipping.PaymentMethod = shipping.PaymentMethod;
                }
                else
                {
                    ORDER order = _repository.Orders.Single(p => p.ID == shipping.SelectAddress);
                    confirm.Shipping.Name = order.Name;
                    confirm.Shipping.Email = order.ACCOUNT.Email;
                    confirm.Shipping.SocialId = order.ACCOUNT.SocialID;
                    confirm.Shipping.Tel = order.Tel;
                    confirm.Shipping.Address = order.Address;
                    confirm.Shipping.District = order.DISTRICT.Name;
                    confirm.Shipping.City = order.CITY.Name;
                    confirm.Shipping.PaymentMethod = shipping.PaymentMethod;
                }
                Session["confirm"] = confirm;
                return RedirectToAction("Confirm", "Cart");
            }

            ACCOUNT account = Model.Controller.AccountController.GetById((int)Session["id"]);
            ViewData["account"] = account;


            var list = new List<Address>();
            IQueryable<ORDER> orders = _repository.Orders.Where(p => p.ACCOUNT.ID == account.ID);
            foreach (ORDER order in orders)
            {
                string fullAdd = order.Name + " - " + order.Tel + " - " + order.Address + " - " +
                                 order.DISTRICT.Name + " - " + order.CITY.Name;
                bool flag = true;
                foreach (Address address in list)
                {
                    if (address.FullAdd == fullAdd)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    var address = new Address
                    {
                        Id = order.ID,
                        Name = order.Name,
                        Add = order.Address,
                        City = order.CITY.ID,
                        District = order.DISTRICT.ID,
                        Tel = order.Tel,
                        FullAdd = fullAdd
                    };
                    list.Add(address);
                }
            }



            return View(new ShippingDetail { ListAddress = list, NewAddress = true, PaymentMethod = 3 });

        }




        public ViewResult Confirm()
        {
            ViewData["ImageCDN"] = _imageCDN;
            CheckoutConfirmModel confirm = (CheckoutConfirmModel) Session["confirm"];
            return View(confirm);
        }
    }
}