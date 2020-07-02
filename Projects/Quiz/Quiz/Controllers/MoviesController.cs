using System;
using System.Collections.Generic;
using System.IO;
using Quiz;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiz.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var path = @"\\Mac\Home\Documents\Visual Studio 2015\Projects\Quiz\Quiz\App_Data\TextFile1.txt";
            var lines = System.IO.File.ReadAllLines(path);

            foreach (var line in lines)
            {
                //return Content(line);
            }
            return View();
            //return View();
        }
    }
}