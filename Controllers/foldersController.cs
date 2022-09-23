using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Bookmark.Data;
using Bookmark.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookmark.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class foldersController : ControllerBase
    {
        private readonly Bookmarkcontext _bookmarkcontext;

        public foldersController(Bookmarkcontext bookmarkcontext)
        {
            this._bookmarkcontext = bookmarkcontext;
        }
        [HttpGet()]
        public async Task<JsonResult> GetAll()
        {
            var result = await _bookmarkcontext.foldermodels.ToListAsync();

            return new JsonResult(Ok(result));
        }
        [HttpGet]
        public async Task<JsonResult> Get(int ID)
        {
            var folderrecord = await _bookmarkcontext.foldermodels.FirstOrDefaultAsync(x => x.Id == ID);
            if (folderrecord == null)
            {
                return new JsonResult(NotFound(folderrecord));
            }
            else
            {
                return new JsonResult(Ok(folderrecord));
            }


        }
        [HttpPost]
        public async Task<JsonResult> Create(foldermodel foldermodel)
        {
            var folderRec = await _bookmarkcontext.foldermodels.FirstOrDefaultAsync(x => x.Id == foldermodel.Id);
             if (folderRec == null)
            {
                await _bookmarkcontext.foldermodels.AddAsync(foldermodel);
                          }
            else
            {
                    return new JsonResult(Conflict());
            }
            await _bookmarkcontext.SaveChangesAsync();
            return new JsonResult(Ok(foldermodel));
        }

        [HttpPut]
        [Route("{ID:int}")]
        public async Task<JsonResult> updateFolder([FromRoute] int ID, addUpdateFolder updateFolder)
        {
            var foldertoupdate= await _bookmarkcontext.foldermodels.FirstOrDefaultAsync(x => x.Id == ID);
            if (foldertoupdate == null)
            {
                return new JsonResult(NoContent());
            }
            else
            {
                foldertoupdate.Name= updateFolder.Name;
                foldertoupdate.Description= updateFolder.Description;
                foldertoupdate.UpdatedDate=DateTime.Now;
            await _bookmarkcontext.SaveChangesAsync();
                return new JsonResult(Ok(updateFolder));
            }

        }

        [HttpDelete]
        public JsonResult Delete(int ID)
        {
            var FolderToDelete = _bookmarkcontext.foldermodels.FirstOrDefault(x => x.Id == ID);
            if (FolderToDelete == null)
            { return new JsonResult(NotFound()); }
            else
            {
                _bookmarkcontext.foldermodels.Remove(FolderToDelete);
                _bookmarkcontext.SaveChanges();
                return new JsonResult(NoContent());
            }
        }
    }
}
