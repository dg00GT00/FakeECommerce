using System.Text.Json.Serialization;

namespace ProductsTransformer.CourseFakeProducts
{
    public class CourseProducts : BaseProducts
    {
        [JsonIgnore] public new string Title { get; set; }

        [JsonIgnore] public new string Image { get; set; }
        public string Name { get; set; }
        public new string Description { get; set; }
        public new decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductBrandId { get; set; }
    }
}