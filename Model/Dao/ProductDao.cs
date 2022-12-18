using Model.EF;
using Model.ViewModel;
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

        public List<string> ListName(string keyword)
        {
            return db.Product.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();
        }

        public List<ProductViewModel> Search(string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Product.Where(x => x.Name == keyword).Count();
            var model = (from a in db.Product
                         join b in db.Category
                         on a.CategoryID equals b.ID
                         where a.Name.Contains(keyword)
                         select new
                         {
                             CateName = b.Name,
                             CreatedDate = a.CreatedDate,
                             ID = a.ID,
                             Images = a.Image,
                             Name = a.Name,
                             Price = a.Price
                         }).AsEnumerable().Select(x => new ProductViewModel()
                         {
                             CateName = x.Name,
                             CreatedDate = x.CreatedDate,
                             ID = x.ID,
                             Images = x.Images,
                             Name = x.Name,
                             Price = x.Price
                         });
            model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return model.ToList();
        }
    }
}