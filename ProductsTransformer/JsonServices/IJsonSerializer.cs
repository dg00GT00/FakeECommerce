namespace ProductsTransformer.JsonServices
{
    public interface IJsonSerializer<T> where T : BaseProducts
    {
        public string GenerateString(T[] obj);
        public T GenerateSingle(string jsonResponse);
        public T[] GenerateArray(string jsonResponse);
    }
}