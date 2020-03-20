namespace Tapas.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using Tapas.Common;
    using Tapas.Data.Models;

    internal class UsersToRoleSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await this.AddUserToRole(
                GlobalConstants.AdministratorName,
                userManager);

            await this.AddUserToRole(
                GlobalConstants.OperatorName,
                userManager);
        }

        private async Task AddUserToRole(
            string userName,
            UserManager<ApplicationUser> userManager)
        {
            var user = await userManager.FindByNameAsync(userName);

            if (await userManager.IsInRoleAsync(user, userName))
            {
                return;
            }

            await userManager.AddToRoleAsync(user, userName);
        }
    }
}
