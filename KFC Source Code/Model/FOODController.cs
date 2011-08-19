using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class FoodController
    {
        private static FoodStoreEntities _db;

        public static int GetMaxId()
        {
            int id;
            try
            {

                _db = new FoodStoreEntities();
                id = _db.FOODs.Max().ID + 1;
            }
            catch (Exception)
            {
                id = 1;
            }
            return id;
        }

        public static bool Insert(int id, String foodName, int foodPrice, int foodTypeId, String foodImage, String foodDetail)
        {
            bool flag = true;
            try
            {
                _db = new FoodStoreEntities();
                var food = new FOOD();
                var foodType = FoodTypeController.Get(foodTypeId,_db);

                food.ID = id;
                food.Name = foodName;
                food.Price = foodPrice;
                food.Detail = foodDetail;
                food.Image = foodImage;
                food.FOODTYPE = foodType;

                _db.AddToFOODs(food);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                flag = false;
                throw;
            }
            return flag;
        }
    }
}
