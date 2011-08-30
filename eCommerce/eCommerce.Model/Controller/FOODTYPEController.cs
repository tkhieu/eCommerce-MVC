using System;
using System.Collections.Generic;
using System.Linq;
using eCommerce.Utility;

namespace eCommerce.Model.Controller
{
    public class FoodTypeController
    {
        private static FoodStoreEntities _db;
        public static int GetMaxId()
        {
            int id;
            try
            {

                _db = new FoodStoreEntities();
                id = _db.FOODTYPEs.Max(p => p.ID) + 1;
            }
            catch (Exception)
            {
                id = 1;
            }
            return id;
        }
        public static List<FOODTYPE> GetList()
        {
            _db = new FoodStoreEntities();
            return _db.FOODTYPEs.ToList();
        }

        public static FOODTYPE Get(int id)
        {
            _db = new FoodStoreEntities();
            return _db.FOODTYPEs.Single(p => p.ID == id);
        }

        public static FOODTYPE Get(int id,FoodStoreEntities db)
        {
            return db.FOODTYPEs.Single(p => p.ID == id);
        }
        public static FOODTYPE GetById(int id)
        {
            _db = new FoodStoreEntities();
            return _db.FOODTYPEs.Single(p => p.ID == id);
        }
        public static bool Insert(int id,string foodTypeName)
        {
            bool flag = true;
            try
            {
                _db = new FoodStoreEntities();
                var foodType = new FOODTYPE();

                foodType.ID = id;
                foodType.Name = foodTypeName;
                foodType.Alias = StringOperation.GetAlias(id, foodTypeName);

                _db.AddToFOODTYPEs(foodType);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                flag = false;
                throw;
            }
            return flag;
        }
        public static bool Update(int id, string foodTypeName)
        {
            bool flag = true;
            _db = new FoodStoreEntities();
            try
            {
                var foodType = _db.FOODTYPEs.Single(p => p.ID == id);

                foodType.Name = foodTypeName;
                foodType.Alias = StringOperation.GetAlias(id, foodTypeName);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                flag = false;
                throw;
            }
            return flag;
        }
        public static bool Delete(int id)
        {
            _db = new FoodStoreEntities();
            bool flag = true;
            try
            {
                var foodType = _db.FOODTYPEs.Single(p => p.ID == id);
                _db.FOODTYPEs.DeleteObject(foodType);
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
