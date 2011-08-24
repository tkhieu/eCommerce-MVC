using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OfficeWebUI;
using eCommerce.Model.Controller;
using eCommerce.Utility.Encryption;
using eCommerce.Utility;

namespace eCommerce.Admin
{
    public partial class Manager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Header.Title = String.Format("{0} | {1}", Configuration.SYSTEM_NAME, "Manage");

            if (!IsPostBack)
            {
                if (Request.QueryString.Count == 1 && Request.QueryString["New"] == "1")
                {
                    OfficePopupManage.Show();
                }
            }

            List<FManager> list = ManagerController.GetListFManage();
            GridViewListManager.DataSource = list;
            GridViewListManager.DataBind();
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

        protected void ManageResendPassword(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true;
            int id = int.Parse(GridViewListManager.Rows[e.NewEditIndex].Cells[1].Text);
            Session["mdelid"] = id;
            OfficeMessageBoxConfirmEdit.Show();
        }

        protected void ManagerDelete(object sender, GridViewDeleteEventArgs e)
        {
            int id = int.Parse(GridViewListManager.Rows[e.RowIndex].Cells[1].Text);
            Session["mdelid"] = id;
            OfficeMessageBoxConfirmDelete.Show();
        }

        protected void DeleteManagerYes(object sender, EventArgs e)
        {
            if (OfficeMessageBoxConfirmDelete.ReturnValue == MessageBoxReturnType.Yes)
            {
                int id = (int)Session["mdelid"];
                if (ManagerController.DeleteById(id))
                {
                    OfficeMessageBoxDeleteManagerSuccess.Show();
                }
                else
                {
                    OfficeMessageBoxDeleteManagerFail.Show();
                }
            }
            Session["mdelid"] = null;
        }

        protected void ResendManagerInfoYes(object sender, EventArgs e)
        {
            if (OfficeMessageBoxConfirmEdit.ReturnValue == MessageBoxReturnType.Yes)
            {
                int id = (int)Session["mdelid"];
                if (ManagerController.ResendPassword(id))
                {
                    OfficeMessageBoxResendPassSuccess.Show();
                }
                else
                {
                    OfficeMessageBoxResendPasswordFail.Show();
                }
                Session["mdelid"] = null;
            }
        }
    }
}