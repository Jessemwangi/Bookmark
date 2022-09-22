using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bookmark.Data;
using Bookmark.Models;
namespace Bookmark.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class bookmarkController : ControllerBase
    {
        //private readonly folderContext _folderContext;
        private readonly Bookmarkcontext _bookmarkContext;

        public bookmarkController(Bookmarkcontext context)
        {
            _bookmarkContext = context;
        }
        [HttpGet]
        public JsonResult Get(int Id)
        {
            var result = _bookmarkContext.Bookmarks.Find(Id);
            if (result == null)
                return new JsonResult(NotFound(result));
            return new JsonResult(Ok(result));
        }
        [HttpPost]
        public JsonResult create(bookmarkmodel _bookmarkmodel)
        {
            if (_bookmarkmodel.Id == 0)
            {
                _bookmarkContext.Bookmarks.Add(_bookmarkmodel);
            }
            else
            {
                var bookmarkindb = _bookmarkContext.Bookmarks.Find(_bookmarkmodel.Id);
                if (bookmarkindb == null)
                    return new JsonResult(NotFound());
                bookmarkindb = _bookmarkmodel;
            }
            _bookmarkContext.SaveChanges();
            return new JsonResult(Ok(_bookmarkmodel));
        }
    }
}