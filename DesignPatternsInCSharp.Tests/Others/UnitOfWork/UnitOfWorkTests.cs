using DesignPatternsInCSharp.Others.Repository.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using DesignPatternsInCSharp.Tests.Others.Repository;
using Microsoft.EntityFrameworkCore;
using DesignPatternsInCSharp.Others.Repository.Data;

namespace DesignPatternsInCSharp.Tests.Others.UnitOfWork;

[TestClass]
public class UnitOfWorkTests
{
    private readonly ServiceProvider _serviceProvider;

    public UnitOfWorkTests()
    {
        var servicesCollection = new ServiceCollection();
        _serviceProvider = ConfigureServices(servicesCollection).BuildServiceProvider();
        _ = _serviceProvider.GetRequiredService<ProductDbContext>().Database.EnsureCreated();
    }

    [TestMethod]
    public async Task UnitOfWork_AddCategoryAndProduct_BothSaved()
    {
        //Arrange
        using var unitOfWork = _serviceProvider.GetRequiredService<DesignPatternsInCSharp.Others.UnitOfWork.UnitOfWork>();

        Assert.AreEqual(0, (await unitOfWork.CategoryRepository.GetAllAsync()).Count);
        Assert.AreEqual(0, (await unitOfWork.ProductRepository.GetAllAsync()).Count);

        //Act
        unitOfWork.CategoryRepository.Add(new Category() { Id = 1, CategoryName = "CategoryName" });
        unitOfWork.ProductRepository.Add(new Product() { Id = 1, ProductName = "ProductName", CategoryID = 1 });
        _ = await unitOfWork.SaveAsync();

        //Assert
        Assert.AreEqual(1, (await unitOfWork.CategoryRepository.GetAllAsync()).Count);
        Assert.AreEqual(1, (await unitOfWork.ProductRepository.GetAllAsync()).Count);
    }

    private IServiceCollection ConfigureServices(IServiceCollection serviceCollection) =>
        serviceCollection.AddPooledDbContextFactory<ProductDbContext>(options => options.UseInMemoryDatabase(nameof(RepositoryTests)).EnableSensitiveDataLogging())
                         .AddSingleton<ProductDbContext>()
                         .AddSingleton<DesignPatternsInCSharp.Others.UnitOfWork.UnitOfWork>();
}
