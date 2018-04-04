using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebSite.Models;

namespace WebSite.Models
{
    public class Item
    {
        public Product product { get; set; }    //display products
        [DisplayName("Quantity")]
        public int quantity { get; set; }       //quantity in cart

        //Products Data
        [Required(ErrorMessage = "Please enter product name")]
        [DisplayName("Product Name")]
        public string productName { get; set; }     
        [DisplayName("Brand")]
        public int brandID { get; set; }
        [Required(ErrorMessage = "Please enter price")]
        [DisplayName("Price")]
        public int price { get; set; }
        [Required(ErrorMessage = "Please enter product name")]
        [DisplayName("Description")]
        public string description { get; set; }
        [DisplayName("Photo")]
        public string photo { get; set; }
    }
}