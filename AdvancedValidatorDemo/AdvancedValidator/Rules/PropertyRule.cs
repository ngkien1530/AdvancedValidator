using System.Collections.Generic;
using System.Reflection;
using AdvancedValidator.Results;
using AdvancedValidator.Validators;

namespace AdvancedValidator.Rules
{
    public class PropertyRule<T, TProperty> : IPropertyRule<T>
    {
        private readonly PropertyModel<T, TProperty> _model;

        public PropertyRule(PropertyModel<T, TProperty> propertyModel, IPropertyValidator validator)
        {
            _model = propertyModel;
            Validator = validator;
        }

        public string PropertyName
        {
            get => _model.PropertyName;
            set => _model.PropertyName = value;
        }

        public MemberInfo Member => _model.Member;

        public IPropertyValidator Validator { get; set; }

        public IEnumerable<ValidatorError> Validate(T instance)
        {
            var validationContext =
                new PropertyValidatorContext(instance, _model.PropertyName, _model.PropertyFunc(instance), Member);
            return Validator.Validate(validationContext);
        }
    }
}