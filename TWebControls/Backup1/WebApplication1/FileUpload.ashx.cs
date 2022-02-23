using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Script.Serialization;
using System.Threading;
using System.Web.SessionState;

namespace WebApplication1
{
    /// <summary>
    /// Summary description for FileUpload
    /// </summary>
    public class FileUpload : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.Request.Files.Count == 0)
            {
                return;
            }

            var retorno = new List<ViewDataUploadFilesResult>();

            string path = @"c:\temp\upload";

            foreach (string file in context.Request.Files)
            {
                HttpPostedFile hpf = context.Request.Files[file] as HttpPostedFile;

                if (hpf.ContentLength == 0)
                    continue;

                UploadDetail fileDetail = new UploadDetail { IsReady = false, ContentLength = hpf.ContentLength };

                context.Session["UploadDetail"] = fileDetail;

                string fileName;

                if (HttpContext.Current.Request.Browser.Browser.ToUpper() == "IE")
                {
                    fileName = hpf.FileName.Remove(0, hpf.FileName.LastIndexOf("\\") + 1);
                }
                else
                {
                    fileName = hpf.FileName;
                }

                int bufferSize = 1;
                byte[] buffer = new byte[bufferSize];

                using (FileStream fs = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    while (fileDetail.UploadedLength < fileDetail.ContentLength)
                    {
                        int bytes = hpf.InputStream.Read(buffer, 0, bufferSize);
                        fs.Write(buffer, 0, bytes);
                        fileDetail.UploadedLength += bytes;
                    }
                }

                retorno.Add(new ViewDataUploadFilesResult
                {
                    idImagem = 1,
                    Name = fileName
                });
            }

            var uploadedFiles = new
            {
                files = retorno.ToArray()
            };

            var jsonObj = new JavaScriptSerializer().Serialize(uploadedFiles);
            context.Response.Write(jsonObj.ToString());
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }

    
    public class ViewDataUploadFilesResult
    {
        public int idImagem { get; set; }
        public string Name { get; set; }
        public string Caminho { get; set; }
    }
}