using System.Collections.Generic;
using System.Linq;

namespace TuduManayer.Domain
{
    public class ServiceExecutionResult
    {
        public bool IsOk => !errors.Any();
        
        public IReadOnlyList<Error> Errors => errors.AsReadOnly();
        
        private List<Error> errors;

        private ServiceExecutionResult()
        {
            errors = new List<Error>();
        }
        
        private ServiceExecutionResult(List<Error> errors)
        {
            this.errors = errors;
        }

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