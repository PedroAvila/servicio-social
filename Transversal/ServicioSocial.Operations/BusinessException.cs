using System.Runtime.Serialization;

namespace ServicioSocial.Operations
{
    public class BusinessException : Exception
    {
        public int Status { get; set; }
        public string? Mensaje { get; set; }

        public BusinessException()
                : base()
        {
        }

        public BusinessException(string message)
            : base(message)
        {
        }

        public BusinessException(string format, params object[] args)
            : base(string.Format(format, args))
        {
            Mensaje = format;
            var dato = args.ToList().FirstOrDefault();
            if (dato != null)
                Status = (int)dato;
        }

        public BusinessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public BusinessException(string format, Exception innerException, params object[] args)
            : base(string.Format(format, args), innerException)
        {
        }

        protected BusinessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}