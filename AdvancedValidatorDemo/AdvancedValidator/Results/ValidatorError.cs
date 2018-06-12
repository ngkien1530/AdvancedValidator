using System;

namespace AdvancedValidator.Results
{
    public class ValidatorError
    {
        public ValidatorError(string propertyName, string error)
        {
            PropertyName = propertyName;
            ErrorMessage = error;
        }

        public string PropertyName { get; }

        public string ErrorMessage { get; }

        public override string ToString()
        {
            return ErrorMessage;
        }
    }
}