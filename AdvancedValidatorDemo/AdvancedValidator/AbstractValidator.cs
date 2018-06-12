using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using AdvancedValidator.Internal;
using AdvancedValidator.Results;

namespace AdvancedValidator
{
    public abstract class AbstractValidator<T> : IValidator<T>
    {
        private readonly List<IValidatorRule<T>> _rules = new List<IValidatorRule<T>>();

        ValidatorResult IValidator.Validate(object instance)
        {
            return Validate((T) instance);
        }

        public virtual ValidatorResult Validate(T instance)
        {
            instance.Guard("Cannot pass null to Validate");
            var failures = new List<ValidatorError>();
            foreach (var validator in _rules)
                failures.AddRange(validator.Validate(instance));
            return new ValidatorResult(failures);
        }

        public void AddRule(IValidatorRule<T> rule)
        {
            _rules.Add(rule);
        }

        public IValidatorRuleHelper<T, TProperty> RuleFor<TProperty>(Expression<Func<T, TProperty>> expression)
        {
            expression.Guard("Cannot pass null to RuleFor");
            var ruleBuilder = new ValidatorRuleHelper<T, TProperty>(expression);
            _rules.Add(ruleBuilder);
            return ruleBuilder;
        }
    }
}