using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class StoreManagerController : Controller
    {
        private readonly MusicStoreEntities musicContext;
        public StoreManagerController(MusicStoreEntities musicContext)
        {
            this.musicContext = musicContext;
        }
        public ActionResult Index()
        {
            return View(musicContext.Album.Include(g => g.Genre).Include(a => a.Artist));
        }

        public ActionResult Details(int id)
        {
            return View(musicContext.Album.Find(id));
        }

        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(musicContext.Genre, "Id", "Name");
            ViewBag.ArtistId = new SelectList(musicContext.Artist, "Id", "Name");
            return View();
        }

        public ActionResult Edit(int id)
        {
            Album album = musicContext.Album.Find(id);
            ViewBag.GenreId = new SelectList(musicContext.Genre, "Id", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(musicContext.Artist, "Id", "Name", album.ArtistId);

            return View(album);
        }

        [HttpPost]
        public ActionResult Edit(Album album)
        {
            if (ModelState.IsValid)
            {
                musicContext.Entry(album).State = EntityState.Modified;
                musicContext.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewBag.GenreId = new SelectList(musicContext.Genre, "Id", "Name", album.GenreId);
            ViewBag.ArtistId = new SelectList(musicContext.Artist, "Id", "Name", album.ArtistId);

            return View(album);
        }
        public ActionResult Delete(int id)
        {
            return View(musicContext.Album.Find(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = musicContext.Album.Find(id);
            musicContext.Album.Remove(album);
            musicContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
