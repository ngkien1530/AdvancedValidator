using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using AdvancedValidatorDemo.AdvancedValidator.Results;

namespace AdvancedValidatorDemo.AdvancedValidator
{
	public class AdvancedValidator<T>: IValidator<T>
	{
		public ValidationResult Validate(T instance)
		{
			throw new NotImplementedException();
		}

		public ValidationResult Validate(object instance)
		{
			throw new NotImplementedException();
		}

		public ValidationResult Validate(ValidationContext context)
		{
			throw new NotImplementedException();
		}

		public void AddRule()
	}
}