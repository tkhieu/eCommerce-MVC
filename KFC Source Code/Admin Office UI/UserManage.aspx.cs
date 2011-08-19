using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using OfficeWebUI;
using Utility;

//Using by Kimhieuqtvn

namespace ContosoWebApp
{
    public partial class UserManage : Page
    {

        //
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //Load
            List<ACCOUNT> list = AccountController.GetList();

            var listAccount = from account in list
                              select new
                              {
                                  ID = account.ID,
                                  Username = account.Username,
                                  Name = account.Name,
                                  Address = account.Address,
                                  City = account.CITY.Name,
                                  District = account.DISTRICT.Name,
                                  Tel = account.Tel,
                                  SocialID = account.SocialID,
                                  Email = account.Email
                              };
            GridViewListUser.DataSource = listAccount;
            GridViewListUser.DataBind();

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

                if (Session["edit"] != null)
                {
                    int idAccount = int.Parse(Session["id"].ToString());
                    if (!AccountController.Update(idAccount, fullName, address, tel, socialId, idCity, idDistrict))
                    {
                        OfficeMessageBoxUpdateAccountFail.Show();
                        OfficePopupNewUser.Hide();
                        Session["edit"] = null;
                    }
                    else
                    {
                        
                        OfficeMessageBoxUpdateAccountSuccess.Show();
                        OfficePopupNewUser.Hide();
                        Session["edit"] = null;
                    }
                }
                else
                {
                    if (!AccountController.Insert(username, password, fullName, address, tel, socialId, email, question, answer,
                                         idCity, idDistrict))
                    {
                        OfficeMessageBoxAddAccountFail.Show();
                        OfficePopupNewUser.Hide();
                    }
                    else
                    {
                        OfficeMessageBoxAddAccountSuccess.Show();
                        Utility.Mail.SendWelcome(email, fullName);
                        OfficePopupNewUser.Hide();
                    }                    
                }
                    
            }else
            {
                OfficePopupNewUser.Height = 600;
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

        

        protected void GridViewListUser_RowEditing(object sender, System.Web.UI.WebControls.GridViewEditEventArgs e)
        {
            Session["id"] = GridViewListUser.Rows[e.NewEditIndex].Cells[1].Text;
            Session["edit"] = 1;
            OfficeMessageBoxConfirmEdit.Show();
            e.Cancel = true;
        }

        protected void GridViewListUser_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {
            Session["id"] = e.Values["ID"].ToString();
            OfficeMessageBoxConfirmDelete.Show();
        }

        protected void DeleteAccountYes(object sender, EventArgs e)
        {
            if (OfficeMessageBoxConfirmDelete.ReturnValue == MessageBoxReturnType.Yes)
            {
                int id = int.Parse(Session["id"].ToString());
                AccountController.Delete(id);    
            }
        }

        protected void EditAccountYes(object sender, EventArgs e)
        {
            if (OfficeMessageBoxConfirmEdit.ReturnValue == MessageBoxReturnType.Yes)
            {
                int id = int.Parse(Session["id"].ToString());
                var account = AccountController.Get(id);

                //Cấm Edit thông tin đăng nhập
                NewUserUserName.Enabled = false;
                NewUserPassword.Enabled = false;
                NewUserRetypePassword.Enabled = false;
                NewUserEmail.Enabled = false;
                NewUserRetypeEmail.Enabled = false;

                //Cấm Edit thông tin bảo mật
                NewUserQuestion.Enabled = false;
                NewUserAnswer.Enabled = false;

                //Load thông tin lên các Control
                NewUserUserName.Text = account.Username;
                NewUserPassword.TextMode = TextBoxMode.SingleLine;
                NewUserRetypePassword.TextMode = TextBoxMode.SingleLine;
                NewUserPassword.Text = @"-------------------";
                NewUserRetypePassword.Text = @"-------------------";
                NewUserEmail.Text = account.Email;
                NewUserRetypeEmail.Text = account.Email;


                var listItem = new ListItem {Text = account.QUESTION.Question, Value = account.QUESTION.ID.ToString()};
                NewUserQuestion.Items.Add(listItem);
                NewUserQuestion.SelectedIndex = 0;
                NewUserAnswer.Text = @"-------------------";

                NewUserFullName.Text = account.Name;
                NewUserSocialId.Text = account.SocialID;
                NewUserPhone.Text = account.Tel;
                NewUserAddress.Text = account.Address;
                NewUserWard.Text = @"Tạm thời không có";


                List<CITY> listCity = CityController.GetList();
                NewUserCity.DataTextField = "Name";
                NewUserCity.DataValueField = "ID";
                NewUserCity.DataSource = listCity;
                NewUserCity.DataBind();
                NewUserCity.SelectedValue = account.IDCity.ToString();

                //Đổ dữ liệu vào NewUserDistrict
                int cityId = int.Parse(NewUserCity.SelectedValue);
                List<DISTRICT> listDistrict = DistrictController.GetListDistrictByCityId(cityId);
                NewUserDistrict.DataTextField = "Name";
                NewUserDistrict.DataValueField = "ID";
                NewUserDistrict.DataSource = listDistrict;
                NewUserDistrict.DataBind();
                NewUserDistrict.SelectedValue = account.IDDistrict.ToString();
                OfficePopupNewUser.Show();
            }
        }
    }
}