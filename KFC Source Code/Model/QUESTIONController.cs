using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class QuestionController
    {
        private static FoodStoreEntities _db;

        public static List<QUESTION> GetList()
        {
            _db = new FoodStoreEntities();
            return _db.QUESTIONs.ToList();
        }
    }
}
