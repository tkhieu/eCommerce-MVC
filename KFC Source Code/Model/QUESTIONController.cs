using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class QuestionController
    {
        private static FoodStoreEntities _db;

        //Lấy list câu hỏi
        public static List<QUESTION> GetList()
        {
            _db = new FoodStoreEntities();
            return _db.QUESTIONs.ToList();
        }

        //Lấy câu hỏi by Id
        public static QUESTION GetById(int id)
        {
            _db = new FoodStoreEntities();
            return _db.QUESTIONs.Single(p => p.ID == id);
        }

        public static QUESTION GetById(int id,FoodStoreEntities db)
        {
            return db.QUESTIONs.Single(p => p.ID == id);
        }
    }
}
