namespace Episerver_React.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Episerver_React.Models;
    using System.Collections;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Episerver_React.Models.EPiServerDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Episerver_React.Models.EPiServerDB context)
        {
            //var cat = new Category { Name = "Women", Description = "Women's shoes" };
            
            ////var catList = new List<Category>();
            ////catList.Add(cat);
            //var sub = new SubCategory { Name = "Fitness"};

            //cat.SubCategories.Add(sub);
            //sub.Categories.Add(cat);
            ////var subcatList = new List<SubCategory>();
            ////subcatList.Add(sub);






            //context.SubCategories.AddOrUpdate(sub);
            //context.Categories.AddOrUpdate(cat);

            ////context.Categories.AddOrUpdate(new Category
            ////{
            ////    Name = "Men",
            ////    Description = "Men's shoes",
            ////    SubCategories = subcatList
            ////    //Size = "43",
            ////    //Price = 110,
            ////    //Image = "~/images/adidas1.JPG"
            ////});

        }
    }
}
