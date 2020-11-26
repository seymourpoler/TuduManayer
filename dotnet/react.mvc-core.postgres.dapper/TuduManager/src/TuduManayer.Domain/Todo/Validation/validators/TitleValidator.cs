using System.Collections.Generic;

namespace TuduManayer.Domain.Todo.Validation.validators
{
    internal class TitleValidator: IValidation
    {
        public List<Error> Validate(ValidationArgs args)
        {
            var result = new List<Error>();
            if (string.IsNullOrWhiteSpace(args.Title))
            {
                result.Add(Error.With(nameof(args.Title), ErrorCodes.Required));
            }
            else if (args.Title.Length > Validator.MaximumNumberOfCharacters)
            {
                result.Add(Error.With(nameof(args.Title), ErrorCodes.InvalidLength));
            }

            return result;
        }
    }
}