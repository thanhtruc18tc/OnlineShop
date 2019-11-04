using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class SizeDao
    {
        OnlineShopContext db = null;
        public SizeDao(OnlineShopContext db)
        {
            this.db = db;
        }

        public List<Size> GetSizeList(int idProd)
        {
            var listIdSize = db.SizeDetails.Where(x => x.id_product == idProd && x.quantity > 0).Select(item => item.id_size).ToList();
            return db.Sizes.Where(x => listIdSize.Contains(x.id_size)).ToList();
        }

        public string GetNameById(int id)
        {
            return db.Sizes.Where(x => x.id_size == id).Select(x => x.name).SingleOrDefault();
        }

        public int GetQuantity(int idProd, int idSize)
        {
            return db.SizeDetails.Where(x => x.id_product == idProd && x.id_size == idSize).Select(x => x.quantity).SingleOrDefault();
        }
    }
}
