using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCgame.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVCgame.DAL
{
    public class GameContext : DbContext
    {
        
        public GameContext() : base("GameContext")
            //Is this all i need for the connection string?
        {
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Game> Games { get; set; }

        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)

        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}