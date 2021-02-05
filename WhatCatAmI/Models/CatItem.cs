using System.ComponentModel.DataAnnotations;

namespace WhatCatAmI.Models
{
    public class CatItem
    {
        [Key]
        public string Name { get; set; }

        public string Url { get; set; }
    }
}