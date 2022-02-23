using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Arquitetura.Web.WebControls.Grid;
using System.Web.Script.Services;
using Newtonsoft.Json.Converters;

namespace WebApplication1.Grid
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.grdTeste.Columns.Add(new TGridColModel
            {
                Name = "nome",
                Index = 0,
                Sortable = true
            });

            //this.grdTeste.DataSourceUrl = "WebForm1/GetDados";
        }

        [WebMethod]
        //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static TGridResult GetDados(string sidx, string sord, int page, int rows)
        {
            TGridResult retorno = new TGridResult
            {
                page = 1,
                records = 30,
                total = 3
            };

            List<TGridRow> daod = new List<TGridRow>();

            for (int i = 0; i < 20; i++)
            {
                daod.Add(new TGridRow { id = string.Concat("i", i), cell = new List<string> { string.Concat("luciano", i), DateTime.Today.ToString() } });
            }

            retorno.rows = daod;

            return retorno;

            //var jsonSerializerSettings = new JsonSerializerSettings
            //{
            //    ContractResolver = new CamelCasePropertyNamesContractResolver(),
            //    NullValueHandling = NullValueHandling.Ignore
            //};

            //jsonSerializerSettings.Converters.Add(new IsoDateTimeConverter());

            //string gOpt = JsonConvert.SerializeObject(retorno, Formatting.None, jsonSerializerSettings);

            //return gOpt;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GetDadosObj()
        {
            //string _search, string nd, string rows, string page, string sidx, string sort

            TGridResult retorno = new TGridResult
            {
                page = 1,
                records = 30,
                total = 3
            };

            //retorno.rows = new List<Dado>();

            //for (int i = 0; i < 30; i++)
            //{
            //    List<string> row = new List<string>();
            //    row.Add(string.Concat("nome", i));

            //    retorno.rows.Add(new Dado { nome = string.Concat("luciano", i), telefone = DateTime.Today });
            //}

            List<Dado> daod = new List<Dado>();

            for (int i = 0; i < 20; i++)
            {
                daod.Add(new Dado { nome = string.Concat("luciano", i), telefone = DateTime.Today });
            }

            retorno.rowsObj = daod;

            //return daod;

            var jsonSerializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };

            jsonSerializerSettings.Converters.Add(new IsoDateTimeConverter());

            string gOpt = JsonConvert.SerializeObject(retorno, Formatting.None, jsonSerializerSettings);

            return gOpt;
        }


    }

    public class Dado
    {
        public string nome { get; set; }
        public DateTime telefone { get; set; }
    }
}