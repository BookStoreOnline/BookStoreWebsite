using System;

namespace BookStoreOnline.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        BookStoreOnlineDbContext Init();
    }
}