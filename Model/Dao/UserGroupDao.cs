using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class UserGroupDao
    {
        private BookStoreDbContext db = null;

        public UserGroupDao()
        {
            db = new BookStoreDbContext();
        }

        public List<UserGroup> ListAll()
        {
            return db.UserGroup.ToList();
        }
    }
}