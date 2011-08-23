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
            var list = OrderController.GetList();
            var listOrder = from order in list
                            select new
                            {
                                ID = order.ID,
                                Username = order.ACCOUNT.Username,
                                Name = order.Name,
                                Tel = order.Tel,

                                Address = order.Address,
                                District = order.DISTRICT.Name,
                                City = order.CITY.Name,

                                Time = order.Date,
                                State = (order.State == 1) ? "New" : (order.State == 2) ? "Processing" : (order.State == 3)?"Finish":"Error",
                                TotalPayment = order.TotalPayment
                            };

            GridViewListOrder.DataSource = listOrder;
            GridViewListOrder.DataBind();

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



        protected void GridViewListOrder_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
            int a  = e.NewEditIndex;
            string idS = GridViewListOrder.Rows[e.NewEditIndex].Cells[1].Text;
            int id = int.Parse(idS);
            ORDER order = OrderController.GetById(id);
            ACCOUNT account = order.ACCOUNT;

            OrderUserId.Text = account.ID.ToString();
            OrderUserFullName.Text = account.Name;
            OrderUserAddress.Text = account.Address;
            OrderUserCity.Text = account.CITY.Name;
            OrderUserDistrict.Text = account.DISTRICT.Name;
            OrderUserTel.Text = account.Tel;
            OrderUserEmail.Text = account.Tel;
            OrderUserUsername.Text = account.Username;

            OrderAddressAddress.Text = order.Address;
            OrderAddressCity.Text = order.CITY.Name;
            OrderAddressDistrict.Text = order.DISTRICT.Name;
            OrderAddressFullName.Text = order.Name;
            OrderAddressTel.Text = order.Tel;
            if (order.State == 1)
            {
                OrderStatus.SelectedValue = "1";
            } else if (order.State == 2)
            {
                OrderStatus.SelectedValue = "2";
            } else if (order.State == 3)
                OrderStatus.SelectedValue = "3";
            var listOrderDetail = from orderdetail in order.ORDERDETAILs
                                  select new
                                             {
                                                 Name = orderdetail.FOOD.Name,
                                                 Type = orderdetail.FOOD.FOODTYPE.Name,
                                                 Count = orderdetail.Count,
                                                 Price = orderdetail.Price,
                                                 Total = orderdetail.Count * orderdetail.Price
                                             };
            GridViewOrderDetail.DataSource = listOrderDetail;
            GridViewOrderDetail.DataBind();

            int totalPayment = 0;
            foreach (ORDERDETAIL orderdetail in order.ORDERDETAILs)
            {
                var i = orderdetail.Count * orderdetail.Price;
                if (i != null)
                    totalPayment += (int) i;
            }

            OrderDetailTotal.Value = totalPayment.ToString();
            Session["orderid"] = order.ID;
            OfficePopupViewOrder.Show();
        }

        protected void OfficePopupOrderOk(object sender, EventArgs e)
        {
            int id = int.Parse(Session["orderid"].ToString());
            ORDER order = OrderController.GetById(id);
            if (order.State != null)
            {
                int state = (int) order.State;
                if (state != int.Parse(OrderStatus.SelectedValue))
                {
                    state = int.Parse(OrderStatus.SelectedValue);
                    if (OrderController.UpdateState(id, state))
                    {
                        OfficeMessageBoxUpdateStateSuccess.Show();
                    } else OfficeMessageBoxUpdateStateFail.Show();
                }
            }
            Session["orderid"] = null;
            OfficePopupViewOrder.Hide();
        }
    }
}