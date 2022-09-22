using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Bookmark.Data;
using Bookmark.Models;

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
        public JsonResult GetAll()
        {
            var result = _bookmarkcontext.foldermodels.ToList();

            return new JsonResult(Ok(result));
        }
        [HttpGet]
        public JsonResult Get(int ID)
        {
            var folderrecord = _bookmarkcontext.foldermodels.FirstOrDefault(x => x.Id == ID);
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
        public JsonResult Create(foldermodel foldermodel)
        {
            if (foldermodel.Id == 0)
            {
                _bookmarkcontext.foldermodels.Add(foldermodel);
            }
            else
            {
                var bookindb = _bookmarkcontext.foldermodels.FirstOrDefault(x => x.Id == foldermodel.Id);
                if (bookindb == null)
                {
                    return new JsonResult(NotFound());
                   
                }
                else
                {
                    _bookmarkcontext.foldermodels.Update(bookindb);
                }
            }
            _bookmarkcontext.SaveChanges();
            return new JsonResult(Ok(foldermodel));
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
