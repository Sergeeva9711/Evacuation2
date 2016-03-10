namespace Evacuation.Dal.Migrations
{
    using Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Evacuation.Dal.Context.UserContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Evacuation.Dal.Context.UserContext context)
        {
            context.Users.Add(new User { FirstName = "Sasha", LastName = "Serhieva", Age = 18, Email = "2857sasha2661@mail.ru", UserName = "Admin", Password = "arctur199711", ConfirmPassword = "arctur199711" });
            context.SaveChanges();
        }
    }
}
