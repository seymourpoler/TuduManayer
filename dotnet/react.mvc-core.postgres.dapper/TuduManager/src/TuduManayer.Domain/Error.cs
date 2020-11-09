namespace TuduManayer.Domain
{
    public class Error
    {
        public string FieldId { get; }
        public ErrorCodes ErrorCode { get; }
        
        private  Error(string fieldId, ErrorCodes errorCode)
        {
            FieldId = fieldId;
            ErrorCode = errorCode;
        }
        
        public static  Error With(string fieldId, ErrorCodes errorCode)
        {
            return new Error(fieldId, errorCode);
        }
        
        public static  Error With( ErrorCodes errorCode)
        {
            return new Error("General", errorCode);
        }
    }
}