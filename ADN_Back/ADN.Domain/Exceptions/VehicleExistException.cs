namespace ADN.Domain.Exceptions
{
    public class VehicleExistException : AppException
    {
        public VehicleExistException() { }
        public VehicleExistException(string message) : base(message) { }
        public VehicleExistException(string message, System.Exception inner) : base(message, inner) { }
        protected VehicleExistException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}