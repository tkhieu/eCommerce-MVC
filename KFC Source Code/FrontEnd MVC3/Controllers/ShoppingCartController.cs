using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace FrontEnd_MVC3.Controllers
{
    public class ShoppingCartController : Controller
    {
        //
        // GET: /ShoppingCart/
        FoodStoreEntities storeDB = new FoodStoreEntities();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult AddFoodToCart(int foodId)
        {
            List<ORDERDETAIL> orders = new List<ORDERDETAIL>();
            var food = storeDB.FOODs.SingleOrDefault(f => f.ID == foodId);
            if (Session["order"] != null)
            {
                orders = (List<ORDERDETAIL>)Session["order"];
                int flag = 1;
                for (int i = 0; i < orders.Count; i++)
                {
                    if (orders[i].Food == foodId)
                    {
                        orders[i].Count++;
                        orders[i].TotalPayment += orders[i].Price;
                        flag = 0;
                    }
                }
                if (flag == 1)
                {
                    ORDERDETAIL orderDetail = new ORDERDETAIL();
                    orderDetail.FOOD = food;
                    orderDetail.ID = orders[0].ID;
                    orderDetail.Food = foodId;
                    orderDetail.Count = 1;
                    orderDetail.Price = food.Price;
                    orderDetail.TotalPayment = food.Price;
                    orders.Add(orderDetail);
                    Session["order"] = orders;
                }
            }
            else
            {
                ORDERDETAIL orderDetail = new ORDERDETAIL();
                orderDetail.FOOD = food;
                orderDetail.ID = 1;
                orderDetail.Food = foodId;
                orderDetail.Count = 1;
                orderDetail.Price = food.Price;
                orderDetail.TotalPayment = food.Price;
                orders.Add(orderDetail);
                Session["order"] = orders;
            }
            return PartialView("Index");
        }
    }
}
