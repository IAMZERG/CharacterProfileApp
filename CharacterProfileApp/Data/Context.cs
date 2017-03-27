using CharacterProfileApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace CharacterProfileApp.Data
{
    public class Context : DbContext
    {
        public DbSet<CharacterProfile> CharacterProfiles { get; set; }
        public DbSet<Alias> Aliases { get; set; }
        public DbSet<Stat> Stats { get; set; }
        public DbSet<Posession> Posessions { get; set; }

        public Context()
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        internal int CharacterProfilesCount()
        {
            return CharacterProfiles.Count();
        }
    }
}