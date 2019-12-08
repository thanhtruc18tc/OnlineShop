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

        public bool DeleteSizeDetail(int id)
        {
            try
            {
                SizeDetail sizeDetail = db.SizeDetails.SingleOrDefault(x => x.id_product == id);
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

        public bool updateQuantity(int idProduct,int idSize , int quantity)
        {
            try
            {
                var item = db.SizeDetails.Where(x => x.id_product == idProduct && x.id_size == idSize).First();
                item.quantity = item.quantity - quantity;
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
