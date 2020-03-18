namespace Tapas.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Tapas.Common;
    using Tapas.Data.Models;

    internal class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await this.CreateUserAsync(GlobalConstants.AdministratorName, GlobalConstants.EmailAdministrator, userManager);
            await this.CreateUserAsync(GlobalConstants.OperatorName, GlobalConstants.EmailOperator, userManager);
        }

        private async Task CreateUserAsync(string username, string email, UserManager<ApplicationUser> userManager)
        {
            var user = await userManager.FindByNameAsync(username);

            if (user != null)
            {
                return;
            }

            await userManager.CreateAsync(
                new ApplicationUser()
                {
                    UserName = username,
                    Email = email,
                    EmailConfirmed = true,
                }, username);
        }
    }
}
