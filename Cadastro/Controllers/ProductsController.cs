using Cadastro.Interfaces;
using Cadastro.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cadastro.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductViewModelService _productViewModelService;
        private readonly IClientViewModelService _clientViewModelService;
        private readonly ICategoryViewModelService _categoryViewModelService;

        public ProductsController(IProductViewModelService productViewModelService, IClientViewModelService clientViewModelService, ICategoryViewModelService categoryViewModelService)
        {
            _productViewModelService = productViewModelService;
            _clientViewModelService = clientViewModelService;
            _categoryViewModelService = categoryViewModelService;
        }

        public ActionResult Index()
        {
            var list = _productViewModelService.GetAll();
            foreach ( var item in list)
            {
                var client = _clientViewModelService.Get(item.IdClient);

                item.ClientName = client.Name;                    
            }

            return View(list);
        }

        public ActionResult Details(int id)
        {
            var viewModel = _productViewModelService.Get(id);

            viewModel.ClientName = _clientViewModelService.Get(viewModel.IdClient).Name;
            viewModel.CategoryName = _categoryViewModelService.Get(viewModel.IdCategory).Name;

            return View(viewModel);
        }

        public ActionResult Create()
        {
            var productViewModel = new ProductViewModel();
            productViewModel.ClientViewModels = new List<SelectListItem>();
            productViewModel.CategoryViewModels = new List<SelectListItem>();

            var clientsViewModel = _clientViewModelService.GetAll();
            var categoriesViewModel = _categoryViewModelService.GetAll();

            foreach (var client in clientsViewModel)
            {
                productViewModel.ClientViewModels.Add(
                    new SelectListItem
                    {
                        Text = client.Name,
                        Value = client.Id.ToString()
                    });

            }

            foreach (var category in categoriesViewModel)
            {
                productViewModel.CategoryViewModels.Add(
                    new SelectListItem
                    {
                        Text = category.Name,
                        Value = category.Id.ToString()
                    });

            }

            return View(productViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel viewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _productViewModelService.Insert(viewModel);

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch (Exception ex)
            {
                return View(viewModel);
            }
        }

        public ActionResult Edit(int id)
        {

            var viewModel = _productViewModelService.Get(id);
            viewModel.ClientViewModels = new List<SelectListItem>();
            viewModel.CategoryViewModels = new List<SelectListItem>();

            var clientsViewModel = _clientViewModelService.GetAll();
            var categoriesViewModel = _categoryViewModelService.GetAll();

            foreach (var client in clientsViewModel)
            {
                viewModel.ClientName = client.Name;
                viewModel.ClientViewModels.Add(
                    new SelectListItem
                    {
                        Text = client.Name,
                        Value = client.Id.ToString()
                    });
            }


            foreach (var category in categoriesViewModel)
            {
                viewModel.CategoryViewModels.Add(
                    new SelectListItem
                    {
                        Text = category.Name,
                        Value = category.Id.ToString()
                    });

            }

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProductViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productViewModelService.Update(viewModel);

                    return RedirectToAction(nameof(Index));
                }
                return View(viewModel);
            }
            catch (Exception ex)
            {
                return View(viewModel);
            }
        }

        public ActionResult Delete(int id)
        {
            var viewModel = _productViewModelService.Get(id);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _productViewModelService.Delete(id);

                    return RedirectToAction(nameof(Index));
                }

                var viewModel = _productViewModelService.Get(id);
                return View(viewModel);
            }
            catch
            {
                var viewModel = _productViewModelService.Get(id);
                return View(viewModel);
            }
        }
    }
}
