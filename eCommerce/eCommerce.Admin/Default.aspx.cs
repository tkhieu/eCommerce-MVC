using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eCommerce.Utility;

namespace eCommerce.Admin
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.Title = String.Format("{0} | {1}", Configuration.SYSTEM_NAME, "Home");
        }
    }
}
