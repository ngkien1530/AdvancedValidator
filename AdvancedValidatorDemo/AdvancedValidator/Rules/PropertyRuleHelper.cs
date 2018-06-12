using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AdvancedValidator.Results;
using AdvancedValidator.Validators;

namespace AdvancedValidator.Rules
{
    public class PropertyRuleHelper<T, TProperty>: IPropertyRuleHelper<T, TProperty>
    {
        private readonly List<IPropertyRule<T>> _rules = new List<IPropertyRule<T>>();
        
        public PropertyRuleHelper(Expression<Func<T, TProperty>> expression)
        {
            Model = new PropertyModel<T, TProperty>(((MemberExpression)expression.Body).Member, expression.Compile(), expression);
        }

        public PropertyModel<T, TProperty> Model { get; }

        public IPropertyRuleHelper<T, TProperty> SetValidator(IPropertyValidator validator)
        {
            var rule = new PropertyRule<T, TProperty>(Model, validator);
            _rules.Add(rule);
            Validator = validator;
            return this;
        }

        public IPropertyRuleHelper<T, TProperty> SetErrorMessage(string errorMessage)
        {
            Validator.SetErrorMessage(errorMessage);
            return this;
        }

        public IPropertyValidator Validator { get; set; }

        public virtual IEnumerable<ValidatorError> Validate(T instance)
        {
	        var results = new List<ValidatorError>();
			foreach (var rule in _rules)
			{
				results.AddRange(rule.Validate(instance));
			}

	        return results;
		}
    }
}