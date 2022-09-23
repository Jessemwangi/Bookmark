using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bookmark.Data;
using Bookmark.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookmark.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class bookmarkController : ControllerBase
    {

        private readonly Bookmarkcontext _bookmarkContext;

        public  bookmarkController(Bookmarkcontext context)
        {
            _bookmarkContext = context;
        }
        [HttpGet()]
        public async Task<JsonResult> getall()
        {
            return new JsonResult(Ok(await _bookmarkContext.Bookmarks.ToListAsync()));
        }


        [HttpGet]
        public async Task<JsonResult> Get(int Id)
        {
            var result = await _bookmarkContext.Bookmarks.FindAsync(Id);
            if (result == null)
                return new JsonResult(NotFound(result));
            return new JsonResult(Ok(result));
        }
        [HttpPost]
        public async Task<JsonResult> create(bookmarkmodel _bookmarkmodel)
        {
            var bookmarkindb = await _bookmarkContext.Bookmarks.FindAsync(_bookmarkmodel.Id);
            if (bookmarkindb == null)
            {
                await _bookmarkContext.Bookmarks.AddAsync(_bookmarkmodel);
            }
            else
            {
                    return new JsonResult(Conflict());
            }
            await _bookmarkContext.SaveChangesAsync();
            return new JsonResult(Ok(_bookmarkmodel));
        }

        [HttpPut]
        [Route("{ID:int}")]

        public async Task<JsonResult> updateboomark([FromRoute] int ID, UpdateBookmark updateBookmark) 
        {
            var result = await _bookmarkContext.Bookmarks.FirstOrDefaultAsync(X => X.Id == ID);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            else
            {
                result.Name=updateBookmark.Name;
                result.URL=updateBookmark.URL;
                result.updatedAt=DateTime.Now;
                await _bookmarkContext.SaveChangesAsync();
                return new JsonResult(Ok(updateBookmark));
            }
        }

        [HttpDelete]
        public async Task<JsonResult> Delete(int id)
        {
            var result = await _bookmarkContext.Bookmarks.FirstOrDefaultAsync(X => X.Id ==id);

            if (result == null)
                return new JsonResult(NotFound());

           _bookmarkContext.Bookmarks.Remove(result);
           await _bookmarkContext.SaveChangesAsync();

            return new JsonResult(NoContent());
        }
    }
}