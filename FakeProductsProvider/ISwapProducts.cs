using System.Collections.Generic;
using System.Threading.Tasks;

namespace FakeProductsProvider
{
    public interface ISwapProducts<TTarget>
    {
        /// <summary>
        /// Swaps the source fake product object for the target fake product
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<TTarget>> SwapAsync();
    }
}