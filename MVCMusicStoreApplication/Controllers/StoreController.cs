using MVCMusicStoreApplication.Data;
using MVCMusicStoreApplication.Models;
using System.Linq;
using System.Web.Mvc;

namespace MVCMusicStoreApplication.Controllers
{
    public class StoreController : Controller
    {

        MVCMusicStoreDB db = new MVCMusicStoreDB();

        [HttpGet]
        public ActionResult Browse()
        {
            var genres = db.Genres.ToList();

            return View(genres);
        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            var albumModel = db.Albums.Where(album => album.GenreId == id).ToList();
            return View(albumModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var albumModel = db.Albums.FirstOrDefault(album => album.AlbumId == id);
            return View(albumModel);
        }
    }
}