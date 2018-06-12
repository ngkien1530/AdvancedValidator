namespace AdvancedValidator.Validators
{
    public class NotEmptyValidator : PropertyValidator
    {
        public NotEmptyValidator() : base(Constants.DefaultNotEmptyMessage)
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue == null || context.PropertyValue.Equals(string.Empty)) return false;

            return true;
        }
    }
}