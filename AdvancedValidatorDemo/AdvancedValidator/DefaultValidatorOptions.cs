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

namespace AdvancedValidator {
	using System;
	using System.Linq;
	using System.Linq.Expressions;
	using Internal;
	using Validators;

	public static class DefaultValidatorOptions
	{
		public static IRuleBuilderOptions<T, TProperty> WithMessage<T, TProperty>
            (this IRuleBuilderOptions<T, TProperty> rule, string errorMessage)
		{
		    return rule.Configure(config => {
		        config.Validator.SetErrorMessage(errorMessage);
		        //funcs
		        //.Select(func => new Func<object, object>(x => func((T)x)));
		        //.ForEach(config.Validator.CustomMessageFormatArguments.Add);
		    });
		}

		//public static IRuleBuilderOptions<T, TProperty> WithMessage<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, string errorMessage, params object[] formatArgs)
		//{
		//	var funcs = ConvertArrayOfObjectsToArrayOfDelegates<T>(formatArgs);
		//	return rule.WithMessage(errorMessage, funcs);
		//}

		//public static IRuleBuilderOptions<T, TProperty> WithMessage<T, TProperty>(this IRuleBuilderOptions<T, TProperty> rule, string errorMessage, params Func<T, object>[] funcs)
		//{
		//	errorMessage.Guard("A message must be specified when calling WithMessage.");

			
		//	return rule.Configure(config => {
		//		config.Validator.SetErrorMessage(errorMessage);

		//		//funcs
		//			//.Select(func => new Func<object, object>(x => func((T)x)));
		//			//.ForEach(config.Validator.CustomMessageFormatArguments.Add);
		//	});
		//}

		//static Func<T, object>[] ConvertArrayOfObjectsToArrayOfDelegates<T>(object[] objects)
		//{
		//	if (objects == null || objects.Length == 0)
		//	{
		//		return new Func<T, object>[0];
		//	}
		//	return objects.Select(obj => new Func<T, object>(x => obj)).ToArray();
		//}
	}
}