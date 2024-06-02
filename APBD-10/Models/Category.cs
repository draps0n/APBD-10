namespace APBD_10.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Categories")]
public class Category
{
    [Key]
    [Column("PK_category")]
    public int CategoryId { get; set; }
    
    [Column("name", TypeName = "varchar(100)")]
    [Required]
    [MaxLength(100)]
    public string CategoryName { get; set; }

    public IEnumerable<ProductCategory> ProductsCategories { get; set; }
}