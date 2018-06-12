using System;
using System.ComponentModel.DataAnnotations;

namespace AdvancedValidator.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ValidatorAttribute : ValidationAttribute
	{
        public ValidatorAttribute(Type validatorType, object obj)
        {
            ValidatorType = validatorType;
            var validator = Activator.CreateInstance(validatorType) as IValidator;
	        var result = validator.Validate(obj);

		}

	    public Type ValidatorType { get; }
    }
}