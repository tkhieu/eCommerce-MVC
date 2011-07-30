using System;
using System.Collections.Generic;
using System.Web.UI;
using Model;
//Using by Kimhieuqtvn

namespace ContosoWebApp
{
    public partial class UserManage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //NewUserCity.ViewStateMode = ViewStateMode.Enabled;
            
            //Kiểm tra xem có đang ở trạng thái PostBack hay không
            if (!IsPostBack)
            {
                // Trường hợp chỉ nhận 1 Query String là New
                if (Request.QueryString.Count == 1)
                {
                    if (Request.QueryString["New"] == "1")
                    {
                        //Đổ dữ liệu vào NewUserQuestion
                        List<QUESTION> listQuestion = QuestionController.GetList();
                        NewUserQuestion.DataTextField = "Question";
                        NewUserQuestion.DataValueField = "ID";
                        NewUserQuestion.DataSource = listQuestion;
                        NewUserQuestion.DataBind();

                        //Đổ dữ liệu vào NewUserCity
                        List<CITY> listCity = CityController.GetList();
                        NewUserCity.DataTextField = "Name";
                        NewUserCity.DataValueField = "ID";
                        NewUserCity.DataSource = listCity;
                        NewUserCity.DataBind();


                        //Hiển thị OfficePopupNewUser
                        OfficePopupNewUser.RecreateChildControls();
                        OfficePopupNewUser.Show();
                    }
                }

            }
            NewUserCity.SelectedIndexChanged += NewUserCity_SelectedIndexChanged;

        }

        private void NewUserCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            int cityId = int.Parse(NewUserCity.SelectedValue);
            List<DISTRICT> listDistrict = DistrictController.GetListDistrictByCityId(cityId);
            NewUserDistrict.DataTextField = "Name";
            NewUserDistrict.DataValueField = "ID";
            NewUserDistrict.DataSource = listDistrict;
            NewUserDistrict.DataBind();
        }

        protected void NewUserPopupOk(object sender, EventArgs eventArgs)
        {
        }
    }
}