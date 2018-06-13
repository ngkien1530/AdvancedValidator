using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedValidator.Validators
{
    public class LengthValidator: PropertyValidator
    {
        public int Min { get; private set; }
        public int Max { get; private set; }

        public LengthValidator(int min, int max) : base(Constants.DefaultLengthMessage)
        {
            Max = max;
            Min = min;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue == null)
                return true;

            var length = context.PropertyValue.ToString().Length;

            if (length < Min || (length > Max && Max != -1))
            {
                return false;
            }

            return true;
        }
    }
}
