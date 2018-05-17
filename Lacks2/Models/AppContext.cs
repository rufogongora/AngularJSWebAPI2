using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lacks2.Models {
    public class AppContext : DbContext {
        public AppContext() : base("DefaultConnection") {

        }

        static AppContext() {
            Database.SetInitializer<AppContext>(
            new MigrateDatabaseToLatestVersion<AppContext, Migrations.Configuration>());
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Food> Foods { get; set; }

    }
}