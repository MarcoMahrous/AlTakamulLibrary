using AlTakamulLibrary.Data;
using AlTakamulLibrary.Models;
using AlTakamulLibrary.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlTakamulLibrary.Controllers
{
    public class SubCategoriesController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public SubCategoriesController(ISubCategoryService subCategoryService,ICategoryService categoryService,IMapper mapper)
        {
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
            _mapper = mapper;
        }
        // GET: SubCategoriesController
        public ActionResult Index()
        {
            var item = _mapper.Map<List<SubCategoryFormViewModel>>(_subCategoryService.Get().Result);
            return View(item);
        }

        // GET: SubCategoriesController/Details/5
        public ActionResult Details(int? id)
        {
            if (id is null) return BadRequest();
            var item = _subCategoryService.Get((int)id).Result;
            if (item is null) return NotFound();
            return View(_mapper.Map<SubCategoryFormViewModel>(item));
        }

        // GET: SubCategoriesController/Create
        public ActionResult Create()
        {
            var item = new SubCategoryFormViewModel()
            {
                categories= _categoryService.Get().Result,
            };
            return View(item);
        }

        // POST: SubCategoriesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubCategoryFormViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", model);
                }
                var item = new SubCategory()
                {
                    Name = model.Name,
                    CategoryId = model.CategoryId,
                };
                var result = _subCategoryService.Create(item).Result;
                if (!result.Success) return NotFound();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubCategoriesController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id is null) return BadRequest();
            var item = _mapper.Map<SubCategoryFormViewModel>(_subCategoryService.Get((int)id).Result);
            item.categories = _categoryService.Get().Result;
            if (item is null) return NotFound();
            return View(item);
        }

        // POST: SubCategoriesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SubCategoryFormViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Edit", model);
                }
                var item = _subCategoryService.Get(model.Id).Result;
                item.Name = model.Name;
                item.CategoryId = model.CategoryId;
                var result = _subCategoryService.Update(item).Result;
                if (!result.Success) return NotFound();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SubCategoriesController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id is null) return BadRequest();
            var item = _subCategoryService.Get((int)id).Result;
            if (item is null) return NotFound();
            return View(_mapper.Map<SubCategoryFormViewModel>(item));
        }

        // POST: SubCategoriesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SubCategoryFormViewModel model)
        {
            try
            {
                var item = _subCategoryService.Get(model.Id).Result;
                var result = _subCategoryService.Delete(item).Result;
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
