using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvancedValidatorDemo.AdvancedValidator.Attributes
{
	public class ValidatorAttribute : Attribute
	{
		public Type ValidatorType { get; private set; }

		public ValidatorAttribute(Type validatorType)
		{
			ValidatorType = validatorType;
		}
	}
}