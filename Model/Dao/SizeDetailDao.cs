using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class SizeDetailDao
    {
        OnlineShopContext db = null;

        public SizeDetailDao(OnlineShopContext context)
        {
            db = context;
        }

        public bool Insert(int idPro, int idSize, int quantity)
        {
            try
            {
                db.SizeDetails.Add(new SizeDetail { id_size = idSize, id_product = idPro, quantity = quantity });
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Update(int idPro, int idSize, int quantity)
        {
            try
            {
                var sizeDetail = db.SizeDetails.SingleOrDefault(x => x.id_product == idPro && x.id_size == idSize);
                if (quantity > 0)
                {
                    sizeDetail.quantity = quantity;
                    db.SaveChanges();
                }
                else
                {
                    DeleteSizeDetail(idPro, idSize);
                }
            }
            catch
            {
                Insert(idPro, idSize, quantity);
            }
            
        }

        public bool DeleteSizeDetail(int idPro, int idSize)
        {
            try
            {
                SizeDetail sizeDetail = db.SizeDetails.SingleOrDefault(x => x.id_product == idPro && x.id_size == idSize);
                db.SizeDetails.Remove(sizeDetail); 
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public SizeDetail GetSizeByIdProduct(int id)
        {
            return db.SizeDetails.SingleOrDefault(x => x.id_product == id);
        }

        public int GetQuanlity(int id)
        {
            int s = 0;
            var list = GetAllSizeDetailById(id);
            foreach(var item in list)
            {
                s += item.quantity;
            }
            return s;
        }
        public List<SizeDetail> GetAllSizeDetailById(int id)
        {
            return db.SizeDetails.Where(x => x.id_product == id).ToList();
        }
    }
}
