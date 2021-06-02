using AutoMapper;
using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces;
using Cadastro.Interfaces;
using Cadastro.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Services
{
    public class CategoryViewModelService : ICategoryViewModelService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryViewModelService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public void Delete(int id)
        {
            _categoryRepository.Delete(id);
        }

        public CategoryViewModel Get(int id)
        {
            var entity = _categoryRepository.GetById(id);
            if (entity == null)
                return null;

            return _mapper.Map<CategoryViewModel>(entity);
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            var list = _categoryRepository.GetAll();
            if (list == null)
                return new CategoryViewModel[] { };

            return _mapper.Map<IEnumerable<CategoryViewModel>>(list);
        }

        public void Insert(CategoryViewModel viewModel)
        {
            var entity = _mapper.Map<Category>(viewModel);

            _categoryRepository.Insert(entity);
        }

        public void Update(CategoryViewModel viewModel)
        {
            var entity = _mapper.Map<Category>(viewModel);

            _categoryRepository.Update(entity);
        }
    }
}
