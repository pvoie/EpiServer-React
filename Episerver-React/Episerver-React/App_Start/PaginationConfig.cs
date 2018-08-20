using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Episerver_React.Models;

namespace Episerver_React.App_Start
{
    public class PaginationConfig        
    {
        public static List<PaginationModel> Rules = new List<PaginationModel>();

        public static void PaginationRegister(List<PaginationModel> paginations)
        {
            paginations.Add(new PaginationModel { ItemsOnPage = 12, PageName = "Default", Area = "" });
            paginations.Add(new PaginationModel { ItemsOnPage = 9, PageName = "Products/Index" });
        }
    }
}