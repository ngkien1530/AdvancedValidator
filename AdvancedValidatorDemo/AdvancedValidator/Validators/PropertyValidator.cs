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

namespace AdvancedValidator.Validators {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Linq.Expressions;
	using Attributes;
	using Internal;
	using Results;

	public abstract class PropertyValidator : IPropertyValidator {
		private string _errorMessage;

		protected PropertyValidator(string errorMessage)
		{
			_errorMessage = errorMessage;
		}

		//private ResourceMetaData resourceMeta;

		//public Func<object, object> CustomStateProvider { get; set; }

		//public bool SupportsStandaloneValidation { get; set; }

		//public Type ErrorMessageResourceType {
		//	get { return resourceMeta.ResourceType; }
		//}

		//public string ErrorMessageResourceName {
		//	get { return resourceMeta.ResourceName; }
		//}

		//public string ErrorMessageTemplate {
		//	get { return resourceMeta.Accessor(); }
		//}

		public void SetErrorMessage(string errorMessage)
		{
			_errorMessage = errorMessage;
		}


		public virtual IEnumerable<ValidationFailure> Validate(PropertyValidatorContext context) {
			//context.MessageFormatter.AppendPropertyName(context.PropertyDescription);

			if (!IsValid(context)) {
				return new[] { CreateValidationError(context) };
			}

			return Enumerable.Empty<ValidationFailure>();
		}

		protected abstract bool IsValid(PropertyValidatorContext context);

		/// <summary>
		/// Creates an error validation result for this validator.
		/// </summary>
		/// <param name="context">The validator context</param>
		/// <returns>Returns an error validation result.</returns>
		protected virtual ValidationFailure CreateValidationError(PropertyValidatorContext context)
		{
			//context.MessageFormatter.AppendAdditionalArguments(
			//	customFormatArgs.Select(func => func(context.Instance)).ToArray()
			//);

			//string error = context.MessageFormatter.BuildMessage(ErrorMessageTemplate);

			var failure = new ValidationFailure(context.PropertyName, _errorMessage);


			return failure;
		}
	}
}