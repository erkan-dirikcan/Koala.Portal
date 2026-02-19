using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Koala.Portal.WebApi.Extentions
{
    public static class ModelStateExtention
    {
        public static void AddModelErrorList(this ModelStateDictionary modelState, List<string> errors)
        {
            foreach (var item in errors)
            {
                modelState.AddModelError(string.Empty, item);

            }
        }
    }
}
