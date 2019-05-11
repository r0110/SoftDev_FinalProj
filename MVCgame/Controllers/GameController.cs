using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCgame.Models;
using System.Web.Mvc;
using MVCgame.DAL;
using System.Data.Entity;
using System.Net;

namespace MVCgame.Controllers
{
    public class GameController : Controller
    {
        private GameContext db = new GameContext();
        // GET: Game
        public ActionResult Index()
        {
            return View(db.Games.ToList());
        }
        //
        //GET: /Game/Browse?genre=FPS
        //public ActionResult Browse(string genre)
        //{
        //    TempData data = new TempData();
        //    var genreModel = data.GetGenres().Where(x => x.Name == genre).FirstOrDefault();
        //    genreModel.Games = data.GetGames().Where(g => g.Genre.Name == genre).ToList();
        //    return View(genreModel);

        //}
        //public ActionResult Browse(string genre)
        //{

        //}

        //
        //GET: /Store/Details
        //public ActionResult Details(int id)
        //{
        //    TempData tempData = new TempData();
        //    var game = tempData.GetGames().Where(x => x.GameID == id).FirstOrDefault();
        //    return View(game);
        //}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }
    }
}