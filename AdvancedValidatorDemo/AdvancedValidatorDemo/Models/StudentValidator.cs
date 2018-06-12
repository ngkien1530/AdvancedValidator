using AdvancedValidator;
using AdvancedValidator.Validators;

namespace AdvancedValidatorDemo.Models
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x => x.StudentName)
                .SetValidator(new NotEmptyValidator())
                .SetErrorMessage("Student Name is required");
            //   RuleFor(x => x.StudentName).NotEmpty().WithMessage("Student Name 2 is required");

            //         RuleFor(x => x.StudentDOB).NotEmpty().WithMessage("Student DOB is required");

            //RuleFor(x => x.StudentEmailID).NotEmpty().WithMessage("Student EmailID is required");

            //RuleFor(x => x.StudentFees).NotEmpty().WithMessage("Student Fees is required");

            //RuleFor(x => x.StudentAddress).NotEmpty().WithMessage("Student Address is required");

            //RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required");

            //RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Confirm Password is required");
        }
    }
}