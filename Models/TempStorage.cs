using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaileyHullingerAssignment9.Models
{
    public class TempStorage
    {
        //crete new list
        private static List<Movie> movies = new List<Movie>();

        //fill the list
        public static IEnumerable<Movie> Movies => movies;

        public static void AddMovie(Movie movie)
        {
            movies.Add(movie);
        }
    }
}
