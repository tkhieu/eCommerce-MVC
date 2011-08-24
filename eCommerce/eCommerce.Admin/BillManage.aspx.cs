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
    public partial class BillManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var list = BillController.GetList();
            var listBill = from bill in list
                           select new
                                      {
                                          ID = bill.ID,
                                          Username = bill.ORDER.ACCOUNT.Username,
                                          Name = bill.ORDER.Name,
                                          Tel = bill.ORDER.Tel,
                                          Address = bill.ORDER.Address,
                                          District = bill.ORDER.DISTRICT.Name,
                                          City = bill.ORDER.CITY.Name,
                                          PaymentMethod = (bill.PaymentMethor == (int)ProjectEnum.Payment.Paypay)?"Paypal":(bill.PaymentMethor == (int)ProjectEnum.Payment.NganLuong)?"Ngân Lượng":(bill.PaymentMethor == (int)ProjectEnum.Payment.Tradition)?"Tradition":"Error",
                                          Time = bill.Date,
                                          TotalPayment = bill.TotalPayment
                                      };
            GridViewListBill.DataSource = listBill;
            GridViewListBill.DataBind();
        }

        protected void GridViewListOrder_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int editRow = e.NewEditIndex;
            int billId = int.Parse(GridViewListBill.Rows[editRow].Cells[1].Text);
            BILL bill = BillController.GetById(billId);
            int orderId = bill.ORDER.ID;
            string url = String.Format("~/OrderManage.aspx?ID={0}", orderId);
            Response.Redirect(url);
        }
    }
}