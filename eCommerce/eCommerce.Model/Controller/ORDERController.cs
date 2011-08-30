using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eCommerce.Utility;

namespace eCommerce.Model.Controller
{
    public class OrderController
    {
        private static FoodStoreEntities _db;

        public static bool Insert(int userId, String fullName, String address, String tel, DateTime orrdertime,
                                  String note, int state, int totalpayent, int idCity, int idDistrict, List<int> foods,
                                  List<int> count)
        {
            //Khởi tạo một đối tượng ACCOUNT


            bool flag = true;

            _db = new FoodStoreEntities();

            int id = GetMaxId();
            ORDER currentorder = null;
            var orderdetails = new List<ORDERDETAIL>();
            ACCOUNT account = AccountController.GetById(userId, _db);
            CITY city = CityController.GetById(idCity, _db);
            DISTRICT district = DistrictController.GetById(idDistrict, _db);
            try
            {
                var order = new ORDER
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
                    FOOD food = FoodController.GetById(fId, _db);
                    currentorder = GetById(id, _db);
                    var orderdetail = new ORDERDETAIL
                                          {
                                              ID = OrderDetailController.GetMaxId(),
                                              ORDER = currentorder,
                                              FOOD = food,
                                              Count = count[i],
                                              TotalPayment = count[i]*food.Price,
                                              Price = food.Price
                                          };
                    orderdetails.Add(orderdetail);
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
            if (flag)
            {
                StringBuilder body = new StringBuilder()
                    .AppendLine("A new order has been submitted")
                    .AppendLine("---")
                    .AppendLine("Items:");

                foreach (ORDERDETAIL i in orderdetails)
                {
                    int? subtotal = i.Price*i.Count;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c})", i.Count,
                                      i.FOOD.Name,
                                      subtotal).AppendLine();
                }

                body.AppendLine()
                    .AppendFormat("Total order value: {0:c}", ((int)currentorder.TotalPayment).ToString("c"))
                    .AppendLine("---")
                    .AppendLine("Ship to:")
                    .AppendLine(currentorder.Name)
                    .AppendLine(currentorder.Note)
                    .AppendLine(currentorder.Tel)
                    .AppendLine(currentorder.Address)
                    .AppendLine(currentorder.DISTRICT.Name)
                    .AppendLine(currentorder.CITY.Name)
                    .AppendLine("---");

                Mail.SendOrderDetail(currentorder.Note, currentorder.Name, body);
            }
            
            return flag;
        }

        public static List<ORDER> GetList()
        {
            _db = new FoodStoreEntities();
            return _db.ORDERs.ToList();
        }

        public static int GetMaxId()
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

        public static ORDER GetById(int id, FoodStoreEntities db)
        {
            return db.ORDERs.Single(p => p.ID == id);
        }

        public static bool UpdateState(int id, int state)
        {
            bool flag = true;
            _db = new FoodStoreEntities();
            try
            {
                ORDER order = GetById(id, _db);
                order.State = state;
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
