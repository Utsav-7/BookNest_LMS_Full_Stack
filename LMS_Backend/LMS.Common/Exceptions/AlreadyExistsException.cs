namespace LMS_Backend.LMS.Common.Exceptions
{
    public class AlreadyExistsException<T> : Exception
    {
        public AlreadyExistsException() { }
        public AlreadyExistsException(string? message) : base(message) { }
        public AlreadyExistsException(T entityName) : base($"Data Already exists for {entityName}.") { }
    }
}