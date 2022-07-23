using Microsoft.EntityFrameworkCore;
using System;

namespace DesignPatternsInCSharp.Tests.Others.Repository;
internal class DbContextFactoryMock<TContext> : IDbContextFactory<TContext> where TContext : DbContext
{
    private readonly DbContextOptions<TContext> _options;

    public DbContextFactoryMock(DbContextOptions<TContext> options)
    {
        _options = options ?? throw new ArgumentNullException(nameof(options));
    }

    public TContext CreateDbContext() => (TContext)Activator.CreateInstance(typeof(TContext), _options);
}