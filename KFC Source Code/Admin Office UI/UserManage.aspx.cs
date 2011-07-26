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

                    var listQuestion = QuestionController.GetList();
                    foreach (var question in listQuestion)
                    {
                        var listItem = new ListItem(question.Question, question.ID.ToString());
                        NewUserQuestion.Items.Add(listItem);
                    }
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