using Bookmark.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookmark.Data
{
    public class Bookmarkcontext : DbContext
    {
      
        public Bookmarkcontext(DbContextOptions<Bookmarkcontext> options)
            : base(options)
        {

        }
          public DbSet<bookmarkmodel> Bookmarks { get; set; }
          public DbSet<foldermodel>foldermodels {get; set;}
        public DbSet<BookmarkCategories> BookmarkCategories { get; set; }
    }
}
