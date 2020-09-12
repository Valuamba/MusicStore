using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly MusicStoreEntities musicContext;
        public StoreController(MusicStoreEntities musicContext)
        {
            this.musicContext = musicContext;
        }

        //public IDbConnection Connection
        //{
        //    get
        //    {
        //        return new SqlConnection(config.GetConnectionString("DefaultConnection"));
        //    }
        //}
        public void Some()
        {
            States s1 = new States() { Description = "Some text" };
            States s2 = new States() { Description = "Some text 2" };

            musicContext.States.Add(s1);
            musicContext.States.Add(s2);
            musicContext.SaveChanges();

            Peoples p1 = new Peoples()
            {
                Name = "Vasily",
                Years = 20,
                State = s1
            };
            Peoples p2 = new Peoples()
            {
                Name = "Igor",
                Years = 20,
                State = s2
            };

            musicContext.Peoples.Add(p1);
            musicContext.Peoples.Add(p2);

            musicContext.SaveChanges();
        }
        public void Add()
        {
            //musicContext.Artist.AddRange(SampleData.artists);
            //musicContext.SaveChanges();

            musicContext.Genre.AddRange(SampleData.genres);
            musicContext.SaveChanges();

            //musicContext.Album.AddRange(SampleData.Album());
            //musicContext.SaveChanges();

        }

        public ActionResult Index()
        {
            var genres = musicContext.Genre.ToList();
            return View(genres);
        }

        // GET: StoreController/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Browse(string genre)
        {

            var genreModel = musicContext.Genre.Include("Album")
                .First(g=> g.Name == genre);
            return View(genreModel);
        }

        public ActionResult Details(int id)
        {
            var album = musicContext.Album.Find(id);
            return View(album);
        }
    }
}
