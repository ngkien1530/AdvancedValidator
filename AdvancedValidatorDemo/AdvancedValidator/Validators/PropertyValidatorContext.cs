using System.Reflection;

namespace AdvancedValidator.Validators
{
    public class PropertyValidatorContext
    {
        private object _propertyValue;
        private bool _propertyValueSet;

        public PropertyValidatorContext(object instance, string propertyName, object propertyValue)
            : this(instance, propertyName, propertyValue, null)
        {
            Instance = instance;
            PropertyValue = propertyValue;
            PropertyName = propertyName;
        }

        public PropertyValidatorContext(object instance, string propertyName, object propertyValue,
            MemberInfo member)
        {
            Instance = instance;
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            Member = member;
        }

        public MemberInfo Member { get; }
        public object Instance { get; }
        public string PropertyName { get; }

        //Lazy loading
        public object PropertyValue
        {
            get
            {
                if (!_propertyValueSet)
                {
                    _propertyValue = Instance;
                    _propertyValueSet = true;
                }

                return _propertyValue;
            }
            set
            {
                _propertyValue = value;
                _propertyValueSet = true;
            }
        }
    }
}