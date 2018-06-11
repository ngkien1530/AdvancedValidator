using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedValidatorDemo.AdvancedValidator
{
    interface IValidatorFactory
    {
        IValidator GetValidator(Type type);
    }
}
