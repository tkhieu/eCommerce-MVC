using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ContosoWebApp
{
    public partial class OrderManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count == 1)
                {
                    if (Request.QueryString["New"] == "1")
                    {
                        OfficePopupNewOrder.Show();
                    }
                }
            }
        }


        protected void NewOrderPopupOk()
        {
            
        }
    }
}