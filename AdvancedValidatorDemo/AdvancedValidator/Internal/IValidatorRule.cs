using System.Collections.Generic;
using AdvancedValidator.Results;
using AdvancedValidator.Validators;

namespace AdvancedValidator.Internal
{
    public interface IValidatorRule<in T>
    {
        IPropertyValidator Validator { get; set; }

        IEnumerable<ValidatorError> Validate(T instance);
    }
}