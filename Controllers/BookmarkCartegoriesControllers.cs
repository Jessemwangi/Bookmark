using Bookmark.Data;
using Bookmark.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;


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
        public JsonResult Get()
        {
            var result = _bookmarkcontext.BookmarkCategories.ToList();
            if (result.Any())
            {
                return new JsonResult(Ok(result));
            }
            return new JsonResult(Ok("no data was returned"));
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
            bookmarks.CreatedDate = DateTime.UtcNow;
           
            _bookmarkcontext.BookmarkCategories.Add(bookmarks);
            _bookmarkcontext.SaveChanges();
            return new JsonResult(Ok(bookmarks));

        }

        // PUT api/<BookmarkCartegories>/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] AddBookmarkCategory addBookmarkCategory)
        {
            
             var result = _bookmarkcontext.BookmarkCategories.FirstOrDefault(x => x.BookmarkCategoriesId == id);
            if (result == null)
            {
                return new JsonResult(NotFound("the id is not in our system"));
            }
            else
            {
                result.description = addBookmarkCategory.description;
                result.UpdatedTime = DateTime.UtcNow;
                result.Agelimit = addBookmarkCategory.Agelimit;
                result.CategoryName = addBookmarkCategory.CategoryName;
                _bookmarkcontext.Update(result);
                _bookmarkcontext.SaveChanges(true);e
            }
        }

        // DELETE api/<BookmarkCartegories>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
