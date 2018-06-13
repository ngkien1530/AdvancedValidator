using System.Collections.Generic;
using AdvancedValidator.Results;
using AdvancedValidator.Validators;

namespace AdvancedValidator.Rules
{
    public interface IPropertyRule<in T>
    {
        //Mẫu Brigde ? -> 2 trục khác nhau, lớp này chứa instance lớp kia
        IPropertyValidator Validator { get; set; }

        IEnumerable<ValidatorError> Validate(T instance);
    }
}