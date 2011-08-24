using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerce.Model.Concrete;

namespace eCommerce.WebUI.Controllers
{
    public class FoodController : Controller
    {
        private EFFoodRepository _repository;
        public FoodController(EFFoodRepository repository)
        {
            this._repository = repository;
        }
        //
        // GET: /Food/

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult List()
        {
            return View(_repository.Foods);
        }

    }
}
