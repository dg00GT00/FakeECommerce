using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("ProductBrand", Schema = "Dev")]
    public class ProductBrand : BaseEntity
    {
        public string Name { get; set; }
    }
}