using Model.EF;
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

        public List<OrderDetail> GetAllByIdOrd(int id)
        {
            return db.OrderDetails.Where(x => x.id_order == id).ToList();
        }
    }
}