using System;
using System.Linq;

namespace eCommerce.Model.Controller
{
    public class OrderDetailController
    {
        private static FoodStoreEntities _db;

        public static int GetMaxId()
        {
            int id;
            try
            {

                _db = new FoodStoreEntities();
                id = _db.ORDERDETAILs.Max(p => p.ID) + 1;
            }
            catch (Exception)
            {
                id = 1;
            }
            return id;
        }
    }
}
