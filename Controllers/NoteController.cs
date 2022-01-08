using Microsoft.AspNetCore.Mvc;
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
        public IActionResult NoteView()
        {
            // retrieve all the notes information from the tables.
            IEnumerable<Note> objNoteList = _db.Notes;
            return View(objNoteList);
        }

        public IActionResult CreateProgram()
    {
        return View();
    }
}

