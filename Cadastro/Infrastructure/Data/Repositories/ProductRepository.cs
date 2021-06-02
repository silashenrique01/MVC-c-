using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces;
using Cadastro.Infrastructure.Data.Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Cadastro.Infrastructure.Data.Repositories
{
    public class ProductRepository : EfRepository<Product>, IProductRepository
    {
        public ProductRepository(RegisterContext dbContext)
            : base(dbContext)
        { }

        public IEnumerable<Product> Get()
        {
            return _dbContext.Products.Include(x => x.Category).Include(x => x.Client);
        }
    }
}
