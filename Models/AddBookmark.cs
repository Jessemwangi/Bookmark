namespace Bookmark.Models
{
    public class AddBookmark
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? URL { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int? CategoryId { get; set; }

     public int? FolderId { get; set; }

    }

}
