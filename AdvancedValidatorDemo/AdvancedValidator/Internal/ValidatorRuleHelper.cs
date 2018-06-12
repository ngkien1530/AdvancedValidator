using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AdvancedValidator.Results;
using AdvancedValidator.Validators;

namespace AdvancedValidator.Internal
{
    public class ValidatorRuleHelper<T, TProperty>: IValidatorRuleHelper<T, TProperty>
    {
        private readonly List<IValidatorRule<T>> _rules = new List<IValidatorRule<T>>();
        
        public ValidatorRuleHelper(Expression<Func<T, TProperty>> expression)
        {
            Model = new PropertyModel<T, TProperty>(expression.GetMember(), expression.Compile(), expression);
        }

        public PropertyModel<T, TProperty> Model { get; }

        public IValidatorRuleHelper<T, TProperty> SetValidator(IPropertyValidator validator)
        {
            validator.Guard("Cannot pass a null validator to SetValidator.");
            var rule = new ValidatorRule<T, TProperty>(Model, validator);
            _rules.Add(rule);
            Validator = validator;
            return this;
        }

        public IValidatorRuleHelper<T, TProperty> SetErrorMessage(string errorMessage)
        {
            Validator.SetErrorMessage(errorMessage);
            return this;
        }

        public IPropertyValidator Validator { get; set; }

        public virtual IEnumerable<ValidatorError> Validate(T instance)
        {
            foreach (var rule in _rules)
            {
                var results = rule.Validate(instance);

                foreach (var result in results) yield return result;
            }
        }
    }
}