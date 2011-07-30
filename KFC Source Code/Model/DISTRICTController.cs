using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class DistrictController
    {
        public static FoodStoreEntities _db;

        public static List<DISTRICT> GetListByCityId(int cityId)
        {
            _db = new FoodStoreEntities();
            return _db.DISTRICTs.Where(p => p.IDCity == cityId).ToList();
        }
    }
}
