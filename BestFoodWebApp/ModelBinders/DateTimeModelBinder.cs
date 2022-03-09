using System.Globalization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BestFoodWebApp.ModelBinders
{
    public class DateTimeModelBinder : IModelBinder
    {
        private readonly string customDateFormat;

        public DateTimeModelBinder(string customDateFormat)
        {
            this.customDateFormat = customDateFormat;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult = bindingContext
               .ValueProvider
               .GetValue(bindingContext.ModelName);

            if (valueResult != ValueProviderResult.None && !String.IsNullOrEmpty(valueResult.FirstValue))
            {
                DateTime actualValue = DateTime.MinValue;
                bool success = false;
                string dateValue = valueResult.FirstValue;

                try
                {
                    actualValue = DateTime.ParseExact(dateValue, customDateFormat, CultureInfo.InvariantCulture);
                    success = true;
                }
                catch (FormatException)
                {
                    try
                    {
                        actualValue = DateTime.Parse(dateValue, new CultureInfo("bg-bg"));
                    }
                    catch (Exception ex)
                    {
                        bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex, bindingContext.ModelMetadata);
                    }
                }
                catch (Exception ex)
                {
                    bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex, bindingContext.ModelMetadata);
                }

                if (success)
                {
                    bindingContext.Result = ModelBindingResult.Success(actualValue);
                }
            }

            return Task.CompletedTask;
        }
    }
}
