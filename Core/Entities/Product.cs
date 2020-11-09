using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.BaseEntities;

namespace Core.Entities
{
    [Table("Product", Schema = "Dev")]
    public class Product : BaseProduct
    {
        public int Id { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductBrandId { get; set; }
    }
}