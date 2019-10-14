using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class MemberDao
    {
        OnlineShopContext db = null;

        public MemberDao(OnlineShopContext context)
        {
            db = context;
        }

        public List<Member> getAll() {
            return db.Members.ToList<Member>();
        }

    }
}
