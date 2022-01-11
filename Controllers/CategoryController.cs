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
        // retrieve all the categories information from the tables.
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
        }
        // Get
        public IActionResult Create()
        {
            return View();
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post and save to the database
        public IActionResult Create(Category obj)
        {
            // Custom Validation
            if (obj.Workout == obj.Participant.ToString()) 
            {
                ModelState.AddModelError("Workout","Workout name can not be a number.");
            }
            // If validation
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
