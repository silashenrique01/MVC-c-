using Cadastro.Interfaces;
using Cadastro.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Controllers
{
    public class CategoriesController : Controller
    {

        private readonly ICategoryViewModelService _categoryViewModelService;

        public CategoriesController(ICategoryViewModelService categoryViewModelService)
        {
            _categoryViewModelService = categoryViewModelService;
        }
        public ActionResult Index()
        {
            var category = _categoryViewModelService.GetAll();

            return View(category);
        }

        public ActionResult Details(int id)
        {

            var category = _categoryViewModelService.Get(id);
            return View(category);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: CagController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryViewModel categoryViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _categoryViewModelService.Insert(categoryViewModel);

                    return RedirectToAction(nameof(Index));
                }
                return View(categoryViewModel);
            }
            catch (Exception ex)
            {

                return View(categoryViewModel);
            }
        }

        // GET: CagController/Edit/5
        public ActionResult Edit(int id)
        {
            var viewModel = _categoryViewModelService.Get(id);
            return View(viewModel);
        }

        // POST: CagController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryViewModel categoryViewModel)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _categoryViewModelService.Update(categoryViewModel);

                    return RedirectToAction(nameof(Index));
                }
                return View(categoryViewModel);
            }
            catch
            {
                return View(categoryViewModel);
            }
        }

        // GET: CagController/Delete/5
        public ActionResult Delete(int id)
        {
            var viewModel = _categoryViewModelService.Get(id);
            return View(viewModel);
        }

        // POST: CagController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                _categoryViewModelService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(collection);
            }
        }
    }
}
