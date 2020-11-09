using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.BaseEntities;

namespace Core.Entities
{
    [Table("ProductType", Schema = "Dev")]
    public class ProductType : BaseProductType
    {
        public int Id { get; set; }

    }
}