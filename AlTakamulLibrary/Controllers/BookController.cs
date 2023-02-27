using AlTakamulLibrary.Data;
using AlTakamulLibrary.Models;
using AlTakamulLibrary.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlTakamulLibrary.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public BookController(IBookService bookService,ICategoryService categoryService,ISubCategoryService subCategoryService,IAuthorService authorService,IMapper mapper)
        {
            _bookService = bookService;
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _authorService = authorService;
            _mapper = mapper;
        }
        // GET: BookController
        public ActionResult Index()
        {
            return View(_mapper.Map<List<BookFormViewModel>>(_bookService.Get().Result));
        }

        // GET: BookController/Details/5
        public ActionResult Details(int? id)
        {
            if (id is null) return BadRequest();
            var book = _bookService.Get((int)id).Result;
            if (book == null) return NotFound();
            return View(book);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            var model = new BookFormViewModel()
            {
                Authors= _authorService.Get().Result,
                Categories = _categoryService.Get().Result,
            };
            return View(model);
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            var book = _mapper.Map<Book>(model);
            var result = _bookService.Create(book).Result;
            if (!result.Success) return NotFound();
            return RedirectToAction(nameof(Index));
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id is null) return BadRequest();
            var book = _mapper.Map<BookFormViewModel>(_bookService.Get((int)id).Result);
            if (book == null) return NotFound();
            ViewBag.Author = _authorService.Get().Result;
            ViewBag.Category = _categoryService.Get().Result;
            book.SubCategories = _subCategoryService.Get().Result.Where(x => x.CategoryId == book.BookCategory!.CategoryId).ToList();
            return View(book);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, BookFormViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Edit", model);
                }
                var book = _bookService.Get(model.Id).Result;
                book.BookCategoryId = model.BookCategoryId;
                book.AuthorId = model.AuthorId;
                book.Name = model.Name;
                book.Description = model.Description;
                var result = _bookService.Update(book).Result;
                if (!result.Success) return NotFound();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id is null) return BadRequest();
            var book = _bookService.Get((int)id).Result;
            if (book == null) return NotFound();
            return View(book);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, BookFormViewModel model)
        {
            try
            {

                var book = _bookService.Get(model.Id).Result;
                var result = _bookService.Delete(book).Result;
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
