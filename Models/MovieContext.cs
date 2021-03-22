using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HaileyHullingerAssignment9.Models
{
    public class MovieContext : DbContext
    {
        //constructor
        public MovieContext (DbContextOptions<MovieContext> options) :base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
    }
}
