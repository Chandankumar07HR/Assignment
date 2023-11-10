using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace CodeFirst_EF_CodeBaseTest1.Models
{
    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext() : base("connectstr")
        {

        }
        public DbSet<Movie> Movies { get; set; }
    }
}