using FakeProductsProvider;
using FakeProductsProvider.JsonServices;

namespace Tests.FakeProductsProviderTests.BaseSourceTests
{
    public class DefaultJsonSerializer
    {
        protected IJsonSerializer<BaseProducts> JsonSerializer { get; } = new JsonSerializerManager<BaseProducts>();
    }
}