using BigSchool.Models;
using BigSchool.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BigSchool.Controllers
{
    public class CoursesController : Controller
    {
    private readonly ApplicationDbContext _dbContext;
        // GET: Courses
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: Courses/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Courses/Create
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CourseViewModel
            {
                Categories = _dbContext.Categories.ToList()
            };
   
            return View(viewModel);
        }

        // POST: Courses/Create
        [HttpPost]
        public ActionResult Create(CourseViewModel courseViewModel)
        {
                if(!ModelState.IsValid)
                {
                    courseViewModel.Categories = _dbContext.Categories.ToList();
                return View("Create", courseViewModel);
                }
                // TODO: Add insert logic here
                var newCourse = new Course
                {
                    LecturerId = User.Identity.GetUserId(),
                    Place = courseViewModel.Place,
                    CategoryId = courseViewModel.Category,
                    DateTime = courseViewModel.GetDateTime(),
                  
                };

            _dbContext.Courses.Add(newCourse);
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Home");

        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Courses/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Courses/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
