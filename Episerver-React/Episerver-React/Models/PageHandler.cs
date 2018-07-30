using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Episerver_React.Controllers;
using System.Data.Entity;

namespace Episerver_React.Models
{
    public static class PageHandler
    {

        public static int NumberOfPages(this int items, int itemsOnPage)
        {
            int pages;

            if (items % itemsOnPage == 0)
            {
                pages = items / itemsOnPage - 1;
            }
            else
            {
                pages = items / itemsOnPage;
            }
            return pages;
        }

        public static IEnumerable<Product> ToPage(this DbSet<Product> items, int itemsOnPage, int pageIndex)
        {
            if (itemsOnPage != 0)
            {
                IEnumerable<Product> list = items.OrderBy(p => p.Id).Skip(pageIndex * itemsOnPage).Take(itemsOnPage).ToList();
                return list;
            }
            else
            {
                throw new ArgumentException("Parameter cannot be null", "itemsOnPage");
            }
           
        }

        public static IEnumerable<Product> Search(this DbSet<Product> products, string searchString)
        {
            if (String.IsNullOrWhiteSpace(searchString))
            {
                throw new ArgumentNullException("Parameter cannot be null or a white space", "searchString");
            }
            else
            {
                IEnumerable<Product> searchResult = products.Where(p => p.Name.Contains(searchString)).ToList();
                return searchResult;
            }
        }
    }
}