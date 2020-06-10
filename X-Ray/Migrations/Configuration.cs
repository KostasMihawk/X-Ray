using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using X_Ray.Models;

namespace X_Ray.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<X_Ray.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(X_Ray.Models.ApplicationDbContext context)
        {

            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);

            if (!context.Users.Any(x => x.Email == "mgeladari@unipi.gr"))
            {
                var user = new ApplicationUser { Email = "mgeladari@unipi.gr", UserName = "mgeladari", Name = "Maria", Surname = "Geladari", Hospital = "Hospital2", Department = "Orthopedix" };
                userManager.Create(user, "1qaz@WSX");
                context.Roles.AddOrUpdate(x => x.Name, new IdentityRole { Name = "Doctor" });
                context.SaveChanges();
                userManager.AddToRole(user.Id, "Doctor");
            }
            if (!context.Users.Any(x => x.Email == "apanagiotopoulos@unipi.gr"))
            {
                var user = new ApplicationUser { Email = "apanagiotopoulos@unipi.gr", UserName = "apanagiotopoulos", Name = "Alex", Surname = "Panagiotopoulos", Hospital = "Hospital1", Department = "Xray" };
                userManager.Create(user, "1qaz@WSX");
                context.Roles.AddOrUpdate(x => x.Name, new IdentityRole { Name = "Doctor" });
                context.SaveChanges();
                userManager.AddToRole(user.Id, "Doctor");
            }
            if (!context.Users.Any(x => x.Email == "gsourila@unipi.gr"))
            {
                var user = new ApplicationUser { Email = "gsourila@unipi.gr", UserName = "gsourila", Name = "Garuffalia", Surname = "Sourila", Hospital = "Hospital3", Department = "Pathologix" };
                userManager.Create(user, "1qaz@WSX");
                context.Roles.AddOrUpdate(x => x.Name, new IdentityRole { Name = "Doctor" });
                context.SaveChanges();
                userManager.AddToRole(user.Id, "Doctor");
            }
            if (!context.Users.Any(x => x.Email == "msabanis@unipi.gr"))
            {
                var user = new ApplicationUser { Email = "msabanis@unipi.gr", UserName = "msabanis", Name = "Michalis", Surname = "Sabanis", Hospital = "Health Care Centre", Department = "XRay" };
                userManager.Create(user, "1qaz@WSX");
                context.Roles.AddOrUpdate(x => x.Name, new IdentityRole { Name = "Doctor" });
                context.SaveChanges();
                userManager.AddToRole(user.Id, "Doctor");
            }
            if (!context.Users.Any(x => x.Email == "drallis@unipi.gr"))
            {
                var user = new ApplicationUser { Email = "drallis@unipi.gr", UserName = "drallis", Name = "Dimitrios", Surname = "Rallis", Hospital = "Main Hospital", Department = "XRay" };
                userManager.Create(user, "1qaz@WSX");
                context.Roles.AddOrUpdate(x => x.Name, new IdentityRole { Name = "Doctor" });
                context.SaveChanges();
                userManager.AddToRole(user.Id, "Doctor");
            }
            if (!context.Users.Any(x => x.Email == "jcampell@unipi.gr"))
            {
                var user = new ApplicationUser { Email = "jcampell@unipi.gr", UserName = "jcampell", Name = "Joseph", Surname = "Campell", Hospital = "Main Hospital", Department = "XRay" };
                userManager.Create(user, "1qaz@WSX");
                context.Roles.AddOrUpdate(x => x.Name, new IdentityRole { Name = "Doctor" });
                context.SaveChanges();
                userManager.AddToRole(user.Id, "Doctor");
            }
            if (!context.Users.Any(x => x.Email == "jkarabatou@unipi.gr"))
            {
                var user = new ApplicationUser { Email = "jkarabatou@unipi.gr", UserName = "jkarabatou", Name = "Julia", Surname = "Karabatou", Hospital = "Main Hospital", Department = "XRay" };
                userManager.Create(user, "1qaz@WSX");
                context.Roles.AddOrUpdate(x => x.Name, new IdentityRole { Name = "Doctor" });
                context.SaveChanges();
                userManager.AddToRole(user.Id, "Doctor");
            }
            if (!context.Users.Any(x => x.Email == "bmichos@unipi.gr"))
            {
                var user = new ApplicationUser { Email = "bmichos@unipi.gr", UserName = "bmichos", Name = "Bill", Surname = "Michos", Hospital = "Main Hospital", Department = "XRay" };
                userManager.Create(user, "1qaz@WSX");
                context.Roles.AddOrUpdate(x => x.Name, new IdentityRole { Name = "Doctor" });
                context.Roles.AddOrUpdate(x => x.Name, new IdentityRole { Name = "Manager" });
                context.SaveChanges();
                userManager.AddToRole(user.Id, "Doctor");
                userManager.AddToRole(user.Id, "Manager");
            }
            if (!context.Users.Any(x => x.Email == "kmichopoulos@unipi.gr"))
            {
                var user = new ApplicationUser { Email = "kmichopoulos@unipi.gr", UserName = "kmichopoulos", Name = "Konstantinos", Surname = "Michopoulos", Hospital = "Main Hospital", Department = "IT" };
                userManager.Create(user, "1qaz@WSX");
                context.Roles.AddOrUpdate(x => x.Name, new IdentityRole { Name = "Admin" });
                context.SaveChanges();
                userManager.AddToRole(user.Id, "Admin");
            }
        }

    }
}
