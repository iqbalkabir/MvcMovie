//#define OverloadDelete
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcMovie.Models;
using Massive;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        protected dynamic _table; 

        public MoviesController( ) 
        {
            _table = new Movies();
            ViewBag.Table = _table;
        }

        /*

        // GET: /Movies/SearchIndex
#if ONE
public ActionResult SearchIndex(string Genre, string searchString)
{

    var GenreLst = new List<string>();
    GenreLst.Add("All");

    var GenreQry = from d in db.Movies
                   orderby d.Genre
                   select d.Genre;
    GenreLst.AddRange(GenreQry.Distinct());
    ViewBag.Genre = new SelectList(GenreLst);

    var movies = from m in db.Movies
                 select m;

    if (!String.IsNullOrEmpty(searchString))
    {
        movies = movies.Where(s => s.Title.Contains(searchString));
    }

    if (string.IsNullOrEmpty(Genre) || Genre == "All")
        return View(movies);
    else
    {
        return View(movies.Where(x => x.Genre == Genre));
    }

}
#else

        public ActionResult SearchIndex(string movieGenre, string searchString)
        {

            var GenreLst = new List<string>();

            var GenreQry = from d in db.Movies
                           orderby d.Genre
                           select d.Genre;
            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.movieGenre = new SelectList(GenreLst);

            var movies = from m in db.Movies
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }


            if (string.IsNullOrEmpty(movieGenre))
                return View(movies);
            else
            {
                return View(movies.Where(x => x.Genre == movieGenre));
            }

        }
#endif



        //public ActionResult SearchIndex(string searchString)
        //{          
        //    var movies = from m in db.Movies
        //                 select m;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        movies = movies.Where(s => s.Title.Contains(searchString));
        //    }

        //    return View(movies);
        //}

        [HttpPost]
        public string SearchIndex(FormCollection fc, string searchString) {
            return "<h3> From [HttpPost]SearchIndex: " + searchString + "</h3>";
        }

        */


        public ViewResult Index()
        {
            IEnumerable<dynamic> items = _table.All(); 
            return View(items);
        }


         
        [HttpGet]
        public virtual ActionResult Edit(int id)
        {
            var model = _table.Get(ID: id);
            model._Table = _table;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Edit(int id, FormCollection collection)
        {
            var model = _table.CreateFrom(collection);
            try
            {
                // TODO: Add update logic here
                _table.Update(model, id);
                return RedirectToAction("Index");
            }
            catch (Exception x)
            {
                TempData["Error"] = "There was a problem editing this record";
                return View(model);
            }
        }



        [HttpGet]
        public virtual ActionResult Details(int id)
        {
            var model = _table.Get(ID: id);
            return View(model); 
        }




        [HttpGet]
        public ActionResult Create()
        {
            return View(_table.Prototype);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(FormCollection collection)
        {
            var model = _table.CreateFrom(collection);
            try
            {
                // TODO: Add insert logic here
                _table.Insert(model);
                return RedirectToAction("Index");
            }
            catch (Exception x)
            {
                TempData["Error"] = "There was a problem adding this record";
                return View();
            }
        }




    }
}