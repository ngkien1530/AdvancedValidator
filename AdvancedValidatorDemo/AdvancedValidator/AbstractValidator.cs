#region License
// Copyright 2008-2009 Jeremy Skinner (http://www.jeremyskinner.co.uk)
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
// 
// http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License.
// 
// The latest version of this file can be found at http://www.codeplex.com/FluentValidation
#endregion

namespace AdvancedValidator {
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using Internal;
	using Results;
	using Validators;

	/// <summary>
	/// Base class for entity validator classes.
	/// </summary>
	/// <typeparam name="T">The type of the object being validated</typeparam>
	public abstract class AbstractValidator<T> : IValidator<T>//, IEnumerable<IValidationRule<T>>
	{
		readonly List<IValidationRule<T>> nestedValidators = new List<IValidationRule<T>>();

		ValidationResult IValidator.Validate(object instance) {
			return Validate((T)instance);
		}

		ValidationResult IValidator.Validate(ValidationContext context) {
			var genericContext = new ValidationContext<T>((T)context.InstanceToValidate, context.PropertyChain);

			return Validate(genericContext);
		}

		public virtual ValidationResult Validate(T instance) {
			return Validate(new ValidationContext<T>(instance, new PropertyChain()));
		}
		

		public virtual ValidationResult Validate(ValidationContext<T> context)
		{
		    context.Guard("Cannot pass null to Validate");
		    var failures = new List<ValidationFailure>();
		    foreach (var validator in nestedValidators)
		    {
		        failures.AddRange(validator.Validate(context));
		    }
			return new ValidationResult(failures);
		}

		public void AddRule(IValidationRule<T> rule) {
			nestedValidators.Add(new SimpleRuleBuilder<T>(rule));
		}

		public IRuleBuilderInitial<T, TProperty> RuleFor<TProperty>(Expression<Func<T, TProperty>> expression) {
			expression.Guard("Cannot pass null to RuleFor");
			var ruleBuilder = new RuleBuilder<T, TProperty>(expression);
			nestedValidators.Add(ruleBuilder);
			return ruleBuilder;
		}

		//public void Custom(Func<T, ValidationFailure> customValidator) {
		//	customValidator.Guard("Cannot pass null to Custom");
		//	AddRule(new DelegateValidator<T>(x => new[] { customValidator(x) }));
		//}

		//public void Custom(Func<T, ValidationContext<T>, ValidationFailure> customValidator) {
		//	customValidator.Guard("Cannot pass null to Custom");
		//	AddRule(new DelegateValidator<T>((x, ctx) => new[] { customValidator(x, ctx) }));
		//}

		//public IEnumerator<IValidationRule<T>> GetEnumerator() {
		//	return nestedValidators.SelectMany(x => x).ToList().GetEnumerator();
		//}

		//IEnumerator IEnumerable.GetEnumerator() {
		//	return GetEnumerator();
		//}
	}
}