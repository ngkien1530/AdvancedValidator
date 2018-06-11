using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using AdvancedValidatorDemo.AdvancedValidator.Results;
using ValidationResult = AdvancedValidatorDemo.AdvancedValidator.Results.ValidationResult;

namespace AdvancedValidatorDemo.AdvancedValidator
{
	public class AdvancedValidator<T>: IValidator<T>
	{
		public System.ComponentModel.DataAnnotations.ValidationResult Validate(T instance)
		{
			throw new NotImplementedException();
		}

		public ValidationResult Validate(object instance)
		{
		}

		public ValidationResult Validate(ValidationContext context)
		{
			throw new NotImplementedException();
		}

	    public IRuleBuilderInitial<T, TProperty> RuleFor<TProperty>(Expression<Func<T, TProperty>> expression)
	    {
	        //expression.Guard("Cannot pass null to RuleFor", nameof(expression));
	        var rule = PropertyRule.Create(expression, () => CascadeMode);
	        AddRule(rule);
	        var ruleBuilder = new RuleBuilder<T, TProperty>(rule, this);
	        return ruleBuilder;
	    }
    }
}