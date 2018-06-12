using AdvancedValidator.Validators;

namespace AdvancedValidator.Internal
{
    public interface IValidatorRuleHelper<T, TProperty> : IValidatorRule<T>
    {
        IValidatorRuleHelper<T, TProperty> SetValidator(IPropertyValidator validator);

        IValidatorRuleHelper<T, TProperty> SetErrorMessage(string errorMessage);
    }
}