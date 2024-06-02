using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_10.Models;

[Table("Products")]
public class Product
{
    [Key]
    [Column("PK_product")]
    public int ProductId { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("name")]
    public string ProductName { get; set; }

    [Required]
    [Column("weight", TypeName = "decimal(5,2)")]
    public double ProductWeight { get; set; }

    [Required]
    [Column("width", TypeName = "decimal(5,2)")]
    public double ProductWidth { get; set; }
    
    [Required]
    [Column("height", TypeName = "decimal(5,2)")]
    public double ProductHeight { get; set; }
    
    [Required]
    [Column("depth", TypeName = "decimal(5,2)")]
    public double ProductDepth { get; set; }
    
    public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
    
    public IEnumerable<ProductCategory> ProductsCategories { get; set; }
}