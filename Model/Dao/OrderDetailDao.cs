﻿using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrderDetailDao
    {
        OnlineShopContext db = null;

        public OrderDetailDao(OnlineShopContext context)
        {
            db = context;
        }

        public IEnumerable<OrderDetail> GetAllByIdOrd(int id)
        {
            return db.OrderDetails.Where(x => x.id_order == id).ToList<OrderDetail>();
        }

        public bool AddOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                db.OrderDetails.Add(orderDetail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}