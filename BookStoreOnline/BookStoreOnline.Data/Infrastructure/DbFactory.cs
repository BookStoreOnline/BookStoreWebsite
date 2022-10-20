namespace BookStoreOnline.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private BookStoreOnlineDbContext dbContext;

        public BookStoreOnlineDbContext Init()
        {
            return dbContext ?? (dbContext = new BookStoreOnlineDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }
    }
}