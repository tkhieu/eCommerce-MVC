using System;
using System.Collections.Generic;
using System.Linq;
using eCommerce.Utility;
using eCommerce.Utility.Encryption;

namespace eCommerce.Model.Controller
{
    public class ManagerController
    {
        private static FoodStoreEntities _db;

        public static bool Insert(String encrypted, String name)
        {
            //Khởi tạo một đối tượng ACCOUNT
            bool flag = true;
            _db = new FoodStoreEntities();
            try
            {
                var manager = new MANAGER();
                manager.ID = GetMaxId();
                manager.Name = name;
                manager.Encrypted = encrypted;
                _db.MANAGERs.AddObject(manager);

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
                id = _db.MANAGERs.Max(p => p.ID) + 1;
            }
            catch (Exception)
            {
                id = 1;
            }
            return id;
        }

        public static bool IsExistEmail(String email)
        {
            bool flag = false;
            _db = new FoodStoreEntities();
            List<MANAGER> list = _db.MANAGERs.ToList();
            foreach (MANAGER manager in list)
            {
                String encrypted = manager.Encrypted;
                String decrypted = StringEncrypt.DecryptString(encrypted, Configuration.ENCRYPT_PASSWORD);
                string[] arr = decrypted.Split('*');
                if (email == arr[0])
                {
                    flag = true;
                    return flag;
                }
            }
            return flag;
        }

        public static String GetNameByEmail(String email)
        {
            _db = new FoodStoreEntities();
            List<MANAGER> list = _db.MANAGERs.ToList();
            foreach (MANAGER manager in list)
            {
                String encrypted = manager.Encrypted;
                String decrypted = StringEncrypt.DecryptString(encrypted, Configuration.ENCRYPT_PASSWORD);
                string[] arr = decrypted.Split('*');
                if (email == arr[0])
                {
                    return manager.Name;
                }
            }
            return null;
        }

        public static int GetRoleByEmail(String email)
        {
            int role = 0;
            _db = new FoodStoreEntities();
            List<MANAGER> list = _db.MANAGERs.ToList();
            foreach (MANAGER manager in list)
            {
                String encrypted = manager.Encrypted;
                String decrypted = StringEncrypt.DecryptString(encrypted, Configuration.ENCRYPT_PASSWORD);
                string[] arr = decrypted.Split('*');
                if (email == arr[0])
                {
                    return int.Parse(arr[2]);
                }
            }
            return role;
        }

        public static bool IsLoginOk(String email, String password)
        {
            bool flag = false;
            _db = new FoodStoreEntities();
            List<MANAGER> list = _db.MANAGERs.ToList();
            foreach (MANAGER manager in list)
            {
                String encrypted = manager.Encrypted;
                String decrypted = StringEncrypt.DecryptString(encrypted, Configuration.ENCRYPT_PASSWORD);
                string[] arr = decrypted.Split('*');
                if (email == arr[0] && password == arr[1])
                {
                    flag = true;
                    return flag;
                }
            }
            return flag;
        }

        public static List<FManager> GetListFManage()
        {
            _db = new FoodStoreEntities();
            List<MANAGER> list = _db.MANAGERs.ToList();
            List<FManager> listFManage = new List<FManager>();
            foreach (MANAGER manager in list)
            {
                String encrypted = manager.Encrypted;
                String decrypted = StringEncrypt.DecryptString(encrypted, Configuration.ENCRYPT_PASSWORD);
                string[] arr = decrypted.Split('*');
                FManager fManager = new FManager();
                fManager.ID = manager.ID;
                fManager.Name = manager.Name;
                fManager.Email = arr[0];
                fManager.Enumrole = int.Parse(arr[2]);
                fManager.Role = ProjectEnum.PrintRole(fManager.Enumrole);
                listFManage.Add(fManager);
            }
            return listFManage;
        }
    }

    public class FManager
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public String Role { get; set; }
        public int Enumrole { get; set; }

        public FManager()
        {
            
        }
    }
}
