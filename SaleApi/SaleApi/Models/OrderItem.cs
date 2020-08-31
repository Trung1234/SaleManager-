using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SaleApi.Models
{
    public class OrderItem
    {
        [Key]
        public int ID { set; get; }

        public int OrderID { set; get; }
        public int ProductID { set; get; }

        public int Quantity { set; get; }

        public decimal Price { set; get; }

        public int ColorId { get; set; }

        public int SizeId { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { set; get; }
    }
}
