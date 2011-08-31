using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerce.Model;
using eCommerce.Model.Concrete;
using eCommerce.Utility;
using eCommerce.WebUI.Models;
using eCommerce.WebUI.Models.Supporter;

namespace eCommerce.WebUI.Controllers
{
    public class FoodController : Controller
    {
        private String _imageCDN = Configuration.IMAGE_CDN_HOST;
        private EFFoodRepository _repository;
        private const int PAGE_SIZE = Configuration.PAGE_SIZE;


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

        public ViewResult List(string type,int page = 1)
        {
            FoodListViewModel foodListViewModel = new FoodListViewModel
                                                      {
                                                          Foods = _repository.Foods
                                                                              .Where(p=> type == null || p.FOODTYPE.Alias == type)
                                                                              .OrderBy(p => p.ID)
                                                                              .Skip((page - 1) * PAGE_SIZE)
                                                                              .Take(PAGE_SIZE),
                                                          PagingInfo = new PagingInfo
                                                                           {
                                                                               CurrentPage = page,
                                                                               ItemPerPage = PAGE_SIZE,
                                                                               TotalItem = type == null? _repository.Foods.Count() : _repository.Foods.Where(p=>p.FOODTYPE.Alias == type).Count()
                                                                           },
                                                                           CurrentFoodType = type
                                                      };
            ViewData["ImageCDN"] = _imageCDN;

            return View(foodListViewModel);
        }

        public ViewResult Detail(int id)
        {
            ViewData["ImageCDN"] = _imageCDN;
            FOOD food = Model.Controller.FoodController.GetById(id);
            return View(food);
        }

    }
}
;