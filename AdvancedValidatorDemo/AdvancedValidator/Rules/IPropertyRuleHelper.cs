using AdvancedValidator.Validators;

namespace AdvancedValidator.Rules
{
    public interface IPropertyRuleHelper<T, TProperty> : IPropertyRule<T>
    {
        //Factory Method : IPropertyValidator validator, để lớp xài quyết định khởi tạo nó là gì
        IPropertyRuleHelper<T, TProperty> SetValidator(IPropertyValidator validator);

        IPropertyRuleHelper<T, TProperty> SetErrorMessage(string errorMessage);
    }
}