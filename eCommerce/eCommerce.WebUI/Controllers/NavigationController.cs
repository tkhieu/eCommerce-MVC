using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using eCommerce.Model;
using eCommerce.Model.Abstract;

namespace eCommerce.WebUI.Controllers
{
    public class NavigationController : Controller
    {
        private IFoodRepository _repository;

        public NavigationController(IFoodRepository repository)
        {
            this._repository = repository;
        }

        //
        // GET: /Navigation/

        public PartialViewResult Menu()
        {
            IEnumerable<FOODTYPE> types = _repository.Types.OrderBy(x => x.ID);

            return PartialView(types);
        }

    }
}
