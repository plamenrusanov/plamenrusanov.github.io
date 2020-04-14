namespace Tapas.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Tapas.Data;
    using Tapas.Data.Common.Repositories;
    using Tapas.Data.Models;
    using Tapas.Data.Repositories;
    using Xunit;

    public class SettingsServiceTests
    {
    //    [Fact]
    //    public void GetCountShouldReturnCorrectNumber()
    //    {
    //        var repository = new Mock<IRepository<Setting>>();
    //        repository.Setup(r => r.All()).Returns(new List<Setting>
    //                                                    {
    //                                                        new Setting(),
    //                                                        new Setting(),
    //                                                        new Setting(),
    //                                                    }.AsQueryable());
    //        var service = new SettingsService(repository.Object);
    //        Assert.Equal(3, service.GetCount());
    //        repository.Verify(x => x.All(), Times.Once);
    //    }

    //    [Fact]
    //    public async Task GetCountShouldReturnCorrectNumberUsingDbContext()
    //    {
    //        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
    //            .UseInMemoryDatabase(databaseName: "SettingsTestDb").Options;
    //        var dbContext = new ApplicationDbContext(options);
    //        dbContext.Settings.Add(new Setting());
    //        dbContext.Settings.Add(new Setting());
    //        dbContext.Settings.Add(new Setting());
    //        await dbContext.SaveChangesAsync();

    //        var repository = new EfDeletableEntityRepository<Setting>(dbContext);
    //        var service = new SettingsService(repository);
    //        Assert.Equal(3, service.GetCount());
    //    }
    }
}
