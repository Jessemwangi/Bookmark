using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Bookmark.Data;
using Bookmark.Models;

namespace Bookmark.Controllers
{
    [Route("api/v/[controller]")]
    [ApiController]
    public class foldersController : ControllerBase
    {
        private readonly Bookmarkcontext _bookmarkcontext;

        public foldersController(Bookmarkcontext bookmarkcontext)
        {
            this._bookmarkcontext = bookmarkcontext;
        }
        [HttpGet]
        public JsonResult get(int ID)
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
                    bookindb = foldermodel;

                }

            }
            _bookmarkcontext.SaveChanges();
            return new JsonResult(Ok(foldermodel));
        }
    }
}
