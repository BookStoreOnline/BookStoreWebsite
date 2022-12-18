using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    public class OrderDetailDao
    {
        private BookStoreDbContext db = null;

        public OrderDetailDao()
        {
            db = new BookStoreDbContext();
        }

        public bool Insert(OrderDetail detail)
        {
            try
            {
                db.OrderDetail.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}