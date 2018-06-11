namespace AdvancedValidatorDemo.AdvancedValidator.Rules
{
	namespace FluentValidation
	{
		using System;
		using System.Collections.Generic;
		using System.Threading;
		using System.Threading.Tasks;
		using Results;

		/// <summary>
		/// Defines a rule associated with a property which can have multiple validators.
		/// </summary>
		public interface IValidationRule
		{
			/// <summary>
			/// The validators that are grouped under this rule.
			/// </summary>
			IEnumerable<IPropertyValidator> Validators { get; }
			/// <summary>
			/// Name of the rule-set to which this rule belongs.
			/// </summary>
			string[] RuleSets { get; set; }

			/// <summary>
			/// Performs validation using a validation context and returns a collection of Validation Failures.
			/// </summary>
			/// <param name="context">Validation Context</param>
			/// <returns>A collection of validation failures</returns>
			IEnumerable<ValidationFailure> Validate(ValidationContext context);

			/// <summary>
			/// Performs validation using a validation context and returns a collection of Validation Failures asynchronoulsy.
			/// </summary>
			/// <param name="context">Validation Context</param>
			/// <param name="cancellation">Cancellation token</param>
			/// <returns>A collection of validation failures</returns>
			Task<IEnumerable<ValidationFailure>> ValidateAsync(ValidationContext context, CancellationToken cancellation);

			/// <summary>
			/// Applies a condition to the rule
			/// </summary>
			/// <param name="predicate"></param>
			/// <param name="applyConditionTo"></param>
			void ApplyCondition(Func<ValidationContext, bool> predicate, ApplyConditionTo applyConditionTo = ApplyConditionTo.AllValidators);

			/// <summary>
			/// Applies a condition to the rule asynchronously
			/// </summary>
			/// <param name="predicate"></param>
			/// <param name="applyConditionTo"></param>
			void ApplyAsyncCondition(Func<ValidationContext, CancellationToken, Task<bool>> predicate, ApplyConditionTo applyConditionTo = ApplyConditionTo.AllValidators);
		}
	}
}