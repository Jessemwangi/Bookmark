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
          public DbSet<Bookmarkmodel> Bookmarks { get; set; }
          public DbSet<Foldermodel>Foldermodels {get; set;}
        public DbSet<BookmarkCategories> BookmarkCategories { get; set; }
    }
}
