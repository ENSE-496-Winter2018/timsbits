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
        public DbSet<IdeaComment> IdeaComments { get; set; }
        public DbSet<CommentUpDoot> CommentUpDoots { get; set; }
        public DbSet<IdeaSubscription> IdeaSubscriptions { get; set; }




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
            builder.Entity<Team>().HasMany(a => a.EideasUsers).WithOne(b => b.Team);

            builder.Entity<EIdeasUser>().HasMany(a => a.IdeaComments).WithOne(b => b.EIdeasUser);

            builder.Entity<Idea>().HasMany(a => a.IdeaComments).WithOne(b => b.Idea);


            //IdeaSubscription mapping
            builder.Entity<IdeaSubscription>().HasKey(a => new { a.Id,a.IdeaId });

            builder.Entity<IdeaSubscription>().HasOne(a => a.EideasUser)
                .WithMany(b => b.IdeaSubscriptions).HasForeignKey(c => c.Id);

            builder.Entity<IdeaSubscription>().HasOne(a => a.Idea)
                .WithMany(b => b.IdeaSubscriptions).HasForeignKey(c => c.IdeaId);


            //IdeaUpdoot mapping
            builder.Entity<IdeaUpDoot>().HasKey(a => new { a.Id, a.IdeaId });

            builder.Entity<IdeaUpDoot>().HasOne(a => a.EideasUser)
                .WithMany(b => b.IdeaUpdoots).HasForeignKey(c => c.Id);

            builder.Entity<IdeaUpDoot>().HasOne(a => a.Idea)
                .WithMany(b => b.IdeaUpdoots).HasForeignKey(c => c.IdeaId);

            //CommentUpdoot mapping
            builder.Entity<CommentUpDoot>().HasKey(a => new { a.Id, a.IdeaCommentId });

            builder.Entity<CommentUpDoot>().HasOne(a => a.EIdeasUser)
                .WithMany(b => b.CommentUpDoots).HasForeignKey(c => c.Id);

            builder.Entity<CommentUpDoot>().HasOne(a => a.IdeaComment)
                .WithMany(b => b.CommentUpDoots).HasForeignKey(c => c.IdeaCommentId);


            builder.Entity<Idea>().HasOne(a => a.EIdeasUser).WithMany(b => b.Ideas);


        }


       
    }
}
