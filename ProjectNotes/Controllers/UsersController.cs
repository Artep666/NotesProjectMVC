using System;
using System.Collections.Generic;
using System.Text;
using ProjectNotes.Data;
using ProjectNotes.Data.Models;
using System.Linq;

namespace ProjectNotes.Controllers
{
   public class UsersController
    {
        private UserContext context;

        public UsersController()
        {

        }
        public List<User> GetAllUsers()
        {
            using (context = new UserContext())
            {
                return context.User.ToList();
            }

        }

        public User GetUserss(int id)
        {
            using (context = new UserContext())
            {
                return context.User.FirstOrDefault(x => x.Id == id);
            }

        }
        public void AddUsers(User user)
        {
            using (context = new UserContext())
            {
                this.context.Add(user);
                this.context.SaveChanges();
            }

        }

        public void UpdateUser(User user)
        {
            using (context = new UserContext())
            {
                var p = this.context.User.Find(user.Id);

                context.Entry(p);
                context.SaveChanges();


            }

        }
        public void DeleteUsers(int id)
        {
            using (context = new UserContext())
            {
                var user = context.User.Find(id);
                if (user != null)
                {
                    context.User.Remove(user);
                    context.SaveChanges();
                }
            }
        }
    }
}

