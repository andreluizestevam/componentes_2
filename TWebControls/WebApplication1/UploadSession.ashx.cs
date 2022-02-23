using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for UploadSession
    /// </summary>
    public class UploadSession : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            if (HttpContext.Current.Session["UploadDetail"] == null)
            {
                return;
            }

            UploadDetail info = (UploadDetail)HttpContext.Current.Session["UploadDetail"];
            if (info != null && info.IsReady)
            {
                int soFar = info.UploadedLength;
                int total = info.ContentLength;
                int percentComplete = (int)Math.Ceiling((double)soFar / (double)total * 100);
                string message = "Uploading...";
                string fileName = string.Format("{0}", info.FileName);
                string downloadBytes = string.Format("{0} of {1} Bytes", soFar, total);

                var retorno = new
                {
                    percentComplete = percentComplete,
                    message = message,
                    fileName = fileName,
                    downloadBytes = downloadBytes
                };

                var jsonObj = new JavaScriptSerializer().Serialize(retorno);
                context.Response.Write(jsonObj.ToString());
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}