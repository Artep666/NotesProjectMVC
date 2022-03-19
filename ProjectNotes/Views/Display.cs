using ProjectNotes.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ProjectNotes.Controllers;

namespace ProjectNotes.Views
{
    public class Display
    {
        NoteController noteControler = new NoteController();
        UserController userControler = new UserController();

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
            Console.WriteLine("6.List all users");
            Console.WriteLine("7.Add new users");
            Console.WriteLine("8.Update users");
            Console.WriteLine("9.Fetch user by ID");
            Console.WriteLine("10.Delete user by ID");
  
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
                    case 6: ListAllUser(); break;
                    case 7: AddUser(); break;
                    case 8: UpdateUser(); break;
                    case 9: FetchUser(); break;
                    case 10: DeleteUser(); break;
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

        private void DeleteUser()
        {
            Console.WriteLine("Enter ID to delete:");
            int id = int.Parse(Console.ReadLine());

            userControler.DeleteUsers(id);
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

        private void FetchUser()
        {
            Console.WriteLine("Enter ID to fetch:");
            int id = int.Parse(Console.ReadLine());
            User user = userControler.GetUsers(id);

            if (user != null)
            {
                Console.WriteLine("ID {0}", user.IdUser);
                Console.WriteLine("Name {0}", user.NameUser);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("User not found!");
            }
        }
        private void Update()
        {
            Console.WriteLine("Enter id");
            var id = int.Parse(Console.ReadLine());
            Note note = noteControler.Get(id);

            if (note != null)
            {

                Console.WriteLine("Enter note name");
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

        private void UpdateUser()
        {
            Console.WriteLine("Enter id");
            var id = int.Parse(Console.ReadLine());
            User user = userControler.GetUsers(id);

            if (user != null)
            {

                Console.WriteLine("Enter user name");
                user.NameUser = Console.ReadLine();
                Console.WriteLine("Enter user lastname");
                user.LastName = Console.ReadLine();
                userControler.UpdateUsers(user);
            }
            else
            {
                Console.WriteLine("User not found!");
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
        private void AddUser() 
        {
            User user = new User();
            Console.WriteLine("Enter name user");
            string name = Console.ReadLine();
            Console.WriteLine("Enter description user");
            string lastname = Console.ReadLine();
            Console.WriteLine("Enter date");
          
            user.NameUser = name;
            user.LastName = lastname;
           

            userControler.AddUsers(user);
        
        }
        private void ListAll()
        {
            Console.WriteLine(new string(' ', 18) + "ALL NOTES" + new string(' ', 18));
            Console.WriteLine();
            var notesAll = noteControler.GetAll();
            foreach (var note in notesAll)
            {
                Console.WriteLine("{0} || {1} || {2} || {3}", note.Id, note.Name, note.Description, note.Date);
            }

        }
        private void ListAllUser()
        {
            Console.WriteLine(new string(' ', 18) + "ALL USERS" + new string(' ', 18));
            Console.WriteLine();
            var usersAll = userControler.GetAllUsers();
            foreach (var user in usersAll)
            {
                Console.WriteLine("{0} || {1} || {2}", user.IdUser, user.NameUser, user.LastName);
            }
        }
    }
}

