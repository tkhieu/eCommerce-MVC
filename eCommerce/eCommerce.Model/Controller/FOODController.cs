﻿using System;
using System.Collections.Generic;
using System.Linq;
using eCommerce.Utility;


namespace eCommerce.Model.Controller
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
                id = _db.FOODs.Max(p => p.ID)+1;
            }
            catch (Exception)
            {
                id = 1;
            }
            return id;
        }

        public static bool Insert(int id, String foodName, int foodPrice, int foodTypeId, String foodImage,
                                  String foodDetail)
        {
            bool flag = true;
            try
            {
                _db = new FoodStoreEntities();
                var food = new FOOD();
                var foodType = FoodTypeController.Get(foodTypeId, _db);

                food.ID = id;
                food.Name = foodName;
                food.Price = foodPrice;
                food.Detail = foodDetail;
                food.Image = foodImage;
                food.FOODTYPE = foodType;
                food.Alias = StringOperation.GetAlias(id, foodName);

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

        public static List<FOOD> GetList()
        {
            _db = new FoodStoreEntities();
            return _db.FOODs.ToList();
        }

        public static List<FOOD> GetList(string searchText)
        {
            _db = new FoodStoreEntities();
            return _db.FOODs.ToList().Where(p => p.Name.ToLower().StartsWith(searchText.ToLower())).ToList();
        }

        public static bool Delete(int id)
        {
            _db = new FoodStoreEntities();
            bool flag = true;
            try
            {
                var food = _db.FOODs.Single(p => p.ID == id);
                _db.FOODs.DeleteObject(food);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                flag = false;
                throw;
            }
            return flag;
        }

        public static FOOD GetById(int id)
        {
            _db = new FoodStoreEntities();
            return _db.FOODs.Single(p => p.ID == id);
        }

        public static FOOD GetById(int id,FoodStoreEntities db)
        {
            return db.FOODs.Single(p => p.ID == id);
        }

        public static bool Update(int id, String foodName, int foodPrice, int foodTypeId, String foodImage,
                                  String foodDetail)
        {
            bool flag = true;
            _db = new FoodStoreEntities();
            try
            {
                var food = _db.FOODs.Single(p => p.ID == id);
                var foodType = FoodTypeController.Get(foodTypeId, _db);

                food.Name = foodName;
                food.Price = foodPrice;
                food.FOODTYPE = foodType;
                food.Detail = foodDetail;
                if (foodImage != null)
                    food.Image = foodImage;
                food.Alias = StringOperation.GetAlias(id, foodName);

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