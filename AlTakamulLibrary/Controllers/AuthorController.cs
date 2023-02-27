using AlTakamulLibrary.Data;
using AlTakamulLibrary.Models;
using AlTakamulLibrary.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlTakamulLibrary.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }
        // GET: AuthorController
        public ActionResult Index()
        {
            return View(_authorService.Get().Result);
        }

        // GET: AuthorController/Details/5
        public ActionResult Details(int id)
        {
            var author = _authorService.Get(id).Result;
            if(author == null) return NotFound();
            return View(author);
        }

        // GET: AuthorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AuthorFormViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Index", model);
                }
                var author = new Author()
                {
                    Name= model.Name,
                };
                var result = _authorService.Create(author).Result;
                if(!result.Success) return NotFound();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return BadRequest();
            var author = _authorService.Get((int)id).Result;
            if (author == null) return NotFound();
            return View(_mapper.Map<AuthorFormViewModel>(author));
        }

        // POST: AuthorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AuthorFormViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Edit",model);
                }
                var author = _authorService.Get(model.Id).Result;
                author.Name = model.Name;
                var result = _authorService.Update(author).Result;
                if (!result.Success) return NotFound();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthorController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return BadRequest();
            var author = _authorService.Get((int)id).Result;
            if (author == null) return NotFound();
            return View(_mapper.Map<AuthorFormViewModel>(author));
        }

        // POST: AuthorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AuthorFormViewModel model)
        {
            try
            {
                
                var author = _authorService.Get(model.Id).Result;
                var result = _authorService.Delete(author).Result;
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
