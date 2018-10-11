using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eideas.Areas.Identity.Data;
using eideas.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eideas.Data
{
    public class ApplicationDbContext : IdentityDbContext<EIdeasUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Division> Divisions { get; set; }
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

        }
    }
}
