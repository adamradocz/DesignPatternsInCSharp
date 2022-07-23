using DesignPatternsInCSharp.Others.Repository;
using DesignPatternsInCSharp.Others.Repository.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Common;
using System.Threading.Tasks;

namespace DesignPatternsInCSharp.Tests.Others.Repository;

[TestClass]
public class RepositoryTests
{
    [TestMethod]
    public async Task Repository_FindByAsync_CategoryFoundByName()
    {
        //Arrange
        using var connection = CreateSqliteInMemoryDatabase();
        var optionBuilder = CreateSqliteOptionBuilder(connection);
        var dbContextFactory = new DbContextFactoryMock<TrainingDbContext>(optionBuilder.Options);
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

    private static DbContextOptionsBuilder<TrainingDbContext> CreateSqliteOptionBuilder(DbConnection connection)
        => new DbContextOptionsBuilder<TrainingDbContext>().UseSqlite(connection).EnableSensitiveDataLogging();

    /// <summary>
    /// Creates a SQLite in-memory database and opens the connection to it.
    /// EF Core will use an already open connection when one is givenm abd wull never attempt to close it.
    /// So the key to using EF Core with an in-memory SQLITe database is to open the connection before passing it to EF.
    /// From: https://docs.microsoft.com/en-us/ef/core/testing/sqlite
    /// </summary>
    /// <returns></returns>
    private static DbConnection CreateSqliteInMemoryDatabase()
    {
        var connection = new SqliteConnection("Filename=:memory:");

        // The database is created when the connection to it is opened
        // The dadabase is deleted when the connection to it is closed
        connection.Open();

        return connection;
    }
}
