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
                user.status = !user.status;
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
            return db.Users.Where(x => x.admin == true).ToList<User>();
        }

        public List<User> getAllCustomer()
        {
            return db.Users.Where(x => x.admin == false).ToList<User>();
        }
        #endregion
    }
}
