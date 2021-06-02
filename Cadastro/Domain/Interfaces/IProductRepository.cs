using Cadastro.Domain.Entities;
using System.Collections.Generic;

namespace Cadastro.Domain.Interfaces
{
   public interface IProductRepository
    {
        Product GetById(int id);
        IEnumerable<Product> Get();
        IEnumerable<Product> GetAll();
        void Insert(Product client);
        void Update(Product client);
        void Delete(int id);
    }
}
