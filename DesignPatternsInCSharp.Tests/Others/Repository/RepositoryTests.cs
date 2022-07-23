using DesignPatternsInCSharp.Others.Repository;
using DesignPatternsInCSharp.Others.Repository.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Tests.Others.Repository;

[TestClass]
public class RepositoryTests
{
    [TestMethod]
    public async Task Repository_FindByAsync_CategoryFoundByName()
    {
        //Arrange
        var dbContextFactory = new DbContextFactoryMock<TrainingDbContext>(nameof(Repository_FindByAsync_CategoryFoundByName));
        var dbContext = dbContextFactory.CreateDbContext();
        _ = await dbContext.Database.EnsureCreatedAsync();
        var categoryRepository = new Repository<Category>(dbContext);

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
}
