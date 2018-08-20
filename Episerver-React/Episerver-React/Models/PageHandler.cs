using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Episerver_React.Controllers;
using System.Data.Entity;
using System.Web;

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





        public static string AddParam(this string URL ,string paramName, string paramValue)
        {
            string currentURL = URL;
            var uriBuilder = new UriBuilder(currentURL);
            var query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query[paramName] = paramValue;
            uriBuilder.Query = query.ToString();
            currentURL = uriBuilder.ToString();


            return currentURL;
        }

        public static int ToInt(this string word)
        {
            return Convert.ToInt32(word);
        }


        public static int PromoPrice(this Product product)
        {
            if (product.Promotion != null)
            {
                var percent = product.Promotion.PercentAmount
                                               .Remove(product.Promotion.PercentAmount.IndexOf("%"), 1)
                                               .ToInt();
                var p1 = (((double)percent / 100.0) * (double)product.Price);
                var price = (double)product.Price - p1 ;

                return (int)Math.Round(price);
            }
            else
            {
                throw new Exception("No promo for this product");
            }
            
        }


        public static T FirstOr<T>(this IEnumerable<T> source, T defaultValue)
        {
            foreach (T t in source)
                return t;
            return defaultValue;
        }




    }
}