using Evacuation.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evacuation.Dal.Context
{
    public class UserContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }

        static UserContext()
        {
            Database.SetInitializer<UserContext>(new UserDbInitializer());
        }
        
    }

     class UserDbInitializer : DropCreateDatabaseIfModelChanges<UserContext>
    {
        protected override void Seed(UserContext db)
        {
            db.Users.Add(new User { FirstName = "Sasha", LastName = "Serhieva", Age = 18, Email = "2857sasha2661@mail.ru", UserName = "Admin", Password = "arctur199711", ConfirmPassword = "arctur199711" });
            db.SaveChanges();           
        }
    }
}
