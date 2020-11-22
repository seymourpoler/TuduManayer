using System.Collections.Generic;

namespace TuduManayer.Domain.Todo.Validation
{
    public class Validator
    {
        public static int MaximumNumberOfCharacters = 255;
        
        public List<Error> Validate(ValidationArgs args)
        {
            var result = new List<Error>();
            
            if (string.IsNullOrWhiteSpace(args.Title))
            {
                result.Add(Error.With(nameof(args.Title), ErrorCodes.Required));
            }
            else if (args.Title.Length > MaximumNumberOfCharacters)
                result.Add(Error.With(nameof(args.Title), ErrorCodes.InvalidLength));

            if (!string.IsNullOrWhiteSpace(args.Description) && args.Description.Length > MaximumNumberOfCharacters)
                result.Add(Error.With(nameof(args.Description), ErrorCodes.InvalidLength));

            return result;
        }
    }
}