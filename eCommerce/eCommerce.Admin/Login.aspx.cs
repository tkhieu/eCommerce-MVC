using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eCommerce.Model.Controller;
using eCommerce.Utility;

namespace eCommerce.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.Title = String.Format("{0} | {1}", Configuration.SYSTEM_NAME,"Login");

            if (Session["login"] != null)
            {
                if ((bool)Session["login"] == false)
                {
                    LabelLoginNotice.Text = @"Login Error...!";
                    Session["login"] = null;
                }    
            }
            
                
        }

        protected void ManagerLogin(object sender, EventArgs e)
        {
            String email = ManageEmail.Text;
            String password = ManagePassword.Text;

            if (ManagerController.IsLoginOk(email, password))
            {
                Session["email"] = email;
                Session["name"] = ManagerController.GetNameByEmail(email);
                Session["role"] = ManagerController.GetRoleByEmail(email);
                Response.Redirect("Default.aspx");
            }
            else
            {
                Session["login"] = false;
                Response.Redirect("Login.aspx");
                
            }

        }
    }
}