﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using eCommerce.Model;
using eCommerce.Model.Abstract;
using eCommerce.Model.Controller;
using eCommerce.WebUI.Models.Account;

namespace eCommerce.WebUI.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/
        private IFoodRepository _repository;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            var db = new FoodStoreEntities();

            List<QUESTION> list = db.QUESTIONs.ToList();
            return View(new Register
                            {
                                ListQuestions = list
                            });
        }

        [HttpPost]
        public ActionResult Register(Register register)
        {
            if (ModelState.IsValid)
            {
                int city = CityController.GetIdByTerm(register.City);
                int district = DistrictController.GetIdByTerm(register.District);

                Model.Controller.AccountController.Insert(register.Username, register.Password, register.Name,
                                                          register.Address, register.Tel, register.SocialId,
                                                          register.Email, int.Parse(register.Question), register.Answer, city, district);
                Redirect("/Account/Login");
            }
            var db = new FoodStoreEntities();

            List<QUESTION> list = db.QUESTIONs.ToList();
            return View((new Register
                            {
                                ListQuestions = list
                            }));
        }
    }
}