using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCgame.DAL;
using MVCgame.Models;

namespace MVCgame.Controllers
{
    public class GamesController : Controller
    {
        private GameContext db = new GameContext();

        //// GET: Games
        //public ActionResult Index()
        //{
        //    var games = db.Games.Include(g => g.Genre).Include(g => g.Platforms);
        //    return View(games.ToList());
        //}

        public ActionResult Index(string sortOrder)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.DateSortParm = sortOrder == "ReleaseDate" ? "title_desc" : "ReleaseDate";
            var games = from s in db.Games
                           select s;
            switch (sortOrder)
            {
                case "title_desc":
                    games = games.OrderByDescending(s => s.Title);
                    break;
                case "ReleaseDate":
                    games = games.OrderBy(s => s.ReleaseDate);
                    break;
                default:
                    games = games.OrderBy(s => s.Title);
                    break;
            }
            return View(games.ToList());
        }

        // GET: Games/Details/5
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

        // GET: Games/Create
        public ActionResult Create()
        {
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name");
            ViewBag.PlatformID = new SelectList(db.Platforms, "PlatformID", "System");
            return View();
        }

        // POST: Games/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name", game.GenreID);
            ViewBag.PlatformID = new SelectList(db.Platforms, "PlatformID", "System", game.PlatformID);
            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name", game.GenreID);
            ViewBag.PlatformID = new SelectList(db.Platforms, "PlatformID", "System", game.PlatformID);
            return View(game);
        }

        // POST: Games/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Game game)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(game).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.GenreID = new SelectList(db.Genres, "GenreID", "Name", game.GenreID);
        //    ViewBag.PlatformID = new SelectList(db.Platforms, "PlatformID", "System", game.PlatformID);
        //    return View(game);
        //}

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Game game)
        {
            if (game == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var gameToUpdate = db.Games.Find(game);
            if (TryUpdateModel(gameToUpdate, "",
               new string[] { "GenreID", "PlatformID", "Title", "ReleaseMonth", "ReleaseDate" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(gameToUpdate);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
