using System;
using System.Collections.Generic;
using System.Text;
using ProjectNotes.Data.Models;
using System.Linq;
using ProjectNotes.Data;

namespace ProjectNotes.Controllers
{
   public class UserController
    {
        public UserContext context;

        public UserController()
        {

        }
        internal List<User> GetAllUsers()
        {
            using (context = new UserContext())
            {
                return context.User.ToList();
            }

        }

        internal User GetUsers(int IdUser)
        {
            using (context = new UserContext())
            {
                return context.User.FirstOrDefault(x => x.IdUser == IdUser);
            }

        }
        internal void AddUsers(User user)
        {
            using (context = new UserContext())
            {
                this.context.Add(user);
                this.context.SaveChanges();
            }

        }

        internal void UpdateUsers(User user)
        {
            using (context = new UserContext())
            {
                var p = this.context.User.Find(user.IdUser);

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

