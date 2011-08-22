using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eCommerce.Model
{
    public class OrderController
    {
        private static FoodStoreEntities _db;

        public static bool Insert(int userId, String fullName, String address, String tel, DateTime orrdertime, String note, int state, int totalpayent, int idCity, int idDistrict, List<int> foods, List<int> count)
        {
            //Khởi tạo một đối tượng ACCOUNT

            
            bool flag = true;

            _db = new FoodStoreEntities();
                try
                {
                    int id = GetMaxId();
                    ACCOUNT account = AccountController.GetById(userId,_db);
                    CITY city = CityController.GetById(idCity,_db);
                    DISTRICT district = DistrictController.GetById(idDistrict,_db);
                    var order = new ORDER()
                    {
                        ID = id,
                        ACCOUNT = account,
                        Name = fullName,
                        Tel = tel,
                        Address = address,
                        Date = orrdertime,
                        Note = note,
                        State = state,
                        TotalPayment = totalpayent,
                        DISTRICT = district,
                        CITY = city
                    };

                    _db.ORDERs.AddObject(order);
                    _db.SaveChanges();

                    int n = foods.Count();
                    for (int i = 0; i < n; i++)
                    {
                        int fId = foods[i];
                        var food = FoodController.GetById(fId, _db);
                        ORDER currentorder = GetById(id, _db);
                        ORDERDETAIL orderdetail = new ORDERDETAIL
                                                      {
                                                          ID = OrderDetailController.GetMaxId(),
                                                          ORDER = currentorder,
                                                          FOOD = food,
                                                          Count = count[i],
                                                          TotalPayment = count[i]*food.Price,
                                                          Price = food.Price
                                                      };

                        _db.ORDERDETAILs.AddObject(orderdetail);
                        _db.SaveChanges();
                    }
                    
                    _db.AcceptAllChanges();
                }
                catch (Exception)
                {
                    flag = false;
                    throw;
                }   
        
            return flag;
        }

        private static int GetMaxId()
        {
            int id;
            try
            {

                _db = new FoodStoreEntities();
                id = _db.ORDERs.Max(p => p.ID) + 1;
            }
            catch (Exception)
            {
                id = 1;
            }
            return id;
        }

        public static ORDER GetById(int id)
        {
            _db = new FoodStoreEntities();
            return _db.ORDERs.Single(p => p.ID == id);
        }

        public static ORDER GetById(int id,FoodStoreEntities db)
        {
            return db.ORDERs.Single(p => p.ID == id);
        }
    }
}
