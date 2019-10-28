using Model.EF;
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

        public int GetIdByName(string name)
        {
            return db.Categories.Where(x => x.name == name).SingleOrDefault().id_category;
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
