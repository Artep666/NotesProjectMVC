using System;
using System.Collections.Generic;
using System.Text;
using ProjectNotes.Data;
using ProjectNotes.Data.Models;
using System.Linq;

namespace ProjectNotes.Controllers
{
     public class NoteController
     {
        private NoteContext context;

        public NoteController()
        {

        }

        public NoteController(NoteContext context)
        {
            this.context = context;
        }
          // List All Recorded in the database notes
        public List<Note> GetAll()
        {
            using (context = new NoteContext())
            {
                return context.Note.ToList();
            }

        }
        // Fetch a note from the database by Id
        public Note Get(int id)
        {
            using (context = new NoteContext())
            {
                return context.Note.FirstOrDefault(x => x.Id == id);
            }

        }
         // Add a product to the database
        public void Add(Note note)
        {
            using (context = new NoteContext())
            {
                this.context.Add(note);
                this.context.SaveChanges();
            }

        }
         // Update a single note in the database by Id.
        public void Update(Note note)
        {
            using (context = new NoteContext())
            {
                var n = this.context.Note.Find(note.Id);

                context.Entry(n).CurrentValues.SetValues(note);
                context.SaveChanges();
            }
        }
          // Deleate a note from the database by Id.
        public void Delete(int id)
        {
            using (context = new NoteContext())
            {
                var note = context.Note.Find(id);
                if (note != null)
                {
                    context.Note.Remove(note);
                    context.SaveChanges();
                }
            }
        }
    }
}

