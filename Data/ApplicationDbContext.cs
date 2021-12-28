using Microsoft.EntityFrameworkCore;
using NoteApp.Models;

namespace NoteApp.Data;

    public class ApplicationDbContext :DbContext
    {
        // Configure the application DbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        // Create the tables in the Database.
        public DbSet<Category> Categories { get; set; }
        public DbSet<Note> Notes { get; set; }
    }

