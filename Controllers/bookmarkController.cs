using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Bookmark.Data;
using Bookmark.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookmark.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {

        private readonly Bookmarkcontext _bookmarkContext;

        public  BookmarkController(Bookmarkcontext context)
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
        public async Task<JsonResult> Create(AddBookmark _bookmarkmodel)
        {
            var bookmarkindb = await _bookmarkContext.Bookmarks.FindAsync(_bookmarkmodel.Id);
            if (bookmarkindb == null)
            {
                var Bookmark = new Bookmarkmodel();
                Bookmark.Id = _bookmarkmodel.Id;
                Bookmark.CategoryId = _bookmarkmodel.CategoryId;
                Bookmark.FolderId = _bookmarkmodel.FolderId;
                Bookmark.CreatedAt  = DateTime.Now;
                Bookmark.UpdatedAt = DateTime.Now;
               await _bookmarkContext.Bookmarks.AddAsync(Bookmark);
                //await _bookmarkContext.Bookmarks.AddAsync(_bookmarkmodel);

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

        public async Task<JsonResult> Updateboomark([FromRoute] int ID, UpdateBookmark updateBookmark) 
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
                result.UpdatedAt=DateTime.Now;
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


public static class BookmarkmodelEndpoints
{
	public static void MapBookmarkmodelEndpoints (this IEndpointRouteBuilder routes)
    {
            routes.MapGet("/api/Bookmarkmodel", (Bookmarkcontext db) =>
            {
                // this works the post is the issue
                
                return db.Bookmarks.ToList(); 
            });


            routes.MapGet("/api/Bookmarkmodel/{id}", (Bookmarkcontext db, int id) =>
            {
                var bookmark = db.Bookmarks.FirstOrDefault(x => x.Id == id);

                return Results.Ok(bookmark);
            //return new Bookmarkmodel { ID = id };
            });
       

        routes.MapPut("/api/Bookmarkmodel/{id}", (int id, Bookmarkmodel input) =>
        {
            return Results.NoContent();
        })
        .WithName("UpdateBookmarkmodel")
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/Bookmarkmodel/", (Bookmarkmodel model) =>
        {
            //return Results.Created($"/Bookmarkmodels/{model.ID}", model);
        })
        .WithName("CreateBookmarkmodel")
        .Produces<Bookmarkmodel>(StatusCodes.Status201Created);

        routes.MapDelete("/api/Bookmarkmodel/{id}", (int id) =>
        {
            //return Results.Ok(new Bookmarkmodel { ID = id });
        })
        .WithName("DeleteBookmarkmodel")
        .Produces<Bookmarkmodel>(StatusCodes.Status200OK);
    }
}}