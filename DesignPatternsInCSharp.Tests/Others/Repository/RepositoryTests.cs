using DesignPatternsInCSharp.Others.Repository.Data;
using DesignPatternsInCSharp.Others.Repository.Interfaces;
using DesignPatternsInCSharp.Others.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Tests.Others.Repository;

[TestClass]
public class RepositoryTests
{
    private readonly ServiceProvider _serviceProvider;

    public RepositoryTests()
    {
        var servicesCollection = new ServiceCollection();
        _serviceProvider = ConfigureServices(servicesCollection).BuildServiceProvider();
    }

    [TestMethod]
    public async Task Repository_FindByAsync_CategoryFoundByName()
    {
        //Arrange
        using var dbContext = _serviceProvider.GetRequiredService<ProductDbContext>();
        _ = await dbContext.Database.EnsureCreatedAsync();
        var categoryRepository = _serviceProvider.GetRequiredService<IRepository<Category>>();

        Assert.AreEqual(0, (await categoryRepository.GetAllAsync()).Count);
        categoryRepository.Add(new Category() { Id = 1, CategoryName = "CategoryName" });
        _ = await dbContext.SaveChangesAsync();
        Assert.AreEqual(1, (await categoryRepository.GetAllAsync()).Count);

        //Act
        var category = await categoryRepository.FindByAsync(category => category.CategoryName == "CategoryName");

        //Assert
        Assert.IsNotNull(category);
        Assert.AreEqual("CategoryName", category.CategoryName);
    }

    private IServiceCollection ConfigureServices(IServiceCollection serviceCollection) =>
        serviceCollection.AddDbContextPool<ProductDbContext>(options => options.UseInMemoryDatabase(nameof(RepositoryTests)).EnableSensitiveDataLogging())
        .AddSingleton<IRepository<Category>, Repository<Category>>();
}
