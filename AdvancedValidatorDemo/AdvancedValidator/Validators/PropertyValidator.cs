using System.Collections.Generic;
using System.Linq;
using AdvancedValidator.Results;

namespace AdvancedValidator.Validators
{
    public abstract class PropertyValidator : IPropertyValidator
    {
        private string _errorMessage;

        protected PropertyValidator(string errorMessage)
        {
            _errorMessage = errorMessage;
        }

		public void SetErrorMessage(string errorMessage)
        {
            _errorMessage = errorMessage;
        }

        //Template method: 
        protected abstract bool IsValid(PropertyValidatorContext context);

        public virtual IEnumerable<ValidatorError> Validate(PropertyValidatorContext context)
        {
            if (!IsValid(context)) return new[] {CreateValidationError(context)};

            return Enumerable.Empty<ValidatorError>();
        }


        protected virtual ValidatorError CreateValidationError(PropertyValidatorContext context)
        {
            var failure = new ValidatorError(context.PropertyName, _errorMessage);

            return failure;
        }
    }
}