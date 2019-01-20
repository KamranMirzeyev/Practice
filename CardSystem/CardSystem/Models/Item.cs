﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CardSystem.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Photo { get; set; }

        public double Price { get; set; }

        public string Description { get; set; }
    }
}