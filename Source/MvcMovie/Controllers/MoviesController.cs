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
        private DynamicModel _movies;

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
        //
        // GET: /Movies/

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
        //[ValidateAntiForgeryToken] 
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


        /*
        //
        // GET: /Movies/Details/5

        public ActionResult Details(int id = 0)
        {
            var model = _table.Get(ID: id);
            model._Table = _table;
            return View(model);
            //Movie movie = db.Movies.Find(id);
            //if (movie == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(movie);
        }

        //
        // GET: /Movies/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Movies/Create

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _table.Insert(movie);
                return RedirectToAction("Index");
            } 
            return View(movie);
        }

        //
        // GET: /Movies/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var model = _table.Get(ID: id);
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        //
        // POST: /Movies/Edit/5

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        //
        // GET: /Movies/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
#if OverloadDelete
        public ActionResult Delete(FormCollection fcNotUsed, int id = 0)
        {
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
#else
//
// POST: /Movies/Delete/5

[HttpPost, ActionName("Delete")]
public ActionResult DeleteConfirmed(int id = 0) {
    Movie movie = db.Movies.Find(id);
    if (movie == null) {
        return HttpNotFound();
    }
    db.Movies.Remove(movie);
    db.SaveChanges();
    return RedirectToAction("Index");
}
#endif


        */


    }
}