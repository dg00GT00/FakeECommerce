using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.OrderAggregate
{
    [Table("ProductItemOrdered", Schema = "Dev")]
    public class ProductItemOrdered
    {
        // To Entity Framework requirements
        public ProductItemOrdered()
        {
        }

        // Obs: Populating the properties through constructor is optional
        // when instantiating a new class
        public ProductItemOrdered(int productItemId, string productName, string pictureUrl)
        {
            ProductItemId = productItemId;
            ProductName = productName;
            PictureUrl = pictureUrl;
        }

        public int ProductItemId { get; set; }
        public string ProductName { get; set; }
        public string PictureUrl { get; set; }
    }
}