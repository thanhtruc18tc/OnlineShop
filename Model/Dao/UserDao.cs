using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class UserDao

    {
        OnlineShopContext db = null;

        public object Encryptor { get; private set; }

        public UserDao(OnlineShopContext context)
        {
            db = context;
        }

        public void test()
        {

            if (db.Categories.Count() == 0)
            {
                db.Categories.Add(new Category { name = "Áo sơ mi nam" });
                db.Categories.Add(new Category { name = "Áo thun nam" });
                db.Categories.Add(new Category { name = "Áo khoác nam" });
                db.Categories.Add(new Category { name = "Quần dài nam" });
                db.Categories.Add(new Category { name = "Quần short nam" });
                db.Categories.Add(new Category { name = "Áo kiểu nữ" });
                db.Categories.Add(new Category { name = "Áo sơ mi nữ" });
                db.Categories.Add(new Category { name = "Áo thun nữ" });
                db.Categories.Add(new Category { name = "Áo khoác nữ" });
                db.Categories.Add(new Category { name = "Váy nữ" });
                db.Categories.Add(new Category { name = "Quần dài nữ" });
                db.SaveChanges();
            }

            if (db.Sizes.Count() == 0)
            {
                db.Sizes.Add(new Size { name = "S"});
                db.Sizes.Add(new Size { name = "M" });
                db.Sizes.Add(new Size { name = "L" });
                db.Sizes.Add(new Size { name = "XL" });
                db.Sizes.Add(new Size { name = "XXL" });
                db.Sizes.Add(new Size { name = "24" });
                db.Sizes.Add(new Size { name = "25" });
                db.Sizes.Add(new Size { name = "26" });
                db.Sizes.Add(new Size { name = "27" });
                db.Sizes.Add(new Size { name = "28" });
                db.Sizes.Add(new Size { name = "29" });
                db.Sizes.Add(new Size { name = "30" });
                db.Sizes.Add(new Size { name = "31" });
                db.Sizes.Add(new Size { name = "32" });
                db.Sizes.Add(new Size { name = "33" });
                db.Sizes.Add(new Size { name = "34" });
                db.Sizes.Add(new Size { name = "35" });
                db.Sizes.Add(new Size { name = "36" });
                db.Sizes.Add(new Size { name = "37" });
                db.Sizes.Add(new Size { name = "38" });
                db.Sizes.Add(new Size { name = "39" });
                db.Sizes.Add(new Size { name = "40" });
                db.Sizes.Add(new Size { name = "41" });
                db.Sizes.Add(new Size { name = "42" });
                db.SaveChanges();
            }

            if (db.Colors.Count() == 0)
            {
                db.Colors.Add(new Color { name = "Trắng" });
                db.Colors.Add(new Color { name = "Đen" });
                db.Colors.Add(new Color { name = "Vàng" });
                db.SaveChanges();
            }

            if (db.Products.Count() == 0)
            {
                db.Products.Add(new Product { name = "Áo sơ mi cổ trụ 1", id_category = 1, description = "Áo đẹp lắm", price = 250000, promotionPrice = null, dateCreate = DateTime.Now  });
                db.Products.Add(new Product { name = "Áo sơ mi cổ trụ 2", id_category = 1, description = "Áo đẹp lắm", price = 250000, promotionPrice = null, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Áo sơ mi cổ trụ 3", id_category = 1, description = "Áo đẹp lắm", price = 250000, promotionPrice = null, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Áo sơ mi cổ trụ 4", id_category = 1, description = "Áo đẹp lắm", price = 250000, promotionPrice = null, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Áo sơ mi cổ trụ 5", id_category = 1, description = "Áo đẹp lắm", price = 250000, promotionPrice = null, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Áo sơ mi cổ trụ 6", id_category = 1, description = "Áo đẹp lắm", price = 250000, promotionPrice = null, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Áo sơ mi cổ trụ 7", id_category = 1, description = "Áo đẹp lắm", price = 250000, promotionPrice = null, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Áo sơ mi cổ trụ 8", id_category = 1, description = "Áo đẹp lắm", price = 250000, promotionPrice = null, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Áo sơ mi cổ trụ 9", id_category = 1, description = "Áo đẹp lắm", price = 250000, promotionPrice = null, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Áo sơ mi cổ trụ 10", id_category = 1, description = "Áo đẹp lắm", price = 250000, promotionPrice = null, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Áo sơ mi cổ trụ 11", id_category = 1, description = "Áo đẹp lắm", price = 250000, promotionPrice = null, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Áo sơ mi cổ trụ 12", id_category = 1, description = "Áo đẹp lắm", price = 250000, promotionPrice = null, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Áo sơ mi cổ trụ 13", id_category = 1, description = "Áo đẹp lắm", price = 250000, promotionPrice = null, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Áo sơ mi cổ trụ 14", id_category = 1, description = "Áo đẹp lắm", price = 250000, promotionPrice = null, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Áo sơ mi cổ trụ 15", id_category = 1, description = "Áo đẹp lắm", price = 250000, promotionPrice = null, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Áo sơ mi cổ trụ 16", id_category = 1, description = "Áo đẹp lắm", price = 250000, promotionPrice = null, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Áo sơ mi cổ trụ 17", id_category = 1, description = "Áo đẹp lắm", price = 250000, promotionPrice = null, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Áo sơ mi cổ trụ 18", id_category = 1, description = "Áo đẹp lắm", price = 250000, promotionPrice = null, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Áo sơ mi cổ trụ 19", id_category = 1, description = "Áo đẹp lắm", price = 250000, promotionPrice = null, dateCreate = DateTime.Now });
                db.Products.Add(new Product { name = "Áo sơ mi cổ trụ 20", id_category = 1, description = "Áo đẹp lắm", price = 250000, promotionPrice = null, dateCreate = DateTime.Now });
                db.SaveChanges();
            }
        }


        public User GetByEmail(string email)
        {
            return db.Users.SingleOrDefault(x => x.email == email);
        }

        public User GetByUsernameAndPassword(string username, String password)
        {
            return db.Users.SingleOrDefault(x => x.username == username && x.password == password);
        }

        public User GetById(int id)
        {
            return db.Users.SingleOrDefault(x => x.id_user == id);
        }

        public User GetByUserName(string username)
        {
            return db.Users.SingleOrDefault(x => x.username == username);
        }

        public bool IsEmailExisted(string email)
        {
            return db.Users.Count(x => x.email == email) != 0;
        }

        // MARK: Register
        public void Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
        }

        // MARK: Lock account
        public bool ChangeStatus(int id)
        {
            var user = GetById(id);
            if (user != null)
            {
                user.isActive = !user.isActive;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        // MARK: Forgot password
        public bool ChangePassword(string email, string newpass)
        {
            var user = GetByEmail(email);
            if (user != null) {
                user.password = newpass;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        // MARK: Update profile
        public User Update(string id, string name, string username, string email, string address, string phone)
        {
            var user = GetById(Convert.ToInt32(id));

            user.name = name;
            user.username = username;
            user.email = email;
            user.address = address;
            user.phone = phone;
            db.SaveChanges();
            return user;

        }

        // MARK: Change password
        public void ChangePassword(int id, string newPass)
        {
            var user = GetById(id);
            user.password = newPass;
            db.SaveChanges();
        }

        // MARK: Login
        public int Login(string username, string password)
        {
            var result = db.Users.Count(x => x.username == username);
            if (result > 0)
            {
                result = db.Users.Count(x => x.username == username && x.password == password);
                if (result > 0)
                {
                    return 1; // Success
                }
                else
                {
                    return 0; // Fail
                }
            } else
            {
                return -1; // Not exist
            }  
        }

        #region Admin
        public List<User> getAll() {
            return db.Users.ToList<User>();
        }

        public List<User> getAllAdmin()
        {
            return db.Users.Where(x => x.isAdmin == true).ToList<User>();
        }

        public List<User> getAllCustomer()
        {
            return db.Users.Where(x => x.isAdmin == false).ToList<User>();
        }
        #endregion
    }
}
