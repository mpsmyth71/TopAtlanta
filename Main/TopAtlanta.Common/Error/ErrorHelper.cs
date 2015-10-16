using System;
using System.Web.Mvc;


namespace TopAtlanta.Common
{
    public static class ErrorHelper
    {
        /// <summary>
        /// Adds errors from a <c>RulesException</c> as model errors.
        /// </summary>
        /// <param name="modelState"></param>
        /// <param name="ex"></param>
        public static void AddRuleErrors(this ModelStateDictionary modelState, RulesException ex)
        {
            foreach (var x in ex.Errors)
            {
                modelState.AddModelError(x.PropertyName, x.ErrorMessage);
            }
        }
    }
}
