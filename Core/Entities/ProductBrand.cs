using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.BaseEntities;

namespace Core.Entities
{
    [Table("ProductBrand", Schema = "Dev")]
    public class ProductBrand : BaseProductBrand
    {
        public int Id { get; set; }
    }
}