using System.Collections.Generic;
using System.Linq;

namespace TuduManayer.Domain
{
    public class ServiceExecutionResult
    {
        private List<Error> errors;

        private ServiceExecutionResult()
        {
            errors = new List<Error>();
        }
        
        private ServiceExecutionResult(List<Error> errors)
        {
            this.errors = errors;
        }

        public bool IsOk => !errors.Any();
        public IReadOnlyCollection<Error> Errors => errors.AsReadOnly();

        public static ServiceExecutionResult WithErrors(List<Error> errors)
        {
            return new ServiceExecutionResult(errors);
        }

        public static ServiceExecutionResult WithSucess()
        {
            return new ServiceExecutionResult();
        }
    }
}