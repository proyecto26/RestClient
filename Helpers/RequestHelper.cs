using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Proyecto26
{
    public partial class RequestHelper
    {
        private string _uri;
        /// <summary>
        /// Defines the target URL for the UnityWebRequest to communicate with
        /// </summary>
        public string Uri
        {
            get { return _uri; }
            set { _uri = value; }
        }

        private string _method;
        /// <summary>
        /// Defines the HTTP verb used by this UnityWebRequest, such as GET or POST.
        /// </summary>
        public string Method
        {
            get { return _method; }
            set { _method = value; }
        }

        private object _body;
        /// <summary>
        /// The data to send to the server, encoding the body with JsonUtility
        /// </summary>
        public object Body
        {
            get { return _body; }
            set { _body = value; }
        }

        private string _bodyString;
        /// <summary>
        /// The data serialized as string to send to the web server (Using other tools instead of JsonUtility)
        /// </summary>
        public string BodyString
        {
            get { return _bodyString; }
            set { _bodyString = value; }
        }

        private byte[] _bodyRaw;
        /// <summary>
        /// The data as byte array to send to the server
        /// </summary>
        public byte[] BodyRaw
        {
            get { return _bodyRaw; }
            set { _bodyRaw = value; }
        }

        private int? _timeout;
        /// <summary>
        /// Sets UnityWebRequest to attempt to abort after the number of seconds in timeout have passed.
        /// </summary>
        public int? Timeout
        {
            get { return _timeout; }
            set { _timeout = value; }
        }

        private string _contentType;
        /// <summary>
        /// Override the content type of the request manually
        /// </summary>
        public string ContentType
        {
            get { return _contentType; }
            set { _contentType = value; }
        }

        private int _retries;
        /// <summary>
        /// The number of retries of the request
        /// </summary>
        public int Retries
        {
            get { return _retries; }
            set { _retries = value; }
        }

        private float _retrySecondsDelay;
        /// <summary>
        /// Seconds of delay to make a retry
        /// </summary>
        public float RetrySecondsDelay
        {
            get { return _retrySecondsDelay; }
            set { _retrySecondsDelay = value; }
        }

        private bool _retryCallbackOnlyOnNetworkErrors = true;
        /// <summary>
        /// Invoke RetryCallack only when the retry is provoked by a network error. (Default: true).
        /// </summary>
        public bool RetryCallbackOnlyOnNetworkErrors
        {
            get { return _retryCallbackOnlyOnNetworkErrors; }
            set { _retryCallbackOnlyOnNetworkErrors = value; }
        }

        private Action<RequestException, int> _retryCallback;
        /// <summary>
        /// A callback executed before to retry a request
        /// </summary>
        public Action<RequestException, int> RetryCallback
        {
            get { return _retryCallback; }
            set { _retryCallback = value; }
        }
        
        private Action<float> _progressCallback;

        /// <summary>
        /// A callback executed everytime the requests progress changes (From 0 to 1)
        /// </summary>
        public Action<float> ProgressCallback
        {
            get { return _progressCallback; }
            set { _progressCallback = value; }
        }
        
        private bool _enableDebug;
        /// <summary>
        /// Enable logs of the requests for debug mode
        /// </summary>
        public bool EnableDebug
        {
            get { return _enableDebug; }
            set { _enableDebug = value; }
        }

#if !UNITY_2019_3_OR_NEWER
        private bool? _chunkedTransfer;
        /// <summary>
        /// Indicates whether the UnityWebRequest system should employ the HTTP/1.1 chunked-transfer encoding method.
        /// </summary>
        public bool? ChunkedTransfer
        {
            get { return _chunkedTransfer; }
            set { _chunkedTransfer = value; }
        }
#endif

        private bool? _useHttpContinue = true;
        /// <summary>
        /// Determines whether this UnityWebRequest will include Expect: 100-Continue in its outgoing request headers. (Default: true).
        /// </summary>
        public bool? UseHttpContinue
        {
            get { return _useHttpContinue; }
            set { _useHttpContinue = value; }
        }

        private int? _redirectLimit;
        /// <summary>
        /// Indicates the number of redirects which this UnityWebRequest will follow before halting with a “Redirect Limit Exceeded” system error.
        /// </summary>
        public int? RedirectLimit
        {
            get { return _redirectLimit; }
            set { _redirectLimit = value; }
        }

        private bool _ignoreHttpException;
        /// <summary>
        /// Prevent to catch http exceptions
        /// </summary>
        public bool IgnoreHttpException
        {
            get { return _ignoreHttpException; }
            set { _ignoreHttpException = value; }
        }

        private WWWForm _formData;
        /// <summary>
        /// The form data to send to the web server using WWWForm
        /// </summary>
        public WWWForm FormData
        {
            get { return _formData; }
            set { _formData = value; }
        }

        private Dictionary<string, string> _simpleForm;
        /// <summary>
        /// The form data to send to the web server using Dictionary
        /// </summary>
        public Dictionary<string, string> SimpleForm
        {
            get { return _simpleForm; }
            set { _simpleForm = value; }
        }

        private List<IMultipartFormSection> _formSections;
        /// <summary>
        /// The form data to send to the web server using IMultipartFormSection
        /// </summary>
        public List<IMultipartFormSection> FormSections
        {
            get { return _formSections; }
            set { _formSections = value; }
        }

#if UNITY_2018_1_OR_NEWER
        private CertificateHandler _certificateHandler;
        /// <summary>
        /// Holds a reference to a CertificateHandler object, which manages certificate validation for this UnityWebRequest.
        /// </summary>
        public CertificateHandler CertificateHandler
        {
            get { return _certificateHandler; }
            set { _certificateHandler = value; }
        }
#endif

        private UploadHandler _uploadHandler;
        /// <summary>
        /// Holds a reference to the UploadHandler object which manages body data to be uploaded to the remote server.
        /// </summary>
        public UploadHandler UploadHandler
        {
            get { return _uploadHandler; }
            set { _uploadHandler = value; }
        }

        private DownloadHandler _downloadHandler;
        /// <summary>
        /// Holds a reference to a DownloadHandler object, which manages body data received from the remote server by this UnityWebRequest.
        /// </summary>
        public DownloadHandler DownloadHandler 
        { 
            get { return _downloadHandler; }
            set { _downloadHandler = value; }
        }

        private Dictionary<string, string> _headers;
        /// <summary>
        /// The HTTP headers added manually to send with the request
        /// </summary>
        public Dictionary<string, string> Headers 
        { 
            get
            {
                if (_headers == null)
                {
                    _headers = new Dictionary<string, string>();
                }
                return _headers;
            }
            set { _headers = value; } 
        }

        private Dictionary<string, string> _params;
        /// <summary>
        /// The HTTP query string params to send with the request
        /// </summary>
        public Dictionary<string, string> Params
        {
            get
            {
                if (_params == null)
                {
                    _params = new Dictionary<string, string>();
                }
                return _params;
            }
            set { _params = value; }
        }

        private bool _parseResponseBody = true;
        /// <summary>
        /// Whether to parse the response body as JSON or not. Note: parsing a large non-text file will have severe performance impact.
        /// </summary>
        public bool ParseResponseBody
        {
            get { return _parseResponseBody; }
            set { _parseResponseBody = value; }
        }
    }
}
