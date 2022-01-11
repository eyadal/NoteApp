﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult NoteView()
        {
            IEnumerable<Note> objNoteList = _db.Notes;
            return View(objNoteList);
        }
        // Get
        public IActionResult CreateProgram()
        {
            return View();
        }
        // Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateProgram(Note obj)
        {   // Post and save to the database

        if (ModelState.IsValid) { 
            _db.Notes.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("NoteView");
        }
        return View(obj);
    }
}

