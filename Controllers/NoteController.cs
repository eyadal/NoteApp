using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NoteApp.Data;
using NoteApp.Models;

namespace NoteApp.Controllers;

public class NoteController : Controller
{
    private readonly ApplicationDbContext _db;
    // this is how i retrieve the data
    public NoteController(ApplicationDbContext db)
    {
        _db = db;
    }
    // retrieve all the notes information from the tables.
    public IActionResult NoteView(string searchNote)
    {
        if(String.IsNullOrEmpty(searchNote))
        {
            IEnumerable<Note> objNoteList = _db.Notes;
            return View(objNoteList);
        }
        else
        {
            IEnumerable<Note> objNoteList = _db.Notes;
            return View(objNoteList.Where(note =>
            note.NoteTitle.ToLower().Contains(searchNote)
            || note.NoteText.ToLower().Contains(searchNote)
            || note.Day.ToLower().Contains(searchNote)));
        }
    }
     
    // Get
    public IActionResult CreateProgram()
    {
        return View();
    }
    // Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    // Post and save to the database
    public IActionResult CreateProgram(Note obj)
    {
        if (obj.NoteTitle == "" && obj.NoteText == "")
        {
            ModelState.AddModelError("NoteTitle NoteText", "Fields can not be empty!");
        }

        // If validation Server Side
        if (ModelState.IsValid)
        {
            _db.Notes.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Note created successfully";
            return RedirectToAction("NoteView");
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
        var noteFromDb = _db.Notes.Find(id);

        // Entity FrameWork core ways
        //var noteFromDbFirst = _db.Notes.FirstOrDefault(c => c.Id == id);
        //var noteFromDbSingle = _db.Notes.SingleOrDefault(c => c.Id == id);
        if (noteFromDb == null)
        {
            return NotFound();
        }
        return View(noteFromDb);
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    // Post and save to the database
    public IActionResult Edit(Note obj)
    {
        if (obj.NoteTitle == "" && obj.NoteText == "")
        {
            ModelState.AddModelError("NoteTitle NoteText", "Fields can not be empty!");
        }

        // Validation Server Side
        if (ModelState.IsValid)
        {
            _db.Notes.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Note updated successfully";
            return RedirectToAction("NoteView");
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
        var noteFromDb = _db.Notes.Find(id);

        // Entity FrameWork core ways
        //var noteFromDbFirst = _db.Notes.FirstOrDefault(c => c.Id == id);
        //var noteFromDbSingle = _db.Notes.SingleOrDefault(c => c.Id == id);
        if (noteFromDb == null)
        {
            return NotFound();
        }
        return View(noteFromDb);
    }
    // Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    // Post and save to the database
    public IActionResult DeletePost(int? id)
    {
        var obj = _db.Notes.Find(id);
        if(obj == null) { 
            return NotFound();
        }
        // Validation Server Side
        _db.Notes.Remove(obj);
        _db.SaveChanges();
        TempData["success"] = "Note deleted successfully";
        return RedirectToAction("NoteView");
      
    }
}


