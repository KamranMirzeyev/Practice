using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CookieTest.Models
{
    public class CookieTestContext : DbContext
    {
        public CookieTestContext() : base("CookieTestContext")
        {

        }

        public DbSet<User> Users { get; set; }
    }
}