using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Model;
using Utility;

namespace ContosoWebApp
{
    public partial class FoodManage : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
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


        protected void NewFoodPopupOk(object sender, EventArgs e)
        {
            if (DataValidate())
            {
                String foodName = NewFoodName.Text;
                int foodPrice = int.Parse(NewFoodPrice.Text);
                int foodType = int.Parse(NewFoodType.SelectedValue);

                if (NewFoodImage.PostedFile != null)
                {
                    var postImage = NewFoodImage.PostedFile;
                    int imageFileLenght = postImage.ContentLength;
                    string imageExtension = Path.GetExtension(postImage.FileName);

                    if (imageFileLenght > 0 && (imageExtension == ".png" || imageExtension == ".jpg" || imageExtension == ".gif"))
                    {
                        byte[] myData = new byte[imageFileLenght];

                        // Read uploaded file from the Stream
                        postImage.InputStream.Read(myData, 0, imageFileLenght);

                        // Create a name for the file to store
                        string strFilename = Path.GetFileName(postImage.FileName);

                        // Write data into a file
                        FileOperation.WriteToFile(Server.MapPath("~/Upload/" + strFilename), ref myData);
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
    }
}