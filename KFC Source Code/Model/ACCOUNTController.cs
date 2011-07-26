using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class AccountController
    {
        private static FoodStoreEntities _db;

        public static bool Insert(ACCOUNT account)
        {
            bool flag = true;
            try
            {
                _db = new FoodStoreEntities();
                _db.ACCOUNTs.AddObject(account);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                flag = false;    
                throw;
            }
            return flag;
        }
    }
}
