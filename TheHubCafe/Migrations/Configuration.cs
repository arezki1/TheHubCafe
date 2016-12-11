namespace TheHubCafe.Migrations
{
    using System.Data.Entity.Migrations;
    using TheHubCafe.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<TheHubCafe.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TheHubCafe.Models.ApplicationDbContext context)
        {
            context.Orders.AddOrUpdate(p => p.PizzaName,
       new TheHubCafe.Models.Order
       {
           PizzaName = "Debra Garcia",
           SaladName = "1234 Main St",
           PastaName = "Redmond",

       },
          new TheHubCafe.Models.Order
          {
              PizzaName = "Deb Garcia",
              SaladName = "12 Main St",
              PastaName = "Reond",

          });
        }
    }
}
