using System;
using System.Linq;
using System.Web.Mvc;
using CodeFirst_EF_CodeBaseTest1.Models;
using CodeFirst_EF_CodeBaseTest1.Models.Repository;

namespace CodeFirst_EF_CodeBaseTest1.Controllers
{
    public class MoviesController : Controller
    {
        IRepository<Movie> _repository = null;

        public MoviesController()
        {
            _repository = new Repository<Movie>();
        }

        public ActionResult Index()
        {
            var movie = _repository.GetAll();
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
                _repository.Insert(movie);
                _repository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(movie);
            }
        }

        public ActionResult Edit(int Id)
        {
            var product = _repository.GetById(Id);
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Movie m)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(m);
                _repository.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(m);
            }
        }

        public ActionResult Details(int Id)
        {
            var movie = _repository.GetById(Id);    
            return View(movie);
        }
        public ActionResult Delete(int Id)
        {
            var movie = _repository.GetById(Id);
            return View(movie);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeletePost(int Id)
        {
             _repository.GetById(Id);
            _repository.Delete(Id);
            _repository.Save();
            return RedirectToAction("Index");
        }
        public ActionResult MoviesByYear(int year=2023)
        {
            var moviesInYear = _repository.GetAll().Where(m => m.DateOfRelease.Year == year).ToList();
            return View(moviesInYear);
        }


    }
}