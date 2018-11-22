﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleMVCProject.Web.Models
{
    public class MenuWithAttributes
    {
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Text { get; set; }
        [Display(Name = "Price"), DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [StringLength(10)]
        public string Category { get; set; }
    }
}
