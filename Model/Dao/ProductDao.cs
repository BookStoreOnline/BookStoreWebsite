using Model.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class ProductDao
    {
        private BookStoreDbContext db = null;

        public ProductDao()
        {
            db = new BookStoreDbContext();
        }

        public List<Product> ListNewProduct(int top)
        {
            return db.Product.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }

        public List<Product> ListRelatedProduct(int productId)
        {
            var product = db.Product.Find(productId);
            return db.Product.Where(x => x.ID != productId && x.CategoryID == product.CategoryID).ToList();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<Product> ListByCategoryId(int categoryId, ref int totalRecord, int page, int pageSize)
        {
            totalRecord = db.Product.Where(x => x.CategoryID == categoryId).Count();
            var model = db.Product.Where(x => x.CategoryID == categoryId).OrderBy(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return model;
        }

        public Product ViewDetail(int id)
        {
            return db.Product.Find(id);
        }

        public int Insert(Product entity)
        {
            entity.CreatedDate = DateTime.Now;
            db.Product.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(Product entity)
        {
            try
            {
                var product = db.Product.Find(entity.ID);
                product.Name = entity.Name;

                product.Description = entity.Description;
                product.Image = entity.Image;
                product.Quantity = entity.Quantity;
                product.CategoryID = entity.CategoryID;
                product.Price = entity.Price;
                product.PromotionPrice = entity.PromotionPrice;
                product.ModifiedDate = DateTime.Now;
                product.Weight = entity.Weight;
                product.Width = entity.Width;
                product.Depth = entity.Depth;
                product.Height = entity.Height;
                product.QuantityOfPage = entity.QuantityOfPage;
                product.BookLayout = entity.BookLayout;
                product.Publisher = entity.Publisher;
                product.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Product> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<Product> model = db.Product;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            return model.OrderBy(x => x.Name).ToPagedList(page, pageSize);
        }

        public Product GetById(int id)
        {
            return db.Product.SingleOrDefault(x => x.ID == id);
        }

        public bool Delete(int id)
        {
            try
            {
                var product = db.Product.Find(id);
                db.Product.Remove(product);
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