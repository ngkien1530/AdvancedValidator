using System.Collections.Generic;
using AdvancedValidator.Results;

namespace AdvancedValidator.Validators
{
    //Abstract Factory -> dễ mở rộng
    public interface IPropertyValidator
    {
        IEnumerable<ValidatorError> Validate(PropertyValidatorContext context);

        void SetErrorMessage(string message);
    }
}