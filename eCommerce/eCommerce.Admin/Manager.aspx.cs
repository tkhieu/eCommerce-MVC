using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using eCommerce.Model.Controller;
using eCommerce.Utility.Encryption;
using eCommerce.Utility;

namespace eCommerce.Admin
{
    public partial class Manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString.Count == 1 && Request.QueryString["New"] == "1")
                {
                    OfficePopupManage.Show();
                }
            }
        }

        protected void OfficePopupNewManageOk(object sender, EventArgs e)
        {
            String name = NewManageName.Text;
            String email = NewManageEmail.Text;
            String password = NewManagePassword.Text;
            String role = NewManageRole.SelectedValue;

            String toHash = String.Format("{0}*{1}*{2}",email,password,role);
            String hashed = StringEncrypt.EncryptString(toHash, Configuration.ENCRYPT_PASSWORD);

            OfficePopupManage.Hide();
            if (!ManagerController.IsExistEmail(email))
            {
                if (ManagerController.Insert(hashed, name))
                {

                    OfficeMessageBoxAddManageSuccess.Show();
                }
                else
                {
                    OfficeMessageBoxAddManageFail.Show();

                }    
            }
            else
            {
                OfficeMessageBoxManagerExist.Show();   
            }
            

        }

        protected void OnOfficeMessageBoxFailYes(object sender, EventArgs e)
        {
            OfficePopupManage.Show();
        }
    }
}