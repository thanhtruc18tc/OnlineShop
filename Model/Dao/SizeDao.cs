using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class SizeDao
    {
        OnlineShopContext db = null;

        public SizeDao(OnlineShopContext context)
        {
            db = context;
        }

        public List<Size> GetListSize()
        {
            return db.Sizes.ToList<Size>();
        }
    }
}
