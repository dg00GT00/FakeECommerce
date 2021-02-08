using Core.Entities;

namespace Core.Dtos
{
    /// <summary>
    /// Returns fake product properties for row insertion into a database
    /// </summary>
    public class ProductToInsertionDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? PictureUrl { get; set; }
        public ProductType? ProductType { get; set; }
        public ProductBrand? ProductBrand { get; set; }
    }
}