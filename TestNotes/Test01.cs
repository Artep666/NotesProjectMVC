using NUnit.Framework;
using ProjectNotes.Controllers;
using ProjectNotes.Data;
using ProjectNotes.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestNotes
{
    class Test01
    {
        [TestCase]
        public void AddShouldNote()
        {
            var note = new Note("note", "This is very important;)!",02-03-22);
            var context = new NoteContext();
            var controller = new NoteController(context);

            controller.Add(note);
        
        }
    }
}
