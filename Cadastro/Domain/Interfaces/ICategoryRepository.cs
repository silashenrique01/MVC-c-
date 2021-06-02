using Cadastro.Domain.Entities;
using Cadastro.ViewModels;
using System.Collections.Generic;

namespace Cadastro.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Category GetById(int id);
        IEnumerable<Category> GetAll();
        void Insert(Category viewModel);
        void Update(Category viewModel);
        void Delete(int id);
    }
}
