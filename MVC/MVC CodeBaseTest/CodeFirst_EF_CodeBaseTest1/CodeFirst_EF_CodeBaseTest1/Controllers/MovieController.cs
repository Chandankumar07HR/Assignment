using System;
using System.Linq;
using System.Web.Mvc;
using CodeFirst_EF_CodeBaseTest1.Models;

namespace CodeFirst_EF_CodeBaseTest1.Controllers
{
    public class MoviesController : Controller
    {
        public  MoviesDbContext db = new MoviesDbContext();
        public MoviesController()
        {
            db = new MoviesDbContext();
        }
       
        public ActionResult Index()
        {
            var movies = db.Movies.ToList();
            return View(movies);
        }
       
        public ActionResult Details(int id)
        {
            Movie movie = db.Movies.Find(id);
            return View(movie);
        }
        

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
       
        public ActionResult Edit(int id)
        {
            Movie movie = db.Movies.Find(id);
            return View(movie);
        }
        
        [HttpPost]
      
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
    


        public ActionResult Delete(int id)
        {
            Movie movie = db.Movies.Find(id);
            return View(movie);
        }
       

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Movie movie = db.Movies.Find(id);
            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
  
    }
}