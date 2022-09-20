using Bookmark.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookmark.Data
{
    public class Bookmarkcontext : DbContext
    {
        public DbSet<bookmarkmodel> Bookmarks { get; set; }
        public Bookmarkcontext(DbContextOptions<Bookmarkcontext> options)
            : base(options)
        {

        }
    }
}
