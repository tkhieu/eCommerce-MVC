using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model{

    public class AccountController
    {
        private static FoodStoreEntities _db;

        public static bool Insert(String username, String password,String fullName, String address, String tel, String socialId, String email, int question, String answer, int idCity, int idDistrict)
        {
            //Khởi tạo một đối tượng ACCOUNT

            _db = new FoodStoreEntities();

            var account = new ACCOUNT();
            account.ID = GetMaxId();
            account.Username = username;
            account.Password = password;
            account.Name = fullName;
            account.Address = address;
            account.Tel = tel;
            account.SocialID = socialId;
            account.Email = email;
            account.QUESTION = QuestionController.GetById(question,_db);
            account.Answer = answer;
            account.CITY = CityController.GetById(idCity,_db);
            account.DISTRICT = DistrictController.GetById(idDistrict,_db);

            //Chèn đối tượng ACCOUNT vào CSDL
            bool flag = true;
            try
            {
                
                _db.AddToACCOUNTs(account);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                flag = false;
                throw;
            }
            return flag;
        }

        public static int GetMaxId()
        {
            int id;
            try
            {
                _db = new FoodStoreEntities();
                id = _db.ACCOUNTs.Max(p => p.ID);
            }
            catch (Exception)
            {
                id = 1;    
            }
            return id;
        }

        public static List<ACCOUNT> GetList()
        {
            _db = new FoodStoreEntities();

            return _db.ACCOUNTs.ToList();
        }

        public static bool Delete(int id)
        {
            bool flag = true;
            try
            {
                _db = new FoodStoreEntities();
                var account = _db.ACCOUNTs.Single(p => p.ID == id);
                _db.ACCOUNTs.DeleteObject(account);
                _db.SaveChanges();
            }
            catch (Exception)
            {
                flag = false;
                throw;
            }
            return flag;
        }

        public static ACCOUNT Get(int id)
        {
            _db = new FoodStoreEntities();
            return _db.ACCOUNTs.Single(p => p.ID == id);
        }
    }
}