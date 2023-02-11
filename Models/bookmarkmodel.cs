namespace Bookmark.Models
{
    public class Bookmarkmodel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? URL { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; } 
        public int? CategoryId { get; set; }
        public int? FolderId { get; set; }
        public BookmarkCategories? BookmarKCategories { get; set; }
        public List<Foldermodel>? Foldermodels { get; set; }  //folder can have a list or collection of bookmarks
    }
}
//● Id: Unique identifier
//● Name: Name of the bookmark
//● URL: Link of the bookmark
//● Folder Id (optional): Id of the folder where the bookmark is kept
//● Created at: Timestamp when the bookmark is created
//● Updated at: Timestamp when the bookmark is updated