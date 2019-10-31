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
        string name = "";
        public ProductDao(OnlineShopContext context)
        {
            db = context;
        }
        
        public int GetCount()
        {
            return db.Products.Count();
        }

        public IEnumerable<Product> GetProduct(string name, int page, int pageSize)
        {
            var dao = new CategoryDao(db);
            if (name == "Đang giảm giá")
            {
                return db.Products.Where(item => item.promotionPrice != null)
                .OrderByDescending(x => x.id_product)
                .ToPagedList<Product>(1, 15);
            }
            else if (name == "Hàng mới") {
                var listIdForMen = dao.GetIdForMenClothes();
                var listIdForWomen = dao.GetIdForWomenClothes();
                List<int> listId = new List<int>();
                foreach (var item in listIdForMen)
                {
                    listId.Add(item);
                }
                foreach (var item in listIdForWomen)
                {
                    listId.Add(item);
                }
                return db.Products.Where(item => listId.Contains(item.id_category))
                .OrderByDescending(x => x.dateCreate)
                .ToPagedList<Product>(1, 20);
            }
            else if (name == "Quần áo nam mới về")
            {
                var listId = dao.GetIdForMenClothes();
                return db.Products.Where(item => listId.Contains(item.id_category))
                .OrderByDescending(x => x.dateCreate)
                .ToPagedList<Product>(1, 15);
            }
            else if(name == "Quần áo nữ mới về")
            {
                var listId = dao.GetIdForWomenClothes();
                return db.Products.Where(item => listId.Contains(item.id_category))
                .OrderByDescending(x => x.dateCreate)
                .ToPagedList<Product>(1, 15);
            }
            else if (name == "Tất cả quần áo nam") {
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

        public IEnumerable<Product> GetRelativeProduct(string name, int ignoreId)
        {
            var dao = new CategoryDao(db);
            if (this.name.Contains("nam"))
            {
                var listId = dao.GetIdForMenClothes();
                listId.Remove(ignoreId);
                return db.Products.Where(item => listId.Contains(item.id_category))
               .OrderByDescending(x => x.name)
               .ToPagedList<Product>(1, 6);
            }
            else if (this.name.Contains("nữ"))
            {
                var listId = dao.GetIdForWomenClothes();
                listId.Remove(ignoreId);

                return db.Products.Where(item => listId.Contains(item.id_category))
               .OrderByDescending(x => x.name)
               .ToPagedList<Product>(1, 6);
            } else
            {
                var listForMen = dao.GetIdForMenClothes();
                var listForWomen = dao.GetIdForWomenClothes();
                List<int> listId = new List<int>();
                foreach(var item in listForMen)
                {
                    listId.Add(item);
                }
                foreach (var item in listForWomen)
                {
                    listId.Add(item);
                }
                listId.Remove(ignoreId);

                return db.Products.Where(item => listId.Contains(item.id_category))
               .OrderByDescending(x => x.dateCreate)
               .ToPagedList<Product>(1, 6);
            }
           
        }
    }
}
