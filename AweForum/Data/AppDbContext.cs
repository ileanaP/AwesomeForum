using AweForum.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AweForum.Data
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Message_Reaction>().HasKey(mr => new {
                mr.MessageId,
                mr.ReactionId
            });
            
            builder.Entity<Message_Reaction>().HasOne(m => m.ThreadMessage).WithMany(mr => mr.Message_Reactions).HasForeignKey(m => m.MessageId);
            builder.Entity<Message_Reaction>().HasOne(m => m.Reaction).WithMany(mr => mr.Message_Reactions).HasForeignKey(m => m.ReactionId);

            builder.Entity<User_Reaction>().HasKey(ur => new
            {
                ur.MessageId,
                ur.ReactionId,
                ur.UserId
            });

            builder.Entity<User_Reaction>().HasOne(m => m.ThreadMessage).WithMany(ur => ur.User_Reactions).HasForeignKey(m => m.MessageId);
            builder.Entity<User_Reaction>().HasOne(m => m.Reaction).WithMany(ur => ur.User_Reactions).HasForeignKey(m => m.ReactionId);
            builder.Entity<User_Reaction>().HasOne(m => m.User).WithMany(ur => ur.User_Reactions).HasForeignKey(m => m.UserId);

            base.OnModelCreating(builder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Forum> Forums { get; set; }
        public DbSet<Message_Reaction> MessageReactions { get; set; }
        public DbSet<Reaction> Reactions { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<ThreadMessage> ThreadMessages { get; set; }
        public DbSet<User_Reaction> UserReactions { get; set; }

    }
}
