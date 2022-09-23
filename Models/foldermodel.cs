namespace Bookmark.Models
{
    public class foldermodel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }


    }
}

//● Id: Unique identifier
//● Name: Name of the folder
//● Description (optional): Some description
//● Created at: Timestamp when the bookmark is created
//● Updated at: Timestamp when the bookmark is updated