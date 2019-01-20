using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CardSystem.Models
{
    public class CardSystemContext:DbContext
    {
        public CardSystemContext():base("CardSystemContext")
        {
            
        }

       public DbSet<Item> Items { get; set; }
    }
}