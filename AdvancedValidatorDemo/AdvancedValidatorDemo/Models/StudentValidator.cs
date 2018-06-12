using AdvancedValidator;
using AdvancedValidator.Validators;

namespace AdvancedValidatorDemo.Models
{
    public class StudentValidator : AdvancedValidator<Student>
    {
        public StudentValidator()
        {
            AddRule(x => x.StudentName)
                .SetValidator(new NotEmptyValidator())
                .SetErrorMessage("Student Name is required");


            //   AddRule(x => x.StudentName).NotEmpty().WithMessage("Student Name 2 is required");

            //         AddRule(x => x.StudentDOB).NotEmpty().WithMessage("Student DOB is required");

            //AddRule(x => x.StudentEmailID).NotEmpty().WithMessage("Student EmailID is required");

            //AddRule(x => x.StudentFees).NotEmpty().WithMessage("Student Fees is required");

            //AddRule(x => x.StudentAddress).NotEmpty().WithMessage("Student Address is required");

            AddRule(x => x.Password)
                .SetValidator(new RegularExpressionValidator("^[0-9]{1,12}$"))
                .SetErrorMessage("Regular Expression is not valid, only contain ^[0-9]{1,12}$");

            //AddRule(x => x.ConfirmPassword).NotEmpty().WithMessage("Confirm Password is required");
        }
    }
}