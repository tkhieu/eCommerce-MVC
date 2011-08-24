using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeWebUI;
using eCommerce.Model;

namespace eCommerce.Admin
{
    public partial class Main : System.Web.UI.MasterPage
    {
        public OfficeRibbon MainRibbon { get { return this.OfficeRibbon; } }
        public OfficeWorkspace MainWorkspace { get { return this.Workspace1; } }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] != null)
            {
                int role = (int) Session["role"];
                string email = (String) Session["email"];
                string name = (String)Session["name"];
                string job = ProjectEnum.PrintRole(role);
                
                OfficeRibbon.ExtraText = String.Format("{0} - {1}", name,job);

                if (role == (int)ProjectEnum.Role.SuperAdmin)
                {
                }
                else if (role == (int)ProjectEnum.Role.SaleManage)
                {
                    LargeItemUser1.Enabled = false;
                    LargeItemUser2.Enabled = false;

                    LargeItemFood1.Enabled = false;
                    LargeItemFood2.Enabled = false;

                    LargeItemFoodType1.Enabled = false;
                    LargeItemFoodType2.Enabled = false;

                    LargeItemManage1.Enabled = false;
                    LargeItemManage2.Enabled = false;

                }
                else if (role == (int)ProjectEnum.Role.FoodManage)
                {
                    LargeItemUser1.Enabled = false;
                    LargeItemUser2.Enabled = false;

                    LargeItemManage1.Enabled = false;
                    LargeItemManage2.Enabled = false;

                    LargeItemSale1.Enabled = false;
                    LargeItemSale2.Enabled = false;

                    LargeItemManage1.Enabled = false;
                    LargeItemManage2.Enabled = false;
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }

        protected override void OnInit(EventArgs e)
        {
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
