using Lacks2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Lacks2.Migrations {
    public class Configuration : DbMigrationsConfiguration<AppContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }
        protected override void Seed(AppContext context) {
            List<Person> people = new List<Person>();
            people.AddRange(new Person[]{
                new Person() {
                    Name = "Rudy",
                    Foods = new List<Food>() {
                        new Food() { Name = "Tacos" },
                        new Food() { Name = "Sushi" }
                    }
                },
                new Person() {
                    Name = "Matt",
                    Foods = new List<Food>() {
                        new Food() { Name = "Pizza" },
                        new Food() { Name = "Spaggheti" }
                    }
                },
            });
            context.Persons.AddOrUpdate(p => p.Name, people.ToArray());
            context.SaveChanges();
        }
    }
}