﻿using Stoqa.ProductCatalog.Domain.PaginationHandler;

namespace Stoqa.ProductCatalog.Infraestrutura.Interfaces.ServiceContracts;

public interface IPaginationQueryService<T> where T : class
{
    Task<PageList<T>> CreatePaginationAsync(IQueryable<T> source, int pageSize, int pageNumber);
    
    PageList<T> CreatePagination(List<T> source, int pageSize, int pageNumber);
}