using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDVjezba.Models;
using CRUDVjezba.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace CRUDVjezba.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment _environment;

        public HomeController(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        private StudentContext db = new StudentContext();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFaculty( Faculty faculty,ICollection< IFormFile> files)
        {
            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        faculty.LogoString = "~/uploads/"+file.FileName;
                    }
                    
                }
            }
            
            db.Faculties.Add(faculty);
            db.SaveChanges();
            return RedirectToAction("All");
        }
        [HttpGet]
        public IActionResult CreateFaculty()
        {
            return View();
        }
        public IActionResult All()
        {
            return View(db.Faculties);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Faculty fact = db.Faculties.FirstOrDefault(x=>x.Id==id);
            db.Faculties.Remove(fact);
            db.SaveChanges();

            if (Request.IsAjaxRequest())
                return Ok();
            else
                return RedirectToAction("All");
        }

        [HttpPost]
        public IActionResult Edit(Faculty fact)
        {
            db.Update(fact);
            db.SaveChanges();
            return RedirectToAction("All");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(db.Faculties.First(x=>x.Id==id));
        }
    }
}
