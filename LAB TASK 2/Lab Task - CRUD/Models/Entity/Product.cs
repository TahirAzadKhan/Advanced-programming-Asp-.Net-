using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab_Task___CRUD.Models.Entity
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Provide name")]
        [MinLength(2, ErrorMessage = "Name must be > 2 character")]
        [MaxLength(10, ErrorMessage = "Name should not exceed 10 character")]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        public string Quantity { get; set; }
        public string Description { get; set; }
        public int CartQuantity
        {
            get;
            set;
        }
    }
}