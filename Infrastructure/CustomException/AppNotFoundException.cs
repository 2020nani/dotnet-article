using System.Globalization;

namespace FirstApi.Infrastructure.CustomException
{
    public class AppNotFoundException : Exception
    {
        public AppNotFoundException() : base() { }

        public AppNotFoundException(string message) : base(message) { }

        public AppNotFoundException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}

