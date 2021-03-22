using HaileyHullingerAssignment9.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HaileyHullingerAssignment9.Controllers
{
    public class HomeController : Controller
    {
        //logger information removed

        //next two lines added for database
        private MovieContext context { get; set; }
        public HomeController(MovieContext con)
        {
            context = con;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcast()
        {
            return View();
        }

        //action for loadig the MovieForm page
        //simply loading the page, not accepting any information
        //will return the view with the same name as method
        [HttpGet]
        public IActionResult MovieForm()
        {
            return View();
        }


        //action for getting the movie information in httppost, once the button on the form is pressed
        //will return the confirmation view for when after the submit button has been pressed 
        [HttpPost]
        public IActionResult MovieForm(Movie movieResponse)
        {

            if (ModelState.IsValid)
            {
                //update database
                context.Movies.Add(movieResponse);
                context.SaveChanges();

                //after movie is added to list of movies, redirect to the Confirmation page
                return RedirectToAction("Confirmation");
            }

            else
            {
                return View();
            }

        }

        //action for loading the MovieList page
        public IActionResult MovieList()
        {
            //pass in database to view
            return View(context.Movies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
