using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SaleApi.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Key, Column(TypeName = "varchar(16)"), MaxLength(50)]
        public string Name { get; set; }
        public string Detail { get; set; }
        public double Price { get; set; }
    }
}
