namespace ADN.Domain.Exceptions
{
    public class VehiclePlateException : AppException
    {
        public VehiclePlateException() { }
        public VehiclePlateException(string message) : base(message) { }
        public VehiclePlateException(string message, System.Exception inner) : base(message, inner) { }
        protected VehiclePlateException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}