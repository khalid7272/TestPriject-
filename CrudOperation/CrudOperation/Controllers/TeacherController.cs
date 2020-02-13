using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudOperation.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CrudOperation.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private SchoolContext schoolContext;
        public TeacherController(ILogger<HomeController> logger, SchoolContext sc)
        {
            _logger = logger;
            schoolContext = sc;
        }
        public IActionResult Index()
        {
            return View(schoolContext.Teacher);
        }
    }
}