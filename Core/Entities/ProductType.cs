using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    [Table("ProductType", Schema = "Dev")]
    public class ProductType : BaseEntity
    {
        public string Name { get; set; }
    }
}