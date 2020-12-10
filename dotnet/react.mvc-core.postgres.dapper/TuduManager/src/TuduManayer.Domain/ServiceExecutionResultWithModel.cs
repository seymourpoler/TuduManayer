namespace TuduManayer.Domain
{
    public class ServiceExecutionResultWithModel<T> where T : class
    {
        public bool IsOk { get; private set; }
        
        private  ServiceExecutionResultWithModel(bool hasErrors)
        {
            IsOk = !hasErrors;
        }

        public static ServiceExecutionResultWithModel<T> WitError()
        {
            return new ServiceExecutionResultWithModel<T>(true);
        }
    }
}