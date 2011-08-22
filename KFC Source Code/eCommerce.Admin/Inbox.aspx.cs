using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eCommerce.Admin
{
    public partial class Inbox : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as Main).MainWorkspace.SelectedAreaID = "Area_Personal";
            (Master as Main).MainWorkspace.SelectedItemID = "Item_Inbox";


        }

        protected void TestPop(object sender, EventArgs e)
        {
            this.OfficePopup1.Show();
        }

        protected void OkPop(object sender, EventArgs e)
        {
            this.Label1.Text = "Text in textbox : " + this.TextBox1.Text + "<br>Value in combo : " + this.Combo1.SelectedValue;
            this.OfficePopup1.Hide();
        }

    }
}
