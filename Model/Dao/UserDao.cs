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

        public UserDao(OnlineShopContext context)
        {
            db = context;
        }

        public object Encryptor { get; private set; }

        public User GetByUserName(string username)
        {
            return db.Users.SingleOrDefault(x => x.username == username);
        }

        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.id_user;
        }

        public bool IsEmailExisted(string email)
        {
            return db.Users.Count(x => x.email == email) != 0;
        }

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
    }
}
