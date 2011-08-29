using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using eCommerce.Model;
using eCommerce.WebUI.Models.Account;

namespace eCommerce.WebUI.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

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
                                ListQuestions = list.Select(q => new SelectListItem
                                                                     {
                                                                         Text = q.Question,
                                                                         Value = q.ID.ToString()
                                                                     })
                            });
        }

        [HttpPost]
        public ActionResult Register(Register register)
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
    }
}
