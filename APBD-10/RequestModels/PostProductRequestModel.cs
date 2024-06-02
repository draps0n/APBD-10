using System.ComponentModel.DataAnnotations;

namespace APBD_10.RequestModels;

public class PostProductRequestModel
{
    [Required]
    [MaxLength(100)]
    public string ProductName { get; set; }
    
    [Required]
    [Range(0.00, 999.99, ErrorMessage = "Value must be between 0.00 and 999.99")]
    public decimal ProductWeight { get; set; }
    
    [Required]
    [Range(0.00, 999.99, ErrorMessage = "Value must be between 0.00 and 999.99")]
    public decimal ProductWidth { get; set; }
    
    [Required]
    [Range(0.00, 999.99, ErrorMessage = "Value must be between 0.00 and 999.99")]
    public decimal ProductHeight { get; set; }
    
    [Required]
    [Range(0.00, 999.99, ErrorMessage = "Value must be between 0.00 and 999.99")]
    public decimal ProductDepth { get; set; }
    
    [Required]
    public IEnumerable<int> ProductCategories { get; set; }
}