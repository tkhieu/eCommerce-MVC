using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eCommerce.Model
{
    public class DistrictController
    {

        private static FoodStoreEntities _db;

        public static List<DISTRICT> GetListDistrictByCityId(int cityId)
        {
            _db = new FoodStoreEntities();
            return _db.CITies.Single(p => p.ID == cityId).DISTRICTs.ToList();
        }

        //Lấy câu hỏi by Id
        public static DISTRICT GetById(int id)
        {
            _db = new FoodStoreEntities();
            return _db.DISTRICTs.Single(p => p.ID == id);

        }
        public static DISTRICT GetById(int id,FoodStoreEntities db)
        {
            return db.DISTRICTs.Single(p => p.ID == id);
        }
    }
}
