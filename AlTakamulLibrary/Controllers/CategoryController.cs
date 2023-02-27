using AlTakamulLibrary.Data;
using AlTakamulLibrary.Models;
using AlTakamulLibrary.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlTakamulLibrary.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        // GET: CategoryController
        public ActionResult Index()
        {
            return View(_categoryService.Get().Result);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            var category = _categoryService.Get(id).Result;
            if (category == null) return NotFound();
            return View(_mapper.Map<CategoryFormViewModel>(category));
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryFormViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", model);
                }
                var category = new Category()
                {
                    Name = model.Name,
                };
                var result = _categoryService.Create(category).Result;
                if (!result.Success) return NotFound();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return BadRequest();
            var category = _categoryService.Get((int)id).Result;
            if (category == null) return NotFound();
            return View(_mapper.Map<CategoryFormViewModel>(category));
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryFormViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Edit", model);
                }
                var category = _categoryService.Get(model.Id).Result;
                category.Name = model.Name;
                var result = _categoryService.Update(category).Result;
                if (!result.Success) return NotFound();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null) return BadRequest();
            var category = _categoryService.Get((int)id).Result;
            if (category == null) return NotFound();
            return View(_mapper.Map<CategoryFormViewModel>(category));
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CategoryFormViewModel model)
        {
            try
            {

                var category = _categoryService.Get(model.Id).Result;
                var result = _categoryService.Delete(category).Result;
                if (!result.Success) return NotFound();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
