using AdvancedValidator.Validators;

namespace AdvancedValidator.Rules
{
    public interface IPropertyRuleHelper<T, TProperty> : IPropertyRule<T>
    {
        IPropertyRuleHelper<T, TProperty> SetValidator(IPropertyValidator validator);

        IPropertyRuleHelper<T, TProperty> SetErrorMessage(string errorMessage);
    }
}