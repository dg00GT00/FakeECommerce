using System.Collections.Generic;
using System.Threading.Tasks;
using FakeProductsProvider;
using FakeProductsProvider.BaseFakeProductsApi;

namespace Tests.FakeProductsProviderTests.BaseSourceTests
{
    public class GetTestBaseProduct<T> : IFakeProductsAsync<T> where T : BaseProducts
    {
        private readonly List<T> _sinkProductList = new List<T>();

        /// <summary>
        /// Fake implementation of IFakeProductAsync
        /// </summary>
        /// <param name="sinkBaseProduct">A derived BaseProducts class for charging this fake class</param>
        public GetTestBaseProduct(T sinkBaseProduct)
        {
            _sinkProductList.Add(sinkBaseProduct);
        }

        /// <summary>
        /// Simply returns the derived BaseProducts class injected in the constructor
        /// wrapped into an enumerable
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<T>> GetProductsAsync()
        {
            return Task.FromResult((IEnumerable<T>) _sinkProductList);
        }

        public Task<T> GetProductAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}