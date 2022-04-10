using BulkyBook.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Model.ViewModels
{
    public class ShoppingCart
    {
        public Product Product { get; set; }
        [Range(1,1000, ErrorMessage ="Please Enter A Value Between 1 And 1000!")]
        public int Count { get; set; }
    }
}
