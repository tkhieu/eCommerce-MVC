using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eCommerce.Model;
using eCommerce.Model.Controller;

namespace eCommerce.Admin
{
    public partial class OrderManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;
            if (Request.QueryString.Count != 1) return;
            if (Request.QueryString["New"] == "1")
            {
                OfficePopupNewOrder.Show();
            }
        }


        protected void NewOrderPopupOk(object sender, EventArgs e)
        {
            int userId;
            if (NewUserIsGuest.Checked)
            {
                userId = 0;
            }
            else
            {
                userId = int.Parse(NewOrderUserId.Value);
            }

            String name = NewOrderName.Text;
            String username = NewOrderUser.Text;
            String tel = NewOrderTel.Text;


            String address = NewOrderAddress.Text;
            String district = NewOrderDistrict.Text;
            int districtId = int.Parse(NewOrderDistrictId.Value);
            String city = NewOrderCity.Text;
            int cityId = int.Parse(NewOrderCityId.Value);

            DateTime orderTime;

            bool test = DateTime.TryParse(NewOrderTime.Text, out orderTime);
            if (!test)
            {
                orderTime = DateTime.Now;
            }

            String note = NewOrderNote.Text;
            int totalPayment = int.Parse(NewOrderTotal.Text);

            String foodarray = NewFoodArray.Value;
            String countarray = NewCountArray.Value;

            char[] comma = new char[]{','};
            string[] foods = foodarray.Split(comma, StringSplitOptions.RemoveEmptyEntries);
            string[] counts = countarray.Split(comma, StringSplitOptions.RemoveEmptyEntries);
            List<int> foodarr = new List<int>();
            List<int> countarr = new List<int>();
            foreach (string food in foods)
            {
                foodarr.Add(int.Parse(food));
            }
            foreach (string i in counts)
            {
                countarr.Add(int.Parse(i));
            }

            if (OrderController.Insert(userId, name, address, tel, orderTime, note, 1, totalPayment, cityId, districtId, foodarr, countarr))
            {
                OfficeMessageBoxAddOrderSuccess.Show();
                OfficePopupNewOrder.Hide();
            }
            else
            {
                OfficeMessageBoxAddOrderSuccess.Show();
                OfficePopupNewOrder.Hide();
            }
        }

        protected void OnOfficeMessageBoxOrderFailYes(object sender, EventArgs e)
        {
            OfficePopupNewOrder.Show();
        }
    }
}