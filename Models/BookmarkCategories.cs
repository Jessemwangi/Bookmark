namespace Bookmark.Models
{
    public class BookmarkCategories
    {
        public int BookmarkCategoriesId { get; set; }  
        public string? CategoryName { get; set; }
        public int Agelimit { get; set; }

        public string? Description { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedTime { get; set; }
        public ICollection<Bookmarkmodel>? Bookmarks { get; set; }

    }
}
