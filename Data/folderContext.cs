using Bookmark.Models;
using Microsoft.EntityFrameworkCore;
namespace Bookmark.Data
{
    public class FolderContext : DbContext
    {
        public DbSet<Foldermodel> Foldermodels { get; set; }
        public FolderContext(DbContextOptions<FolderContext> options)
            : base(options)
        {

        }
    }
}
