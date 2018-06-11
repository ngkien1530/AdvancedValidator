using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedValidatorDemo.AdvancedValidator.Results;

namespace AdvancedValidatorDemo.AdvancedValidator
{
    public interface IValidator
    {
        ValidationResult Validate(object instance);
        ValidationResult Validate(ValidationContext context);
    }

    public interface IValidator<T> : IValidator
    {
        ValidationResult Validate(T instance);
    }
}
