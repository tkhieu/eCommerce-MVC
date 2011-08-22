using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerce.Model.Abstract;

namespace eCommerce.WebUI.Controllers
{
    public class FoodController : Controller
    {
        private IFoodRepository _repository;
        public FoodController(IFoodRepository foodRepository)
        {
            _repository = foodRepository;
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
