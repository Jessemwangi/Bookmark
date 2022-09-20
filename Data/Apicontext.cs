
using Bookmark.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookmark.Data
{
    public class Apicontext : DbContext
    {
        public DbSet<bookmarkmodel> Bookmarks { get; set; }
        public Apicontext(DbContextOptions<Apicontext> options)
            : base(options)
        {

        }
    }
}

