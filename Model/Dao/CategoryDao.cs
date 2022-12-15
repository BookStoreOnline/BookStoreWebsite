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
        private BookStoreDbContext db = null;

        public CategoryDao()
        {
            db = new BookStoreDbContext();
        }

        public int Insert(Category entity)
        {
            entity.CreatedDate = DateTime.Now;
            db.Category.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(Category entity)
        {
            try
            {
                var category = db.Category.Find(entity.ID);
                category.Name = entity.Name;
                category.ParentID = entity.ParentID;
                category.ModifiedBy = entity.ModifiedBy;
                category.ModifiedDate = DateTime.Now;
                category.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Category ViewDetail(int id)
        {
            return db.Category.Find(id);
        }

        public List<Category> ListAll()
        {
            return db.Category.Where(x => x.Status == true).ToList();
        }

        public IEnumerable<Category> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Category> model = db.Category;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderBy(x => x.Name).ToPagedList(page, pageSize);
        }

        public Category GetById(int id)
        {
            return db.Category.SingleOrDefault(x => x.ID == id);
        }

        public bool Delete(int id)
        {
            try
            {
                var category = db.Category.Find(id);
                db.Category.Remove(category);
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