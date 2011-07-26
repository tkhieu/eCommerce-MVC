using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ContosoWebApp
{
    public partial class Docs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            (Master as Main).MainWorkspace.SelectedAreaID = "Area_Personal";
            (Master as Main).MainWorkspace.SelectedItemID = "Item_Docs";

            (Master as Main).MainRibbon.getGroupZone("GroupZone1").Content.Add(new TextBox());
            (Master as Main).MainRibbon.getRibbonGroup("RibbonGroup3").Visible = false;
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }
    }
}
