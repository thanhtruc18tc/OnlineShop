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
        OnlineShopDbContext db = null;

        public UserDao()
        {
            db = new OnlineShopDbContext();
        }

        public object Encryptor { get; private set; }

        public User GetByUserName(string username)
        {
            return db.Users.SingleOrDefault(x => x.Username == username);
        }

        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool IsEmailExisted(string email)
        {
            return db.Users.Count(x => x.Email == email) != 0;
        }

        public int Login(string username, string password)
        {
            var result = db.Users.Count(x => x.Username == username);
            if (result > 0)
            {
                result = db.Users.Count(x => x.Username == username && x.Password == password);
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
    }
}
