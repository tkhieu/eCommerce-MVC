using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace FrontEnd_MVC3.Controllers
{
    public class StoreController : Controller
    {
        //
        // GET: /Store/
        FoodStoreEntities StoreDB = new FoodStoreEntities();

        public ActionResult Index()
        {
            var listFoodType = StoreDB.FOODTYPEs.ToList();
            return View(listFoodType);
        }
        //Xem các món ăn thuộc về một loại món ăn(foodtype)
        public ActionResult Browse(int id)
        {
            var listFood = StoreDB.FOODs.Where(p => p.FoodTypeId == id).ToList();
            return View(listFood);
        }
        //Xem thông tin chi tiết về một món ăn
        public ActionResult Detail(int id)
        {
            var food = StoreDB.FOODs.Single(p => p.ID == id);
            return View(food);
        }
        //Kết quả tìm kiếm
        public  ActionResult SearchResult(List<FOOD> listFood )
        {
            return View(listFood);
        }
        //Tìm một loại món ăn theo tên
        public PartialViewResult Search(string name)
        {
            var listFood = StoreDB.FOODs.Where(p => p.Name.Contains(name) == true);
            return PartialView("SearchResult",listFood);
        }
        //Tìm kiếm nâng cao
        public PartialViewResult SuperSearch(string name, int priMin, int priMax)
        {
            var listFood = new List<FOOD>();
            if (priMin != null && priMax != null)
            {
                listFood = StoreDB.FOODs.Where(p => (p.Name.Contains(name) == true || p.Detail.Contains(name) == true) && (p.Price > priMin && p.Price < priMax)).ToList();
            }
            else if (priMin != null)
            {
                listFood = StoreDB.FOODs.Where(p => (p.Name.Contains(name) == true || p.Detail.Contains(name) == true) && p.Price > priMin).ToList();
            }
            else if (priMax != null)
            {
                listFood = StoreDB.FOODs.Where(p => (p.Name.Contains(name) == true || p.Detail.Contains(name) == true) && p.Price < priMax).ToList();
            }
            else
            {
                listFood = StoreDB.FOODs.Where(p => p.Name.Contains(name) == true || p.Detail.Contains(name) == true).ToList();
            }
            return PartialView("SearchResult", listFood);
        }

    }
}
