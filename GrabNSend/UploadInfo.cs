using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace GrabNDrop
{
    public class UploadInfo
    {
        private string file;
        private string url;
        private string paramName;
        private string contentType;

        private NameValueCollection nvc;
        public string File { get { return file; } set { file = value; } }
        public string Url { get { return url; } set { url = value; } }
        public string ParamName { get { return paramName; } set { paramName = value; } }
        public string ContentType { get { return contentType; } set { contentType = value; } }
        public NameValueCollection AdditionalData { get { return nvc; } set { nvc = value; } }
    }
}
