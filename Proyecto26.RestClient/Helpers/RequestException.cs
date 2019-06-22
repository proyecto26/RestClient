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

        private long _statusCode;
        public long StatusCode
        {
            get { return _statusCode; }
            private set { _statusCode = value; }
        }

        private string _serverMessage;
        public string ServerMessage
        {
            get { return _serverMessage; }
            set { _serverMessage = value; }
        }

        private string _response;
        public string Response
        {
            get { return _response; }
            set { _response = value; }
        }

        public RequestException() { }

        public RequestException(string message): base(message) { }

        public RequestException(string format, params object[] args): base(string.Format(format, args)) { }

        public RequestException(string message, bool isHttpError, bool isNetworkError, long statusCode, string response) : base(message) {
            _isHttpError = isHttpError;
            _isNetworkError = isNetworkError;
            _statusCode = statusCode;
            _response = response;
        }
    }
}
