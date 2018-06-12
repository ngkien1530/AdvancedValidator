using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AdvancedValidator.Results;
using AdvancedValidator.Rules;

namespace AdvancedValidator
{
    public abstract class AdvancedValidator<T> : IValidator<T>
    {
        private readonly List<IPropertyRule<T>> _rules = new List<IPropertyRule<T>>();

        ValidatorResult IValidator.Validate(object instance)
        {
            return Validate((T) instance);
        }

        public virtual ValidatorResult Validate(T instance)
        {
            var failures = new List<ValidatorError>();
            foreach (var validator in _rules)
                failures.AddRange(validator.Validate(instance));
            return new ValidatorResult(failures);
        }

        public void AddRule(IPropertyRule<T> rule)
        {
            _rules.Add(rule);
        }

        public IPropertyRuleHelper<T, TProperty> RuleFor<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            var ruleBuilder = new PropertyRuleHelper<T, TProperty>(expression);
            _rules.Add(ruleBuilder);
            return ruleBuilder;
        }
    }
}