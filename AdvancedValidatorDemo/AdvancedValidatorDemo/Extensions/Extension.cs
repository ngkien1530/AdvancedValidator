using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace AdvancedValidatorDemo.Extensions
{
    public static class Extension
    {
        public static MvcHtmlString MyValidationMessagesFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null)
        {
            var propertyName = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData).PropertyName;
            var modelState = htmlHelper.ViewData.ModelState;

            // If we have multiple (server-side) validation errors, collect and present them.
            if (modelState.ContainsKey(propertyName) && modelState[propertyName].Errors.Count > 1)
            {
                var msgs = new StringBuilder();
                foreach (var error in modelState[propertyName].Errors)
                {
                    msgs.Append(error.ErrorMessage + " | ");
                }

                // Return standard ValidationMessageFor, overriding the message with our concatenated list of messages.
                return htmlHelper.ValidationMessageFor(expression, msgs.ToString(), htmlAttributes as IDictionary<string, object> ?? htmlAttributes);
            }

            // Revert to default behaviour.
            return htmlHelper.ValidationMessageFor(expression, null, htmlAttributes as IDictionary<string, object> ?? htmlAttributes);
        }
    }
}