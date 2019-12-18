using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class CategoryDao
    {
        OnlineShopContext db = null;
        public CategoryDao(OnlineShopContext context)
        {
            this.db = context;
        }
        public bool AddCategory(Category category)
        {
            try
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Category UpdateCategory(int id, string name)
        {
            Category category = GetCategoryByIdCat(id);
            category.name = name;
            db.SaveChanges();
            return category;
        }

        public bool DeleteCategory(int id)
        {
            try
            {
                var category = db.Categories.SingleOrDefault(x => x.id_category == id);
                db.Categories.Remove(category);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public String GetNameById(int id)
        {
            return db.Categories.Where(x => x.id_category == id).SingleOrDefault().name;
        }

        public int GetIdByName(string name)
        {
            return db.Categories.Where(x => x.name == name).SingleOrDefault().id_category;
        }

        public Category GetCategoryByIdCat(int id)
        {
            return db.Categories.SingleOrDefault(x => x.id_category == id);
        }

        public IEnumerable<Category> GetAll()
        {
            return db.Categories.ToList<Category>();
        }
        public IEnumerable<Category> GetAllCategory(int page, int pageSize)
        {
            return db.Categories
                .OrderByDescending(x => x.id_category)
                .ToPagedList(page, pageSize);
        }

        public List<int> GetIdForMenClothes()
        {
            List<int> listId = new List<int>();
            var listProduct = db.Categories.Where(x => x.name.Contains("nam") == true).ToList<Category>();
            foreach (var item in listProduct)
            {
                listId.Add(item.id_category);
            }
            return listId;
        }

        public List<int> GetIdForWomenClothes()
        {
            List<int> listId = new List<int>();
            var listProduct = db.Categories.Where(x => x.name.Contains("nữ") == true).ToList();
            foreach (var item in listProduct)
            {
                listId.Add(item.id_category);
            }
            return listId;
        }
    }
}
