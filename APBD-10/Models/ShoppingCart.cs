using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBD_10.Models;

[Table("Shopping_Carts")]
[PrimaryKey(nameof(AccountId), nameof(ProductId))]
public class ShoppingCart
{
    [ForeignKey(nameof(Account))]
    [Column("FK_account", Order = 1)]
    public int AccountId { get; set; }

    public Account Account { get; set; }
    
    [ForeignKey(nameof(Product))]
    [Column("FK_product", Order = 2)]
    public int ProductId { get; set; }

    public Product Product { get; set; }

    [Required]
    [Column("amount")]
    public int Amount { get; set; }
}