using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Episerver_React.Models
{
    public class EPiServerDB : DbContext
    {
        public DbSet<Product> Products { get; set; }

    }
}