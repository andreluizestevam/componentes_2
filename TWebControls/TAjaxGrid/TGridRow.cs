using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arquitetura.Web.WebControls.Grid
{
    public class TGridRow
    { 
        /// <summary>
        /// id da Row, não precisa ser o pk da tabela
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Lista com os dados que serão exibidos no grid
        /// </summary>
        public List<string> cell { get; set; }
    }
}
