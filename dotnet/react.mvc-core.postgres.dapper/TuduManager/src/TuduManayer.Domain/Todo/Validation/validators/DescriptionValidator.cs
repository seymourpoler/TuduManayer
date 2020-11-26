using System.Collections.Generic;

namespace TuduManayer.Domain.Todo.Validation.validators
{
    internal class DescriptionValidator: IValidation
    {
        public List<Error> Validate(ValidationArgs args)
        {
            var result = new List<Error>();
            if (!string.IsNullOrWhiteSpace(args.Description) &&
                args.Description.Length > Validator.MaximumNumberOfCharacters)
            {
                result.Add(Error.With(nameof(args.Description), ErrorCodes.InvalidLength));
            }

            return result;
        }
    }
}