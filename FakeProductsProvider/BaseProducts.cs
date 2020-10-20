namespace FakeProductsProvider
{
    /// <summary>
    /// The default base product for all fake products class providers
    /// </summary>
    public class BaseProducts
    {
        public string? Title { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
    }
}