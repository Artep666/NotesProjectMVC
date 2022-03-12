using ProjectNotes.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ProjectNotes.Controllers;

namespace ProjectNotes.Views
{
    class Display
    {
       NoteController noteControler = new NoteController();

        public Display()
        {
            Input();
        }

        public void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "MENU" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1.List all notes");
            Console.WriteLine("2.Add new notes");
            Console.WriteLine("3.Update notes");
            Console.WriteLine("4.Fetch note by ID");
            Console.WriteLine("5.Delete note by ID");
            Console.WriteLine("6.Exit");
        }
        private void Input()
        {
            int closeOperationId = 6;
            var operation = -1;
            do
            {
                ShowMenu();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1: ListAll(); break;
                    case 2: Add(); break;
                    case 3: Update(); break;
                    case 4: Fetch(); break;
                    case 5: Delete(); break;
                    default: break;
                }

            } while (operation != closeOperationId);
        }

        private void Delete()
        {
            Console.WriteLine("Enter ID to delete:");
            int id = int.Parse(Console.ReadLine());

            noteControler.Delete(id);
            Console.WriteLine("Done.");
        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch:");
            int id = int.Parse(Console.ReadLine());
            Note note = noteControler.Get(id);

            if (note != null)
            {
                Console.WriteLine("ID {0}", note.Id);
                Console.WriteLine("Name {0}", note.Name);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Note not found!");
            }
        }

        private void Update()
        {
            Console.WriteLine("Enter id");
            var id = int.Parse(Console.ReadLine());
            Note note = noteControler.Get(id);

            if (note != null)
            {

                Console.WriteLine("Enter name product");
                note.Name = Console.ReadLine();
                Console.WriteLine("Enter description note");
                note.Description = Console.ReadLine();
                Console.WriteLine("Enter Data");
                note.Date = int.Parse(Console.ReadLine());



                noteControler.Update(note);
            }
            else
            {
                Console.WriteLine("Note not found!");
            }
        }

        private void Add()
        {
            Note note = new Note();
            Console.WriteLine("Enter name note");
            string name = Console.ReadLine();
            Console.WriteLine("Enter description note");
            string description = Console.ReadLine();
            Console.WriteLine("Enter date");
            int date = int.Parse(Console.ReadLine());

            note.Name = name;
            note.Description = description;
            note.Date = date;

            noteControler.Add(note);

        }

        private void ListAll()
        {
            Console.WriteLine(new string(' ', 18) + "ALL NOTES" + new string(' ', 18));
            Console.WriteLine();
            var notesAll = noteControler.GetAll();
            foreach (var note in notesAll)
            {
                Console.WriteLine("{0} {1} {2} {3}", note.Id, note.Name, note.Description, note.Date);
            }
        }
    }

}

