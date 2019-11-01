using Model.EF;
using PagedList;
using System.Collections.Generic;
using System.Linq;

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
            if (name == "Tất cả quần áo nam")
            {
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
            return db.Products.SingleOrDefault(x => x.id_product == id);
        }

        public IEnumerable<Product> Search(string keywords)
        {
            keywords = Helper.StringHelper.RemoveVietnameseTone(keywords);
            List<Product> products = new List<Product>();

            foreach (var p in db.Products.ToList<Product>())
            {
                p.name = Helper.StringHelper.RemoveVietnameseTone(p.name);
                if (p.name.Contains(keywords.ToLower()))
                {
                    products.Add(p);
                }
            }
            //return db.Products
            //    .Where(x => x.name.Contains(keywords.ToLower()))
            return products
                .OrderByDescending(x => x.id_product)
                .ToPagedList<Product>(1, 10);
        }
    }
}
