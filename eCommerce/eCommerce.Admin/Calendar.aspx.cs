using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace eCommerce.Admin
{
    public partial class Calendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as Main).MainWorkspace.SelectedAreaID = "Area_Personal";
            (Master as Main).MainWorkspace.SelectedItemID = "Item_Calendar";
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            e.Cell.Text = "";

            if (e.Day.Date.ToShortDateString() == DateTime.Today.ToShortDateString())
            {
                e.Cell.Attributes.Add("style", "border:2px solid #ffc473");
            }

            HtmlGenericControl a = new HtmlGenericControl("div");
            a.Attributes.Add("style", "padding:2px");
            a.InnerHtml = e.Day.Date.Day.ToString();
            e.Cell.Controls.Add(a);


        }
    }
}
