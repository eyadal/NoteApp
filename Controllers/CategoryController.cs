using Microsoft.AspNetCore.Mvc;
using NoteApp.Data;
using NoteApp.Models;

namespace NoteApp.Controllers;

    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        // this is how i retrieve the data
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        // retrieve all the categories information from the tables.
        public IActionResult Index(string searchCategory)
        {
            if (String.IsNullOrEmpty(searchCategory))
            {
            IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList);
            }
            else
            {
                IEnumerable<Category> objCategoryList = _db.Categories;
            return View(objCategoryList.Where(category =>
            category.Workout.ToLower().Contains(searchCategory)
                || category.Workout.ToUpper().Contains(searchCategory)));
            }
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
        // Custom Validation Server Side
        if (obj.Workout == obj.Participant.ToString())
        {
            ModelState.AddModelError("Workout", "Workout name can not be a number.");
        }

        // If validation Server Side
        if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
            TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // Edit
        public IActionResult Edit(int? id)
        {
        if (id == null || id == 0) 
        {
            return NotFound();
        }
            var categoryFromDb = _db.Categories.Find(id);

            // Entity FrameWork core ways
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(c => c.Id == id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(c => c.Id == id);
            if(categoryFromDb == null)
            {
            return NotFound();
            }
            return View(categoryFromDb);
        }

        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        // Post and save to the database
        public IActionResult Edit(Category obj)
        {
            // Custom Validation Server Side
            if (obj.Workout == obj.Participant.ToString() || obj.Participant.ToString() == obj.Workout)
            {
                ModelState.AddModelError("Workout", "Workout name can not be a number.");
            }
            // If validation Server Side
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

    // Delete
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0)
        {
            return NotFound();
        }
        var categoryFromDb = _db.Categories.Find(id);

        // Entity FrameWork core ways
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(c => c.Id == id);
        //var categoryFromDbSingle = _db.Categories.SingleOrDefault(c => c.Id == id);
        if (categoryFromDb == null)
        {
            return NotFound();
        }
        return View(categoryFromDb);
    }

    // Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    // Post and save to the database
    public IActionResult DeletePost(int? id)
    {
        
        var obj = _db.Categories.Find(id);
        if(obj == null)
        { return NotFound();}
        
            _db.Categories.Remove(obj);
            _db.SaveChanges();
        TempData["success"] = "Category deleted successfully";
        return RedirectToAction("Index");
    }
}

