using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDVjezba.Models;
using CRUDVjezba.Controllers;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUDVjezba.Controllers
{
    public class BlogController : Controller
    {
        private StudentContext db = new StudentContext();
        // GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            return View("Blog");
        }
        [HttpPost]
        public IActionResult Index(ExampleClass model)
        {
            db.Html.Add(model);
            db.SaveChanges();
            return View("GetBlog", db.Html);
        }
    }

}
