using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Bookmark.Data;
using Bookmark.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookmark.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class FoldersController : ControllerBase
    {
        private readonly Bookmarkcontext _bookmarkcontext;

        public FoldersController(Bookmarkcontext bookmarkcontext)
        {
            this._bookmarkcontext = bookmarkcontext;
        }
        [HttpGet()]
        public async Task<JsonResult> GetAll()
        {
            var result = await _bookmarkcontext.Foldermodels.ToListAsync();

            return new JsonResult(Ok(result));
        }
        [HttpGet]
        public async Task<JsonResult> Get(int ID)
        {
            var folderrecord = await _bookmarkcontext.Foldermodels.FirstOrDefaultAsync(x => x.Id == ID);
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
        public async Task<JsonResult> Create(Foldermodel foldermodel)
        {
            var folderRec = await _bookmarkcontext.Foldermodels.FirstOrDefaultAsync(x => x.Id == foldermodel.Id);
             if (folderRec == null)
            {
                await _bookmarkcontext.Foldermodels.AddAsync(foldermodel);
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
        public async Task<JsonResult> UpdateFolder([FromRoute] int ID, AddUpdateFolder updateFolder)
        {
            var foldertoupdate= await _bookmarkcontext.Foldermodels.FirstOrDefaultAsync(x => x.Id == ID);
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
            var FolderToDelete = _bookmarkcontext.Foldermodels.FirstOrDefault(x => x.Id == ID);
            if (FolderToDelete == null)
            { return new JsonResult(NotFound()); }
            else
            {
                _bookmarkcontext.Foldermodels.Remove(FolderToDelete);
                _bookmarkcontext.SaveChanges();
                return new JsonResult(NoContent());
            }
        }
    }
}
