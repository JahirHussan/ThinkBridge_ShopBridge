using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ThinkBridge_ShopBridge.Models
{
    public class Products
    {
        public int? ProductID { get; set; }
        [DataType(DataType.Text)]
        [Display(Name="Product Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The product name can not be empty")]
        [StringLength(200)]
        public string Name { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Product Description")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The product description can not be empty")]
        [StringLength(500)]
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        [Required]
        public decimal ProductPrice { get; set; }
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "The product supplier can not be empty")]
        public string SupplierName { get; set; }
        [DataType(DataType.Text)]
        public string ImageURL { get; set; }

    }
}