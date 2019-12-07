using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrderDao
    {
        OnlineShopContext db = null;
        public OrderDao(OnlineShopContext context)
        {
            this.db = context;
        }
        public IEnumerable<Order> GetAllOrder(int page, int pageSize)
        {
            return db.Orders
                .OrderByDescending(x => x.id_order)
                .ToPagedList(page, pageSize);
        }

        public bool AddOrder(Order order)
        {
            try
            {
                db.Orders.Add(order);
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
