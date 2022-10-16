using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProductAppApi.Models
{
    [Table("product", Schema = "dbo")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("product_id")]
        public int ProductId { get; set; }
        [Column("product_name")]
        public string ProductName { get; set; }
        
        [Column("price")]
        public decimal Price { get; set; }
    }
}
