namespace Bookmark.Models
{
    public class BookmarkCategories
    {
        public int BookmarkCategoriesId { get; set; }  
        public string? CategoryName { get; set; }
        public int Agelimit { get; set; }

        public string? description { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedTime { get; set; }
        public ICollection<bookmarkmodel>? Bookmarks { get; set; }

    }
}
