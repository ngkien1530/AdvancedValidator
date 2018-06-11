using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedValidatorDemo.AdvancedValidator.Results;
using ValidationResult = AdvancedValidatorDemo.AdvancedValidator.Results.ValidationResult;

namespace AdvancedValidatorDemo.AdvancedValidator
{
    public interface IValidator
    {
        ValidationResult Validate(object instance);
        ValidationResult Validate(ValidationContext context);
    }

    public interface IValidator<T> : IValidator
    {
        System.ComponentModel.DataAnnotations.ValidationResult Validate(T instance);
    }
}
