using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.Dao
{
    public class ImageDao
    {
        OnlineShopContext db = null;

        public ImageDao(OnlineShopContext context)
        {
            this.db = context;
        }

        public bool Insert(int idProduct, string link)
        {
            try
            {
                db.Images.Add(new Image { id_product = idProduct, link = link });
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Image GetByIdProduct(int idProd)
        {
            return db.Images.FirstOrDefault(x => x.id_product == idProd);
        }

        public List<string> GetAllImage(int idProd)
        {
            return db.Images.Where(x => x.id_product == idProd).Select(x => x.link).ToList();
        }
    }
}
