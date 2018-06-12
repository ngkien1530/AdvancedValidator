using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdvancedValidator.Validators
{
	public class RegularExpressionValidator: PropertyValidator
	{
		readonly Func<object, Regex> _regexFunc;

		public RegularExpressionValidator(string expression): base(Constants.DefaultRegularExpressionMessage)
		{
			Expression = expression;

			var regex = new Regex(expression, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(2.0));
			_regexFunc = x => regex;
		}

		public RegularExpressionValidator(string expression, RegexOptions options) : base(Constants.DefaultRegularExpressionMessage)
		{
			Expression = expression;

			var regex = new Regex(expression, options, TimeSpan.FromSeconds(2.0));
			_regexFunc = x => regex;
		}

		protected override bool IsValid(PropertyValidatorContext context)
		{
		    var regex = _regexFunc(context.Instance);

		    if (regex != null && context.PropertyValue != null && !regex.IsMatch((string)context.PropertyValue))
		    {
		        return false;
		    }
		    return true;
		}

		public string Expression { get; }
	}
}
