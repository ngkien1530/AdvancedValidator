using AdvancedValidator;
using AdvancedValidator.Validators;
using AdvancedValidatorDemo.CustomValidators;

namespace AdvancedValidatorDemo.Models
{
    public class StudentValidator : AdvancedValidator<Student>
    {
        public StudentValidator()
        {
	        AddRule(x => x.StudentName)
				.SetValidator(new NotEmptyValidator())
	            .SetValidator(new LengthValidator(0, 15)).SetErrorMessage("Length should be 1-14")
                .SetValidator(new CharOnlyValidator()).SetErrorMessage("Only char");

            AddRule(x => x.StudentDOB)
                .SetValidator(new NotEmptyValidator())
                .SetValidator(new RegularExpressionValidator("^[0-9]{1,12}$"));

            AddRule(x => x.StudentEmail)
		        .SetValidator(new NotEmptyValidator());

	        AddRule(x => x.StudentFees)
		        .SetValidator(new NotEmptyValidator());

	        AddRule(x => x.StudentAddress)
		        .SetValidator(new NotEmptyValidator());

            AddRule(x => x.Password)
                .SetValidator(new NotEmptyValidator());

	        AddRule(x => x.ConfirmPassword)
		        .SetValidator(new NotEmptyValidator());
        }
    }
}