using System;

namespace AdvancedValidator.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ValidatorAttribute : Attribute
    {
        public ValidatorAttribute(IValidator validatorType)
        {
            ValidatorType = validatorType;
        }

        public IValidator ValidatorType { get; }
    }
}