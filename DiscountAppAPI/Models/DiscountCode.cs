using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscountAppAPI.Models
{
    [Table("discount", Schema = "dbo")]
    public class DiscountCode
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("discount_id")]
        public int DiscountId { get; set; }
        [Column("order_id")]
        public int OrderId { get; set; }
        [Column("discount")]
        public decimal Discount { get; set; }
    }
}
