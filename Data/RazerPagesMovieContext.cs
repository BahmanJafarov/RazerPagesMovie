using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazerPagesMovie.Models;

namespace RazerPagesMovie.Data
{
    public class RazerPagesMovieContext : DbContext
    {
        public RazerPagesMovieContext (DbContextOptions<RazerPagesMovieContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie { get; set; }
    }
}
