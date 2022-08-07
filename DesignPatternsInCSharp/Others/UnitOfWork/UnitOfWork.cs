using DesignPatternsInCSharp.Others.Repository.Models;
using DesignPatternsInCSharp.Others.Repository;
using Microsoft.EntityFrameworkCore;
using CommunityToolkit.Diagnostics;
using DesignPatternsInCSharp.Others.Repository.Interfaces;
using DesignPatternsInCSharp.Others.Repository.Data;

namespace DesignPatternsInCSharp.Others.UnitOfWork;

public class UnitOfWork : IDisposable, IAsyncDisposable
{
    private readonly ProductDbContext _context;

    private bool _disposedValue;

    private IRepository<Product>? _productRepository;
    public IRepository<Product> ProductRepository
    {
        get
        {
            _productRepository ??= new Repository<Product>(_context);

            return _productRepository;
        }
    }

    private IRepository<Category>? _categoryRepository;
    public IRepository<Category> CategoryRepository
    {
        get
        {
            _categoryRepository ??= new Repository<Category>(_context);

            return _categoryRepository;
        }
    }

    public UnitOfWork(IDbContextFactory<ProductDbContext> dbContextFactory)
    {
        Guard.IsNotNull(dbContextFactory, nameof(dbContextFactory));

        _context = dbContextFactory!.CreateDbContext();
    }

    public async Task<int> SaveAsync() => await _context.SaveChangesAsync();

    #region IDisposable
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                // Dispose managed state (managed objects)
                _context.Dispose();
            }

            // Guideline:
            // - free unmanaged resources (unmanaged objects) and override finalizer
            // - set large fields to null

            _disposedValue = true;
        }
    }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
    #endregion

    #region IAsyncDisposable
    public async ValueTask DisposeAsync()
    {
        // Perform async cleanup.
        await DisposeAsyncCore();

        // Dispose of unmanaged resources.
        Dispose(false);

        // Suppress finalization.
        GC.SuppressFinalize(this);
    }

    private async ValueTask DisposeAsyncCore() => await _context.DisposeAsync().ConfigureAwait(false);
    #endregion
}