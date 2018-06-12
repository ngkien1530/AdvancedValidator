using System;
using System.Linq.Expressions;
using System.Reflection;

namespace AdvancedValidator
{
    public class PropertyModel<T, TProperty>
    {
        public PropertyModel(MemberInfo member, Func<T, TProperty> propertyFunc, Expression expression)
        {
            Member = member;
            PropertyFunc = propertyFunc;
            Expression = expression;

            PropertyName = member.Name;
        }

        public MemberInfo Member { get; }
        public Func<T, TProperty> PropertyFunc { get; }
        public Expression Expression { get; }

        public string PropertyName { get; set; }
    }
}