using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdvancedValidatorDemo.AdvancedValidator.Results
{
    public class ValidationResult
    {
	    public IList<ValidationFailure> Errors { get; set; }

	    public ValidationResult()
	    {
		    Errors = new List<ValidationFailure>();
	    }

		public ValidationResult(IEnumerable<ValidationFailure> errors)
	    {
		    Errors = errors.Where(failure => failure != null).ToList();
	    }
	}
}