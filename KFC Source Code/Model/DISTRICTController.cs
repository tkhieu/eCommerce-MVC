using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class DistrictController
    {

        private static FoodStoreEntities _db;

        public static List<DISTRICT> GetListDistrictByCityId(int cityId)
        {
            _db = new FoodStoreEntities();
            return _db.CITies.Single(p => p.ID == cityId).DISTRICTs.ToList();
        }
    }
}
