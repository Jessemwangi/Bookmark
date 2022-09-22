namespace Bookmark.Models
{
    public class bookmarkmodel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; } 
        public list<foldermodel> foldermodels { get; set; }
    }
}
//● Id: Unique identifier
//● Name: Name of the bookmark
//● URL: Link of the bookmark
//● Folder Id (optional): Id of the folder where the bookmark is kept
//● Created at: Timestamp when the bookmark is created
//● Updated at: Timestamp when the bookmark is updated