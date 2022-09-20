using Bookmark.Models;
using Microsoft.EntityFrameworkCore;
namespace Bookmark.Data
{
    public class folderContext : DbContext
    {
        public DbSet<foldermodel> Foldermodels { get; set; }
        public folderContext(DbContextOptions<folderContext> options)
            : base(options)
        {

        }
    }
}
