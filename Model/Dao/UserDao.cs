using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class UserDao
    {
        private BookStoreDbContext db = null;

        public UserDao()
        {
            db = new BookStoreDbContext();
        }

        public int Insert(User entity)
        {
            db.User.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(User entity)
        {
            try
            {
                var user = db.User.Find(entity.ID);
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public User ViewDetail(int id)
        {
            return db.User.Find(id);
        }

        public IEnumerable<User> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = db.User;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public User GetById(string userName)
        {
            return db.User.SingleOrDefault(x => x.UserName == userName);
        }

        public int Login(string userName, string passWord)
        {
            var result = db.User.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == passWord)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }

        public bool ChangeStatus(int id)
        {
            var user = db.User.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }

        public bool Delete(int id)
        {
            try
            {
                var user = db.User.Find(id);
                db.User.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}