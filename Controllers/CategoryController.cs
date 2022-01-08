using Microsoft.AspNetCore.Mvc;
using NoteApp.Data;
using NoteApp.Models;

namespace NoteApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        // this is how i retrieve the data
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            // retrieve all the categories information from the tables.
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }
            // Get
        public IActionResult Create()
        {
            return View();
        }
    }
}
