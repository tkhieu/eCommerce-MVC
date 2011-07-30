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
            var account = new ACCOUNT();
            account.ID = GetMaxId();
            account.Username = username;
            account.Password = password;
            account.Name = fullName;
            account.Address = address;
            account.Tel = tel;
            account.SocialID = socialId;
            account.Email = email;
            account.Question = question;
            account.Answer = answer;
            account.IDCity = idCity;
            account.IDDistrict = idDistrict;

            //Chèn đối tượng ACCOUNT vào CSDL
            bool flag = true;
            try
            {
                _db = new FoodStoreEntities();
                _db.AddToACCOUNTs(account);
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
    }
}