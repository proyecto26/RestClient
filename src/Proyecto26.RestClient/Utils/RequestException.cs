using System;
namespace Proyecto26
{
    public class RequestException : Exception
    {
        private bool _isHttpError;
        public bool IsHttpError
        {
            get { return _isHttpError; }
            private set { _isHttpError = value; }
        }

        private bool _isNetworkError;
        public bool IsNetworkError
        {
            get { return _isNetworkError; }
            private set { _isNetworkError = value; }
        }

        public RequestException(): base() { }

        public RequestException(string message): base(message) { }

        public RequestException(string format, params object[] args): base(string.Format(format, args)) { }

        public RequestException(string message, bool isHttpError, bool isNetworkError) : base(message) {
            _isHttpError = isHttpError;
            _isNetworkError = isNetworkError;
        }
    }
}
