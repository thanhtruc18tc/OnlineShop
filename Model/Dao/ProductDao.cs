using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PagedList;

namespace Model.Dao
{
    public class ProductDao
    {
        OnlineShopContext db = null;

        public ProductDao(OnlineShopContext context)
        {
            db = context;
        }
        
        public int GetCount()
        {
            return db.Products.Count();
        }

        public IEnumerable<Product> GetAll(string name, int page, int pageSize)
        {
            var dao = new CategoryDao(db);
            if (name == "Tất cả quần áo nam") {
                var listId = dao.GetIdForMenClothes();
                return db.Products.Where(item => listId.Contains(item.id_category))
                .OrderByDescending(x => x.id_product)
                .ToPagedList<Product>(page, pageSize);
            }
            else if (name == "Tất cả quần áo nữ")
            {
                var listId = dao.GetIdForWomenClothes();
                return db.Products.Where(item => listId.Contains(item.id_category))
                .OrderByDescending(x => x.id_product)
                .ToPagedList<Product>(page, pageSize);
            }
            else
            {
                int categoryId = dao.GetIdByName(name);
                return db.Products
                .Where(y => y.id_category == categoryId)
                .OrderByDescending(x => x.id_product)
                .ToPagedList<Product>(page, pageSize);
            }
        }

        public Product GetDetail(int id)
        {
            return db.Products.Where(x => x.id_product == id).SingleOrDefault<Product>();
        }
    }
}
