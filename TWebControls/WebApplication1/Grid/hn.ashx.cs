using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WebApplication1.Grid
{
    /// <summary>
    /// Summary description for hn
    /// </summary>
    public class hn : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            List<Dado> dados = new List<Dado>();

            for (int i = 0; i < 30; i++)
            {
                dados.Add(new Dado { nome = string.Concat("nome", i) });
            }

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };


            var retorno = new { sEcho = 30, iTotalRecords = 40, iTotalDisplayRecords = 20, aaData = dados };
            
            string gOpt = JsonConvert.SerializeObject(retorno, Formatting.None, jsonSerializerSettings);

            //return gOpt;
            
            context.Response.ContentType = "text/json";
            context.Response.Write(gOpt);
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