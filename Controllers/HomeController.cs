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

        //Index action
        public IActionResult Index()
        {
            return View();
        }

        //podcast action
        public IActionResult Podcast()
        {
            return View();
        }

        //action for loadig the MovieForm page
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
            //check if changes are valid, if so add to database, if not return asp validation summary
            if (ModelState.IsValid)
            {
                //update database
                context.Movies.Add(movieResponse);
                context.SaveChanges();

                //after movie is added to list of movies, redirect to the Confirmation page
                return RedirectToAction("MovieLIst");
            }

            else
            {
                return View();
            }

        }

        //action for loading the MovieList page, pass in the db context to the view
        [HttpGet]
        public IActionResult MovieList()
        {
            //pass in database to view
            return View(context.Movies);
        }

        //if an ID is passed to this view, the movie is deleted from the list and redirects to movie list without the deleted movie
        [HttpPost]
        public IActionResult Delete(int MovieID)
        {
            context.Movies.Remove(context.Movies.Find(MovieID));
            context.SaveChanges();
            return RedirectToAction("MovieList");
        }


        //edit view, the method finds the movie where the movieID matches the one passed in, passes it to the edit view
        [HttpGet] 
        public IActionResult Edit(int MovieID)
        {
            var movie = context.Movies.Where(m => m.MovieID == MovieID).FirstOrDefault();

            return View(movie);
        }

        //when the SAVE button is pressed on the edit.cshtml page, the movie and the movie ID is passed into the method where it is updated and then changes saved
        [HttpPost]
        public IActionResult Save(Movie movie, int MovieID)
        {
            //set the movie being updated
            var MovieToOverwrite = context.Movies.Where(movie => movie.MovieID == MovieID).FirstOrDefault();

            //Ensure form inputs are valid, if so override current entries
            if (ModelState.IsValid)
            {
                //Update the values of the movie corresponding with the movieid passed in
                MovieToOverwrite.Title = movie.Title;
                MovieToOverwrite.Category = movie.Category;
                MovieToOverwrite.Year = movie.Year;
                MovieToOverwrite.Director = movie.Director;
                MovieToOverwrite.Rating = movie.Rating;
                MovieToOverwrite.Edited = movie.Edited;
                MovieToOverwrite.LentTo = movie.LentTo;
                MovieToOverwrite.Notes = movie.Notes;

                //Save changes to the DB after being overridden
                context.SaveChanges();
                
            }
            //return asp validation summary
            else
            {
                return View("Edit");
            }

            return RedirectToAction("MovieList");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
