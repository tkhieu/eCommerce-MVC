using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeWebUI;

namespace ContosoWebApp
{
    public partial class Main : System.Web.UI.MasterPage
    {
        public OfficeRibbon MainRibbon { get { return this.OfficeRibbon1; } }
        public OfficeWorkspace MainWorkspace { get { return this.Workspace1; } }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs e)
        {
            this.OfficeRibbon1.ExtraText = "Peter Johnson - Marketing";

            base.OnInit(e);
        }

        protected void GotoInbox(object sender, EventArgs e)
        {
            
        }

        protected void GotoSent(object sender, EventArgs e)
        {
            
        }
    }
}
