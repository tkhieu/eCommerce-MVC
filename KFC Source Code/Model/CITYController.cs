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

    }
}
