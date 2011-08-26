using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
        private int _pageSize = Configuration.PAGE_SIZE;

        
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

        public ViewResult List(int page = 1)
        {
            FoodListViewModel foodListViewModel = new FoodListViewModel
                                                      {
                                                          Foods = _repository.Foods
                                                                              .OrderBy(p => p.ID)
                                                                              .Skip((page - 1) * _pageSize)
                                                                              .Take(_pageSize),
                                                          PagingInfo = new PagingInfo
                                                                           {
                                                                               CurrentPage = page,
                                                                               ItemPerPage = _pageSize,
                                                                               TotalItem = _repository.Foods.Count()
                                                                           }
                                                      };
            ViewData["ImageCDN"] = _imageCDN;

            return View(foodListViewModel);
        }

    }
}
;