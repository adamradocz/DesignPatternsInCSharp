using DesignPatternsInCSharp.Others.Repository.Data;
using DesignPatternsInCSharp.Others.Repository.Interfaces;
using DesignPatternsInCSharp.Others.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Tests.Others.Repository;

[TestClass]
public class RepositoryTests
{
    [TestMethod]
    public async Task FindByAsync_AddOneItemAndUseTheFilter_ItemFound()
    {
        //Arrange
        using var serviceProvider = ConfigureServices(new ServiceCollection())
            .BuildServiceProvider();

        var dbContext = serviceProvider.GetRequiredService<ProductDbContext>();
        _ = await dbContext.Database.EnsureCreatedAsync();
        var categoryRepository = serviceProvider.GetRequiredService<IRepository<Category>>();

        //Act        
        categoryRepository.Add(new Category() { Id = 1, CategoryName = "Category1" });
        var savedItemsCount = await dbContext.SaveChangesAsync();
        var category = await categoryRepository.FindByAsync(category => category.CategoryName.Equals("Category1", System.StringComparison.Ordinal));

        //Assert
        Assert.AreEqual(1, savedItemsCount);
        Assert.IsNotNull(category);
        Assert.AreEqual("Category1", category.CategoryName);
    }

    [TestMethod]
    public async Task GetAllAsync_AddTwoItems_ReturnsTwoItems()
    {
        //Arrange
        using var serviceProvider = ConfigureServices(new ServiceCollection())
            .BuildServiceProvider();

        var dbContext = serviceProvider.GetRequiredService<ProductDbContext>();
        _ = await dbContext.Database.EnsureCreatedAsync();

        var categoryRepository = serviceProvider.GetRequiredService<IRepository<Category>>();

        //Act
        var initialItems =  await categoryRepository.GetAllAsync();

        categoryRepository.Add(new Category() { Id = 1, CategoryName = "Category1" });
        categoryRepository.Add(new Category() { Id = 2, CategoryName = "Category2" });

        var savedItemsCount = await dbContext.SaveChangesAsync();
        var items = await categoryRepository.GetAllAsync();

        //Assert
        Assert.AreEqual(0, initialItems.Count);
        Assert.AreEqual(2, savedItemsCount);
        Assert.AreEqual(2, items.Count);
    }

    private static IServiceCollection ConfigureServices(IServiceCollection serviceCollection, [CallerMemberName] string callerMemberName = "") =>
        serviceCollection.AddDbContextPool<ProductDbContext>(options => options.UseInMemoryDatabase(callerMemberName).EnableSensitiveDataLogging())
        .AddSingleton<IRepository<Category>, Repository<Category>>();
}
