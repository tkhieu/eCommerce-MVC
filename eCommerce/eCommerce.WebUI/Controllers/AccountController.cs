using System.Collections.Generic;
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
            if (Session["login"] == null || (bool)Session["login"] ==false)
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }


        public ActionResult Password()
        {
            if (Session["login"] == null || (bool)Session["login"] == false)
            {
                return RedirectToAction("Login", "Account");
            }

            return View(new Password());
        }

        [HttpPost]
        public ActionResult Password(Password password)
        {
            if (ModelState.IsValid)
            {
                int accountId = int.Parse(Session["id"].ToString());
                if (eCommerce.Model.Controller.AccountController.ChangePassword(accountId,password.OldPassword,password.NewPassword))
                {
                    return RedirectToAction("Index","Account");
                }
            }

            return View(new Password()
                            {
                                Success = false
                            });
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
                return RedirectToAction("Login", "Account");
            }
            var db = new FoodStoreEntities();

            List<QUESTION> list = db.QUESTIONs.ToList();
            return View(register.ListQuestions = list);
        }

        public ActionResult Edit()
        {
            if (Session["login"] == null || (bool)Session["login"] == false)
            {
                return RedirectToAction("Login", "Account");
            }
            var db = new FoodStoreEntities();
             int accountId = int.Parse(Session["id"].ToString());
            ACCOUNT account = Model.Controller.AccountController.GetById(accountId);

            Edit edit = new Edit()
                            {
                                Address = account.Address,
                                //City = account.CITY.Name,
                                //District = account.DISTRICT.Name,
                                Name = account.Name,
                                SocialId = account.SocialID,
                                Tel = account.Tel,
                                Email = account.Email
                            };
            return View(edit);
        }


        [HttpPost]
        public ActionResult Edit(Edit edit)
        {
            int accountId = int.Parse(Session["id"].ToString());
            if (ModelState.IsValid)
            {
                int city = CityController.GetIdByTerm(edit.City);
                int district = DistrictController.GetIdByTerm(edit.District);
                
                if (Model.Controller.AccountController.Update(accountId, edit.Name, edit.Address, edit.Tel, edit.SocialId, city, district))
                {
                    return RedirectToAction("Index");
                }
            }

            var db = new FoodStoreEntities();
            

            
            return View();
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                if (Model.Controller.AccountController.IsLoginOk(login.Username,login.Password))
                {
                    ACCOUNT account = Model.Controller.AccountController.GetByUsername(login.Username);
                    Session["login"] = true;
                    Session["id"] = account.ID;

                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        public ActionResult OrderHistory()
        {
            if (Session["login"] == null || (bool)Session["login"] == false)
            {
                return RedirectToAction("Login", "Account");
            }
            var db = new FoodStoreEntities();
            int accountId = int.Parse(Session["id"].ToString());
            OrderHistory orderHistory = new OrderHistory()
                                            {
                                                Orders = db.ORDERs.Where(p => p.ACCOUNT.ID == accountId).ToList()
                                            };
            return View(orderHistory);
        }

        public ActionResult OrderDetail(int id)
        {
            if (Session["login"] == null || (bool)Session["login"] == false)
            {
                return RedirectToAction("Login", "Account");
            }
            var db = new FoodStoreEntities();
            int accountId = int.Parse(Session["id"].ToString());
            HistoryDetail historyDetail = new HistoryDetail()
                                              {
                                                  OrderDetails = db.ORDERDETAILs.Where(p=>p.ORDER.ID == id).ToList()
                                              };
            return View(historyDetail);
        }


        public ActionResult Logout()
        {
            Session["login"] = null;
            Session["id"] = null;
            return RedirectToAction("List", "Food");
        }
    }
}
