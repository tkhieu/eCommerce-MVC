using System.Collections.Generic;
using System.Linq;

namespace eCommerce.Model.Controller
{
    public class DistrictController
    {

        private static FoodStoreEntities _db;

        public static List<DISTRICT> GetListDistrictByCityId(int cityId)
        {
            _db = new FoodStoreEntities();
            return _db.CITies.Single(p => p.ID == cityId).DISTRICTs.ToList();
        }

        public static List<DISTRICT> GetList(string district)
        {
            _db = new FoodStoreEntities();
            return _db.DISTRICTs.Where(p =>p.Name.ToLower().StartsWith(district.ToLower())).ToList();
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

        public static int GetIdByTerm(string district)
        {
            _db = new FoodStoreEntities();
            return _db.DISTRICTs.Where(p => p.Name == district).Select(p => p.ID).ToList()[0];
        }
    }
}
