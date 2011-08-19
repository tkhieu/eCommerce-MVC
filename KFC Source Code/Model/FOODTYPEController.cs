using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class FoodTypeController
    {
        private static FoodStoreEntities _db;

        public static List<FOODTYPE> GetList()
        {
            _db = new FoodStoreEntities();
            return _db.FOODTYPEs.ToList();
        }
    }
}
