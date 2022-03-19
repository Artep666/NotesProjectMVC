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

        public List<Note> GetAll()
        {
            using (context = new NoteContext())
            {
                return context.Note.ToList();
            }

        }

        public Note Get(int id)
        {
            using (context = new NoteContext())
            {
                return context.Note.FirstOrDefault(x => x.Id == id);
            }

        }
        public void Add(Note note)
        {
            using (context = new NoteContext())
            {
                this.context.Add(note);
                this.context.SaveChanges();
            }

        }
        public void Update(Note note)
        {
            using (context = new NoteContext())
            {
                var n = this.context.Note.Find(note.Id);

                context.Entry(n);//tuk ima nqkuv problem
                context.SaveChanges();
            }
        }
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

