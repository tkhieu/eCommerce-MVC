using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class CityController
    {
        public static FoodStoreEntities _db;

        public static List<CITY> GetList()
        {
            _db = new FoodStoreEntities();
            return _db.CITies.ToList();
        }
    }
}
