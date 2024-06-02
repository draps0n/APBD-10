using APBD_10.Models;

namespace APBD_10.ResponseModels;

public class PostProductResponseModel
{
    public int ProductId { get; set; }
    
    public string ProductName { get; set; }

    public decimal ProductWeight { get; set; }

    public decimal ProductWidth { get; set; }

    public decimal ProductHeight { get; set; }

    public decimal ProductDepth { get; set; }

    public IEnumerable<string> ProductCategories { get; set; }
}