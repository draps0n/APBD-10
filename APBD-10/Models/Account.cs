using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_10.Models;

[Table("Accounts")]
public class Account
{
    [Key]
    [Column("PK_account")]
    public int AccountId { get; set; }

    [Column("FK_role")]
    [ForeignKey(nameof(Role))]
    public int RoleId { get; set; }

    public Role Role { get; set; }
    
    [Column("first_name")]
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [Column("last_name")]
    [Required]
    [MaxLength(50)]
    public string LastName { get; set; }
    
    [Column("email")]
    [EmailAddress]
    [Required]
    [MaxLength(80)]
    public string Email { get; set; }
    
    [Column("phone")]
    [Phone]
    [MaxLength(9)]
    public string? Phone { get; set; }

    public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
}