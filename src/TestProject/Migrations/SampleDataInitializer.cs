using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using TestProject.Models;

namespace TestProject.Migrations
{
    public class SampleDataInitializer : IDisposable
    {
        private readonly ApplicationDbContext context;
        private readonly PasswordHasher<ApplicationUser> passwordHasher;
        private readonly UserManager<ApplicationUser> userManager;

        public SampleDataInitializer(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this.passwordHasher = new PasswordHasher<ApplicationUser>();
            this.context = context;
            this.userManager = userManager;
        }

        public void Dispose()
        {
            this.context.Dispose();
            this.userManager.Dispose();
        }

        public async Task InitializeDataAsync()
        {
            if (await this.userManager.FindByNameAsync("blah") == null)
            {
                /*var user = new ApplicationUser
                {
                    UserName = "blah",
                    Email = "test@test.com"
                };
                user.PasswordHash = this.passwordHasher.HashPassword(user, "password");
                this.context.Users.Add(user);*/

                var user = new ApplicationUser { UserName = "blah", Email = "test@test.com" };
                await this.userManager.CreateAsync(user, "blah");

                // Just making sure...?
                this.context.SaveChanges();
                Console.WriteLine(await this.userManager.CheckPasswordAsync(await this.userManager.FindByNameAsync("blah"), "blah") ? "Valid" : "Invalid");
            }
        }
    }
}