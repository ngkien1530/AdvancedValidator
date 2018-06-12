using System;

namespace AdvancedValidator.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ValidatorAttribute : Attribute
    {
        public ValidatorAttribute(Type validatorType)
        {
            ValidatorType = validatorType;
        }

        public Type ValidatorType { get; }
    }
}