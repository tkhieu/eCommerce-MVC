using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.UI;
using Model;
using Utility;

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

                        //Đổ dữ liệu vào NewUserDistrict
                        int cityId = int.Parse(NewUserCity.SelectedValue);
                        List<DISTRICT> listDistrict = DistrictController.GetListDistrictByCityId(cityId);
                        NewUserDistrict.DataTextField = "Name";
                        NewUserDistrict.DataValueField = "ID";
                        NewUserDistrict.DataSource = listDistrict;
                        NewUserDistrict.DataBind();


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
            OfficePopupNewUser.Dispose();
            if (DataValidating())
            {
                String username = NewUserUserName.Text;
                String password = SaltEncrypt.HashCodeSHA1(NewUserPassword.Text);
                String fullName = NewUserFullName.Text;
                String address = NewUserAddress.Text;
                String tel = NewUserPhone.Text;
                String socialId = NewUserSocialId.Text;
                String email = NewUserEmail.Text;
                int question = int.Parse(NewUserQuestion.SelectedValue);
                String answer = NewUserAnswer.Text;
                int idCity = int.Parse(NewUserCity.SelectedValue);
                int idDistrict = int.Parse(NewUserDistrict.SelectedValue);
                if (!AccountController.Insert(username, password, fullName, address, tel, socialId, email, question, answer,
                                         idCity, idDistrict))
                    Response.Write(@"<script type='text/javascript'>alert('Không thực hiện chèn Account vào CSDL được.')</script>");
                else
                {
                    Utility.Mail.SendWelcome(email, fullName);
                    OfficePopupNewUser.Hide();
                }
                    
            }
        }

        private bool DataValidating()
        {
            ResetValidate();
            bool flag = true;

            if (NewUserUserName.Text.Length == 0)
            {
                LabelUserName.Text = @"Username must be have value";
                LabelUserName.Visible = true;
                flag = false;
            }
            if (NewUserPassword.Text != NewUserRetypePassword.Text && NewUserPassword.Text.Length > 0)
            {
                LabelRetypePassword.Text = @"Two password must be same";
                LabelRetypePassword.Visible = true;
                flag = false;
            }
            if (NewUserPassword.Text.Length < 6)
            {
                LabelPassword.Text = @"Password lenght must be greater than 6 character";
                LabelPassword.Visible = true;
                flag = false;
            }

            //Kiểm tra Email dùng Regular Expension
            String partent = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            var regex = new Regex(partent);
            if (!regex.IsMatch(NewUserEmail.Text) && NewUserEmail.Text.Length > 0)
            {
                LabelEmail.Text = @"Email must have a right form";
                LabelEmail.Visible = true;
                flag = false;
            }
            if (NewUserEmail.Text != NewUserRetypeEmail.Text)
            {
                LabelRetypeEmail.Text = @"Email must be same value";
                LabelRetypeEmail.Visible = true;
                flag = false;
            }
            if (NewUserAnswer.Text.Length == 0)
            {
                LabelAnswer.Text = @"Answer must be have value";
                LabelAnswer.Visible = true;
                flag = false;
            }
            if (NewUserFullName.Text.Length == 0)
            {
                LabelFullName.Text = @"Fullname must be have value";
                LabelFullName.Visible = true;
                flag = false;
            }
            if (NewUserSocialId.Text.Length == 0)
            {
                LabelSocialId.Text = @"Social ID must be have value";
                LabelSocialId.Visible = true;
                flag = false;
            }
            if (NewUserPhone.Text.Length == 0)
            {
                LabelPhone.Text = @"Phone number must be have value";
                LabelPhone.Visible = true;
                flag = false;
            }
            if (NewUserAddress.Text.Length == 0)
            {
                LabelAddress.Text = @"Address must be have value";
                LabelAddress.Visible = true;
                flag = false;
            }
            return flag;
        }

        private void ResetValidate()
        {
            LabelUserName.Visible = false;
            LabelPassword.Visible = false;
            LabelRetypePassword.Visible = false;
            LabelEmail.Visible = false;
            LabelRetypeEmail.Visible = false;
            LabelFullName.Visible = false;
            LabelSocialId.Visible = false;
            LabelAnswer.Visible = false;
            LabelAddress.Visible = false;
        }
    }
}