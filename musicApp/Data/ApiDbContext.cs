using System;
using Microsoft.EntityFrameworkCore;
using musicApp.Models;

namespace musicApp.Data
{
    public class ApiDbContext : DbContext
    {

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        public DbSet<Song> Songs { get; set; }

    }
}
