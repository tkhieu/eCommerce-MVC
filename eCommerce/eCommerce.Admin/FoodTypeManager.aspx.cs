using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using FtpLib;
using eCommerce.Model;
using OfficeWebUI;
using eCommerce.Model.Controller;

namespace eCommerce.Admin
{
    public partial class FoodTypeManager : System.Web.UI.Page
    {
        FoodStoreEntities db = new FoodStoreEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            var list = FoodTypeController.GetList();
            var listFoodType = from foodType in list
                           select new
                           {
                               ID = foodType.ID,
                               Name = foodType.Name,
                               Count = db.FOODs.Count(p=>p.FoodTypeId == foodType.ID)
                           };

            GridViewListFoodType.DataSource = listFoodType;
            GridViewListFoodType.DataBind();
            if (!IsPostBack)
            {
                if (Request.QueryString.Count == 1)
                {
                    if (Request.QueryString["New"] == "1")
                    {
                        OfficePopupNewFoodType.Show();
                    }
                }
            }
        }


        protected void NewFoodTypePopupOk(object sender, EventArgs e)
        {
            if (DataValidate())
            {



                int foodTypeId = FoodTypeController.GetMaxId();

                String foodTypeName = NewFoodTypeName.Text;

                if (Session["edit"] != null)
                {

                    foodTypeId = int.Parse(Session["id"].ToString());

                    if (!FoodTypeController.Update(foodTypeId, foodTypeName))
                    {
                        OfficeMessageBoxUpdateFoodTypeFail.Show();
                        OfficePopupNewFoodType.Hide();
                    }
                    else
                    {
                        OfficeMessageBoxUpdateFoodTypeSuccess.Show();
                        OfficePopupNewFoodType.Hide();
                    }


                    Session["edit"] = null;
                }
                else
                {
                    if (!FoodTypeController.Insert(foodTypeId, foodTypeName))
                    {
                        OfficeMessageBoxAddFoodTypeFail.Show();
                        OfficePopupNewFoodType.Hide();
                    }
                    else
                    {
                        OfficeMessageBoxAddFoodTypeSuccess.Show();
                        OfficePopupNewFoodType.Hide();
                    }
                }
            }
        }

        private bool DataValidate()
        {
            bool flag = true;
            if (NewFoodTypeName.Text.Length == 0)
                flag = false;
            return flag;
        }

        protected void OnOfficeMessageBoxFoodTypeFailYes(object sender, EventArgs e)
        {
            OfficePopupNewFoodType.Show();
        }

        protected void GridViewListFood_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Session["id"] = GridViewListFoodType.Rows[e.NewEditIndex].Cells[1].Text;
            OfficeMessageBoxConfirmEdit.Show();
            e.Cancel = true;
        }

        protected void GridViewListFood_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Session["id"] = e.Values["ID"];
            OfficeMessageBoxConfirmDelete.Show();

        }

        protected void DeleteFoodTypeYes(object sender, EventArgs e)
        {
            if (OfficeMessageBoxConfirmDelete.ReturnValue == MessageBoxReturnType.Yes)
            {
                int id = int.Parse(Session["id"].ToString());
                if (FoodTypeController.Delete(id))
                {
                    Response.Redirect("~/FoodTypeManager.aspx");
                }
            }
        }

        protected void EditFoodTypeYes(object sender, EventArgs e)
        {
            int id = int.Parse(Session["id"].ToString());
            Session["edit"] = 1;
            var foodType = FoodTypeController.GetById(id);
            NewFoodTypeName.Text = foodType.Name;
            OfficePopupNewFoodType.Show();
        }
    }
}