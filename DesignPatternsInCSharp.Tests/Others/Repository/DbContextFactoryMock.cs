using Microsoft.EntityFrameworkCore;
using System;

namespace DesignPatternsInCSharp.Tests.Others.Repository;
internal class DbContextFactoryMock<TContext> : IDbContextFactory<TContext> where TContext : DbContext
{
    private readonly DbContextOptions<TContext> _options;

    public DbContextFactoryMock(string databaseName)
    {
        _options = new DbContextOptionsBuilder<TContext>().UseInMemoryDatabase(databaseName).EnableSensitiveDataLogging().Options;
    }

    public TContext CreateDbContext() => (TContext)Activator.CreateInstance(typeof(TContext), _options);
}