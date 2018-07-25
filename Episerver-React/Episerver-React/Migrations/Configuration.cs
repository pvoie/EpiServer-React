namespace Episerver_React.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Episerver_React.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Episerver_React.Models.EPiServerDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Episerver_React.Models.EPiServerDB context)
        {
            //foreach (var c in "bcdr")
            //{
            //    foreach (var v in "aeiou")
            //    {
            //        foreach (var item in collection)
            //        {

            //        }


            //    }

            //}


            ////for (int i = 0; i < 30; i++)
            ////{
            //    context.Products.AddOrUpdate(new Product { Name = "Tommy "+i.ToString(), Description = "size 43", Price = 110 },
            //    new Product { Name = "Adidas Superstar " + i.ToString(), Description = "size 40", Price = 140 },
            //    new Product { Name = "Reebook P10" + i.ToString(), Description = "size 43", Price = 120 });
            ////}
            context.Products.AddOrUpdate(new Product { Name = "Adidas Superstar Classic", Description = "The full grain leather upper makes these trainers comfortable and soft on your feet.", Size="43" ,Price = 110, Image="~/images/adidas1.JPG" });



        }
    }
}
