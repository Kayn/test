namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication2.Models;
    using WebApplication2.Models.DBModels;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WebApplication2.Models.ApplicationDbContext";
        }

        protected override void Seed(WebApplication2.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        
            context.Articles.AddOrUpdate(
              p => p.ID,
              new Article {ID=new Guid("46976a8a-547e-4bc9-9e61-18ba46b07721"),Title="Article 1", Content="content 1" },
              new Article {ID= new Guid("46976a8a-547e-4bc9-9e61-18ba46b07722"), Title="Article 2", Content="content 2" },
              new Article {ID= new Guid("46976a8a-547e-4bc9-9e61-18ba46b07723"), Title="Article 3", Content="content 3" },
              new Article {ID= new Guid("46976a8a-547e-4bc9-9e61-18ba46b07724"),Title="Article 4", Content="content 4" },
              new Article {ID=new Guid("46976a8a-547e-4bc9-9e61-18ba46b07725"),Title="Article 5", Content="content 5" },
              new Article {ID=new Guid("46976a8a-547e-4bc9-9e61-18ba46b07726"), Title = "Article 6", Content="content 6" }
            );

        }
    }
}
