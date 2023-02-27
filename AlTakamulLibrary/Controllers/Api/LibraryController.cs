using AlTakamulLibrary.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlTakamulLibrary.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IBookService _bookService;

        public LibraryController(IAuthorService authorService,ICategoryService categoryService,ISubCategoryService subCategoryService,IBookService bookService)
        {
            _authorService = authorService;
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _bookService = bookService;
        }
        [HttpGet, Route("getAuthor")]
        public async Task<IActionResult> GetAuthor()
        {

            var list = await _authorService.Get();
            return Ok(list);
        }
        [HttpGet, Route("getCategory")]
        public async Task<IActionResult> GetCategory()
        {

            var list = await _categoryService.Get();
            return Ok(list);
        }
        [HttpGet, Route("getSubCategory")]
        public async Task<IActionResult> GetSubCategory()
        {

            var list = await _subCategoryService.Get();
            return Ok(list);
        }
        [HttpGet, Route("getSubCategoryParentId/{id}")]
        public async Task<IActionResult> GetSubCategoryParentId(int id)
        {

            var list = await _subCategoryService.Get();
            return Ok(list.Where(x=> x.CategoryId == id));
        }

        [HttpGet, Route("getBook/{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            if(id < 1) return BadRequest();
            return Ok(await _bookService.GetStoredProcedure(id));
        }
        [HttpGet, Route("getBooks")]
        public async Task<IActionResult> GetBooks()
        {

            
            return Ok(await _bookService.GetStoredProcedure());
        }
    }
}
