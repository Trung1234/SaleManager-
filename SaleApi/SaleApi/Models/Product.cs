using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Column(TypeName = "nvarchar(255)")]
        public string Description { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }
        [ForeignKey("CategoryID")]
        public virtual ProductCategory ProductCategory { set; get; }
    }
}
