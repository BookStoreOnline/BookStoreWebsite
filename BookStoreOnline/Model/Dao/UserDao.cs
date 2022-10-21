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
        BookStoreOnlineDbContext db = null;
        public UserDao()
        {
            db = new BookStoreOnlineDbContext();
        }
        public int Insert (Users user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user.Id;
        }
        public bool Login(string userName, string password)
        {
            var result = db.Users.Count(x => x.UserName == userName && x.Password == password);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
