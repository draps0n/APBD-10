using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBD_10.Models;

[Table("Products_Categories")]
[PrimaryKey(nameof(ProductId), nameof(CategoryId))]
public class ProductCategory
{
    [ForeignKey(nameof(Product))]
    [Column("FK_product", Order = 1)]
    public int ProductId { get; set; }

    public Product Product { get; set; }
    
    [ForeignKey(nameof(Category))]
    [Column("FK_category", Order = 2)]
    public int CategoryId { get; set; }

    public Category Category { get; set; }
}