﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class CatItem {
        [Key]
        public string Name { get; set; }

        public string Url { get; set; }
        public CatImage Data { get; set; }
    }
}
