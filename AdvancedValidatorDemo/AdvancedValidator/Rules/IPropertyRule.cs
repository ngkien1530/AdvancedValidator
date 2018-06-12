using System.Collections.Generic;
using AdvancedValidator.Results;
using AdvancedValidator.Validators;

namespace AdvancedValidator.Rules
{
    public interface IPropertyRule<in T>
    {
        IPropertyValidator Validator { get; set; }

        IEnumerable<ValidatorError> Validate(T instance);
    }
}