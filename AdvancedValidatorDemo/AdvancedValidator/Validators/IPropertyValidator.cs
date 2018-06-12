using System.Collections.Generic;
using AdvancedValidator.Results;

namespace AdvancedValidator.Validators
{
    public interface IPropertyValidator
    {
        IEnumerable<ValidatorError> Validate(PropertyValidatorContext context);

        void SetErrorMessage(string message);
    }
}