using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//Using by Kimhieuqtvn
using Model;

namespace ContosoWebApp
{
    public partial class UserManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Trường hợp chỉ nhận 1 Query String là New
            if (Request.QueryString.Count == 1)
            {
                if (Request.QueryString["New"] == "1")
                {

                    //Đổ dữ liệu vào NewUserQuestion
                    var listQuestion = QuestionController.GetList();
                    NewUserQuestion.DataTextField = "Question";
                    NewUserQuestion.DataValueField = "ID";
                    NewUserQuestion.DataSource = listQuestion;
                    NewUserQuestion.DataBind();
                    

                    //Hiển thị OfficePopupNewUser
                    OfficePopupNewUser.RecreateChildControls();
                    OfficePopupNewUser.Show();
                }
            }
        }

        protected void NewUserPopupOk (object sender, EventArgs eventArgs)
        {
            
        }
    }
}