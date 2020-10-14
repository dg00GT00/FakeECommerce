using System;
using System.Threading.Tasks;
using Core.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace eCommerce.Models
{
    public class SortBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            var enumerationName = bindingContext.ValueProvider.GetValue(bindingContext.FieldName);
            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, enumerationName);
            var value = enumerationName.FirstValue;

            if (!string.IsNullOrEmpty(value))
            {
                if (value.Equals("priceAsc"))
                {
                    bindingContext.Result =
                        ModelBindingResult.Success(new SortModel {SortProperty = SortBy.PriceAscending});
                }
                else if (value.Equals("priceDesc"))

                {
                    bindingContext.Result =
                        ModelBindingResult.Success(new SortModel {SortProperty = SortBy.PriceDescending});
                }
                else if (value.Equals("nameAsc"))

                {
                    bindingContext.Result =
                        ModelBindingResult.Success(new SortModel {SortProperty = SortBy.NameAscending});
                }
                else if (value.Equals("nameDesc"))

                {
                    bindingContext.Result =
                        ModelBindingResult.Success(new SortModel {SortProperty = SortBy.NameDescending});
                }
                else
                {
                    bindingContext.ModelState.TryAddModelError(nameof(bindingContext.FieldName),
                        $"The '{value}' is not a valid query string value");
                }
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Failed();

                bindingContext.ModelState.TryAddModelException(nameof(bindingContext.FieldName),
                    new Exception("Null or empty query string"));
            }

            return Task.CompletedTask;
        }
    }
}