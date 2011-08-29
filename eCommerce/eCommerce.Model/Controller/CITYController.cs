using System.Collections.Generic;
using System.Linq;

namespace eCommerce.Model.Controller
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

        public static List<CITY> GetList(string city)
        {
            _db = new FoodStoreEntities();
            return _db.CITies.ToList().Where(p => p.Name.ToLower().StartsWith(city.ToLower())).ToList();
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
