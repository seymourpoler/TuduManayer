namespace TuduManayer.Domain
{
    public class ServiceExecutionResultWithModel<T> where T : class
    {
        public bool IsOk { get; private set; }
        public T Model { get; private set; }
        
        private  ServiceExecutionResultWithModel(bool hasErrors)
        {
            IsOk = !hasErrors;
        }
        
        private  ServiceExecutionResultWithModel(T model)
        {
            Model = model;
        }

        public static ServiceExecutionResultWithModel<T> WitError()
        {
            return new ServiceExecutionResultWithModel<T>(true);
        }

        public static ServiceExecutionResultWithModel<T> With(T model)
        {
            return new ServiceExecutionResultWithModel<T>(model);
        }
    }
}