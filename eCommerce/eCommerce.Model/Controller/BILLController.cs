﻿using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;

namespace eCommerce.Model.Controller
{
    public class BillController
    {
        private static FoodStoreEntities _db;

        public static BILL GetByOrderId(int id)
        {
            _db = new FoodStoreEntities();
            return _db.BILLs.Single(p => p.ORDER.ID == id);
        }

        public static bool UpdateBill(int orderId, int state, int paymethod)
        {
            _db = new FoodStoreEntities();
            bool flag = true;
            bool checkBill = true;
            ORDER order = OrderController.GetById(orderId, _db);
            if (order.BILLs.Count == 0)
            {
                checkBill = false;
            }

            if (checkBill)
            {
                BILL bill = _db.BILLs.Single(p => p.ORDER.ID == orderId);
                if (state != (int)ProjectEnum.OrderState.Finish)
                {
                    _db.BILLs.DeleteObject(bill);
                }
                else
                {
                    bill.PaymentMethor = paymethod;
                }
            }
            else
            {
                if (state == (int)ProjectEnum.OrderState.Finish)
                {
                    BILL bill = new BILL();
                    bill.ID = GetMaxId();
                    bill.IDOrder = orderId;
                    bill.Date = DateTime.Now;
                    bill.TotalPayment = order.TotalPayment;
                    bill.PaymentMethor = paymethod;
                    _db.BILLs.AddObject(bill);
                }
            }
            try
            {
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
                id = _db.BILLs.Max(p => p.ID) + 1;
            }
            catch (Exception)
            {
                id = 1;
            }
            return id;
        }

        public static List<BILL> GetList()
        {
            _db = new FoodStoreEntities();
            return _db.BILLs.ToList();
        }

        public static BILL GetById(int id)
        {
            _db = new FoodStoreEntities();
            return _db.BILLs.Single(p => p.ID == id);
        }
        public static int GetPayment(int year,int month)
        {
            _db = new FoodStoreEntities();
            var result =
                _db.BILLs.Where(
                    p => p.Date != null && (p.Date.Value.Month == month && p.Date.Value.Year == year)).Sum(p => p.TotalPayment);
            if (result != null) return (int)result;
            else
            {
                return 0;
            }
        }
        public static void GetMaxMinYear(ref int minYear,ref int maxYear)
        {
            _db = new FoodStoreEntities();
            var min = _db.BILLs.Min(p => p.Date);
            var max = _db.BILLs.Max(p => p.Date);
            if (min != null) minYear = min.Value.Year;
            if (max != null) maxYear = max.Value.Year;
        }
    }
}
