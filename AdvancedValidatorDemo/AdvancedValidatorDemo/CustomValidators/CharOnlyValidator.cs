using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using AdvancedValidator.Validators;

namespace AdvancedValidatorDemo.CustomValidators
{
	public class CharOnlyValidator: RegularExpressionValidator
	{
		private const string CharOnlyRegex = "^[a-zA-Z]*$";
		public CharOnlyValidator() : base(CharOnlyRegex)
		{
		}
	}
}