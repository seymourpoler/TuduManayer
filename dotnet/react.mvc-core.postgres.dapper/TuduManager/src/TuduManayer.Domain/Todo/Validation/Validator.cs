using System.Collections.Generic;
using System.Linq;
using TuduManayer.Domain.Todo.Validation.validators;

namespace TuduManayer.Domain.Todo.Validation
{
    public class Validator
    {
        public static int MaximumNumberOfCharacters = 255;
        
        private List<IValidation> validations = new List<IValidation>
        {
            new TitleValidator(),
            new DescriptionValidator()
        };
        
        public List<Error> Validate(ValidationArgs args)
        {
            return validations
                .SelectMany(x => x.Validate(args))
                .ToList();
        }
    }
}