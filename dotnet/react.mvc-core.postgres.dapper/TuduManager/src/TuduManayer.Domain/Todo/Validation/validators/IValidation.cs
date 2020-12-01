using System.Collections.Generic;

namespace TuduManayer.Domain.Todo.Validation.validators
{
    internal interface IValidation
    {
        List<Error> Validate(ValidationArgs args);
    }
}