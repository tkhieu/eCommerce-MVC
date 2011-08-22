using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using FtpLib;
using eCommerce.Model;
using Utility;
using OfficeWebUI;
using eCommerce.Model.Controller;

namespace eCommerce.Admin
{
    public partial class FoodManage : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            var list = FoodController.GetList();
            var listFood = from food in list
                           select new
                                      {
                                          ID = food.ID,
                                          Name = food.Name,
                                          FoodType = food.FOODTYPE.Name,
                                          Price = food.Price,
                                          Image = food.Image
                                      };

            GridViewListFood.DataSource = listFood;
            GridViewListFood.DataBind();

            if (!IsPostBack)
            {
                if (Request.QueryString.Count == 1)
                {
                    if (Request.QueryString["New"] == "1")
                    {
                        var listFoodType = FoodTypeController.GetList();

                        NewFoodType.DataSource = listFoodType;
                        NewFoodType.DataValueField = "ID";
                        NewFoodType.DataTextField = "Name";
                        NewFoodType.DataBind();
                        OfficePopupNewFood.Show();
                    }
                }    
            }
        }


        protected void NewFoodPopupOk(object sender, EventArgs e)
        {
            if (DataValidate())
            {
                

                bool checkFtpNotError = true;

                int foodId = FoodController.GetMaxId();
                String imageFileName = "";
                
                if (NewFoodImage.PostedFile != null)
                {
                    var postImage = NewFoodImage.PostedFile;
                    int imageFileLenght = postImage.ContentLength;
                    string imageExtension = Path.GetExtension(postImage.FileName);

                    imageFileName = foodId + imageExtension;

                    if (imageFileLenght > 0 && (imageExtension == ".png" || imageExtension == ".jpg" || imageExtension == ".gif"))
                    {
                        byte[] myData = new byte[imageFileLenght];

                        // Read uploaded file from the Stream
                        postImage.InputStream.Read(myData, 0, imageFileLenght);

                        // Create a name for the file to store
                        string strFilename = Path.GetFileName(postImage.FileName);

                        String absServerFileName = Server.MapPath("~/Upload/" + strFilename);
                        // Write data into a file
                        if (FileOperation.WriteToFile(absServerFileName, ref myData))
                        {
                            using (var ftpConnection = new FtpConnection("localhost",21,"imageupload","123456789"))
                            {
                                ftpConnection.Open();
                                ftpConnection.Login();
                                ftpConnection.SetCurrentDirectory("/");
                                try
                                {
                                    ftpConnection.PutFile(absServerFileName, imageFileName);
                                }
                                catch (Exception)
                                {
                                    //Báo lỗi
                                    checkFtpNotError = false;
                                    throw;
                                }
                                finally
                                {
                                    ftpConnection.Close();    
                                }
                                
                            }
                        }
                        
                    }
                }

                String foodName = NewFoodName.Text;
                int foodPrice = int.Parse(NewFoodPrice.Text);
                int foodType = int.Parse(NewFoodType.SelectedValue);
                String imageOnCdn = imageFileName;
                String foodDetail = CKEditorNewFood.Text;

                if (Session["edit"] != null)
                {

                    foodId = int.Parse(Session["id"].ToString());
                    
                    if (NewFoodImage.PostedFile == null)
                    {
                        imageOnCdn = null;
                    }

                    if (!FoodController.Update(foodId, foodName, foodPrice, foodType, imageOnCdn, foodDetail))
                    {
                        OfficeMessageBoxUpdateFoodFail.Show();
                        OfficePopupNewFood.Hide();
                    }
                    else
                    {
                        OfficeMessageBoxUpdateFoodSuccess.Show();
                        OfficePopupNewFood.Hide();
                    }


                    Session["edit"] = null;
                }
                else
                {
                    if (checkFtpNotError)
                    {
                        

                        if (!FoodController.Insert(foodId, foodName, foodPrice, foodType, imageOnCdn, foodDetail))
                        {
                            OfficeMessageBoxAddFoodFail.Show();
                            OfficePopupNewFood.Hide();
                        }
                        else
                        {
                            OfficeMessageBoxAddFoodSuccess.Show();
                            OfficePopupNewFood.Hide();
                        }
                    }
                }
            }
        }

        private bool DataValidate()
        {
            bool flag = true;
            if (NewFoodName.Text.Length == 0)
                flag = false;
            if(NewFoodPrice.Text.Length == 0)
                flag = false;
            foreach (char c in NewFoodPrice.Text)
            {
                if (!Char.IsDigit(c))
                    flag = false;
            }

            if (NewFoodImage.PostedFile == null)
            {
                flag = false;
            }
            return flag;
        }

        protected void OnOfficeMessageBoxFoodFailYes(object sender, EventArgs e)
        {
            OfficePopupNewFood.Show();
        }

        protected void GridViewListFood_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Session["id"] = GridViewListFood.Rows[e.NewEditIndex].Cells[1].Text;
            OfficeMessageBoxConfirmEdit.Show();
            e.Cancel = true;
        }

        protected void GridViewListFood_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["id"] = e.Values["ID"];
            OfficeMessageBoxConfirmDelete.Show();

        }

        protected void DeleteFoodYes(object sender, EventArgs e)
        {
            if (OfficeMessageBoxConfirmDelete.ReturnValue == MessageBoxReturnType.Yes)
            {
                int id = int.Parse(Session["id"].ToString());
                if (FoodController.Delete(id))
                {
                    Response.Redirect("~/FoodManage.aspx");
                }
                
            }
        }

        protected void EditFoodYes(object sender, EventArgs e)
        {
            int id = int.Parse(Session["id"].ToString());
            Session["edit"] = 1;
            var food = FoodController.GetById(id);

            var listFoodType = FoodTypeController.GetList();

            NewFoodType.DataSource = listFoodType;
            NewFoodType.DataValueField = "ID";
            NewFoodType.DataTextField = "Name";
            NewFoodType.DataBind();

            NewFoodName.Text = food.Name;
            NewFoodPrice.Text = food.Price.ToString();
            NewFoodType.SelectedValue = food.FOODTYPE.ID.ToString();
            CKEditorNewFood.Text = food.Detail;

            OfficePopupNewFood.Show();
        }
    }
}