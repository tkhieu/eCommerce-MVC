using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class CityController
    {
        private static FoodStoreEntities _db;

        /**
         * Xuất danh sách CITY
         */

        public static List<CITY> GetList()
        {
            _db = new FoodStoreEntities();
            return _db.CITies.ToList();
        }

        //Lấy câu hỏi by Id
        public static CITY GetById(int id)
        {
            _db = new FoodStoreEntities();
            return _db.CITies.Single(p => p.ID == id);

        }

        public static CITY GetById(int id,FoodStoreEntities db)
        {
            return db.CITies.Single(p => p.ID == id);
        }
    }
}
