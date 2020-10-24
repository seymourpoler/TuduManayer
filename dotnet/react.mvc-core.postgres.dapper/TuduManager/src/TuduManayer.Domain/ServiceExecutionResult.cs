namespace TuduManayer.Domain
{
    public class ServiceExecutionResult
    {
        private bool result;

        private ServiceExecutionResult(bool result)
        {
            this.result = result;
        }

        public bool IsOk => result;

        public static ServiceExecutionResult WithErrors()
        {
            return new ServiceExecutionResult(false);
        }

        public static ServiceExecutionResult WithSucess()
        {
            return new ServiceExecutionResult(true);
        }
    }
}