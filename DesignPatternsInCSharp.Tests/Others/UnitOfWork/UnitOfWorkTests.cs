using DesignPatternsInCSharp.Others.Repository.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using DesignPatternsInCSharp.Tests.Others.Repository;
using Microsoft.EntityFrameworkCore;
using DesignPatternsInCSharp.Others.Repository.Data;
using System.Runtime.CompilerServices;

namespace DesignPatternsInCSharp.Tests.Others.UnitOfWork;

[TestClass]
public class UnitOfWorkTests
{
    [TestMethod]
    public async Task SaveAsync_AddCategoryAndProduct_BothSaved()
    {
        //Arrange
        using var _serviceProvider = ConfigureServices(new ServiceCollection()).BuildServiceProvider();
        _ = _serviceProvider.GetRequiredService<ProductDbContext>().Database.EnsureCreated();
        var unitOfWork = _serviceProvider.GetRequiredService<DesignPatternsInCSharp.Others.UnitOfWork.UnitOfWork>();

        //Act
        unitOfWork.CategoryRepository.Add(new Category() { Id = 1, CategoryName = "Category1" });
        unitOfWork.ProductRepository.Add(new Product() { Id = 1, ProductName = "Product1", CategoryID = 1 });
        var savedItemsCount = await unitOfWork.SaveAsync();

        //Assert
        Assert.AreEqual(2, savedItemsCount);
    }

    private static IServiceCollection ConfigureServices(IServiceCollection serviceCollection, [CallerMemberName] string callerMemberName = "") =>
        serviceCollection.AddPooledDbContextFactory<ProductDbContext>(options => options.UseInMemoryDatabase(callerMemberName).EnableSensitiveDataLogging())
                         .AddSingleton<ProductDbContext>()
                         .AddSingleton<DesignPatternsInCSharp.Others.UnitOfWork.UnitOfWork>();
}
