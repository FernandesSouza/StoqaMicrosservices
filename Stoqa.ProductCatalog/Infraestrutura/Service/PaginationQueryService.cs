﻿using Microsoft.EntityFrameworkCore;
using Stoqa.ProductCatalog.Domain.PaginationHandler;
using Stoqa.ProductCatalog.Infraestrutura.Interfaces.ServiceContracts;

namespace Stoqa.ProductCatalog.Infraestrutura.Service;

public sealed class PaginationQueryService<T> : IPaginationQueryService<T> where T : class
{
    public async Task<PageList<T>> CreatePaginationAsync(IQueryable<T> source, int pageSize, int pageNumber)
    {
        var count = await source.CountAsync();
        var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).AsNoTracking().ToListAsync();

        return new PageList<T>(items, count, pageNumber, pageSize);
    }
    
    public PageList<T> CreatePagination(List<T> source, int pageSize, int pageNumber)
    {
        var count = source.Count;
        var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        return new PageList<T>(items, count, pageNumber, pageSize);
    }
}