using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CrudOperation.Models;
using CrudOperation.Context;

namespace CrudOperation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SchoolContext schoolContext;
        public HomeController(ILogger<HomeController> logger, SchoolContext sc)
        {
            _logger = logger;
            schoolContext = sc;
        }
        public IActionResult Index()
        {
            return View(schoolContext.Teacher);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                schoolContext.Teacher.Add(teacher);
                schoolContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View();
        }
        public IActionResult Update(int id)
        {
            return View(schoolContext.Teacher.Where(a => a.Id == id).FirstOrDefault());
        }

        [HttpPost]
        [ActionName("Update")]
        public IActionResult Update_Post(Teacher teacher)
        {
            schoolContext.Teacher.Update(teacher);
            schoolContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var teacher = schoolContext.Teacher.Where(a => a.Id == id).FirstOrDefault();
            schoolContext.Teacher.Remove(teacher);
            schoolContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
