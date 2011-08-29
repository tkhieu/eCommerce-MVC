using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using eCommerce.Model;

namespace eCommerce.WebUI.Controllers
{
    public class ValidationController : Controller
    {
        //
        // GET: /Validation/

        private FoodStoreEntities _db;

        public JsonResult UsernameExists(string username)
        {
            _db = new FoodStoreEntities();
            List<String> list = _db.ACCOUNTs.Select(x => x.Username).ToList();
            foreach (string s in list)
            {
                if (s.ToLower() == username.ToLower())
                {
                    return Json("Username already exists", JsonRequestBehavior.AllowGet);
                }
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult District(string district)
        {
            _db = new FoodStoreEntities();
            try
            {
                DISTRICT dist = _db.DISTRICTs.Single(x => x.Name == district);
            }
            catch (Exception)
            {
                return Json("District isn't exists", JsonRequestBehavior.AllowGet);
            }
           
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public JsonResult City(string city)
        {
            _db = new FoodStoreEntities();
            try
            {
                CITY c = _db.CITies.Single(x => x.Name == city);
            }
            catch (Exception)
            {
                return Json("City isn't exists", JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}