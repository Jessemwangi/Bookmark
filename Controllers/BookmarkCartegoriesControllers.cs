using Bookmark.Data;
using Bookmark.Models;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Bookmark.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkCartegoriesControllers : ControllerBase
    {
        private readonly Bookmarkcontext _bookmarkcontext;

        public BookmarkCartegoriesControllers(Bookmarkcontext _context)
        {
            _bookmarkcontext = _context;
        }
        // GET: api/<BookmarkCartegories>
        [HttpGet]
        public string[] Get()
        {
            return  new string[] { "value1", "value2" };
        }

        // GET api/<BookmarkCartegories>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = _bookmarkcontext.BookmarkCategories.FirstOrDefault(x => x.BookmarkCategoriesId == id);
            if (result == null)
            {
                return NotFound("the id is not in our system");
            }
            return Ok(result);

        }

        // POST api/<BookmarkCartegories>
        [HttpPost]
        public JsonResult AddBookmarkCat(AddBookmarkCategory addBookmarkCategory)
        {
            var bookmarks = new BookmarkCategories();
            //bookmarks.CategoryId = addBookmarkCategory.CategoryId;
            bookmarks.CategoryName = addBookmarkCategory.CategoryName;
            bookmarks.Agelimit = addBookmarkCategory.Agelimit;
            bookmarks.description = addBookmarkCategory.description;
            bookmarks.CategoryName = addBookmarkCategory.CategoryName;
            _bookmarkcontext.BookmarkCategories.Add(bookmarks);
            _bookmarkcontext.SaveChanges();
            return new JsonResult(Ok(bookmarks));

        }

        // PUT api/<BookmarkCartegories>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BookmarkCartegories>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
