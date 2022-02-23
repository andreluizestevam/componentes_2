using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arquitetura.Web.WebControls.Grid
{
    public class TGridResult
    {
        /// <summary>
        /// Pagina atual do grid
        /// </summary>
        public int page { get; set; }

        /// <summary>
        /// Total de páginas
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// Total de registros
        /// </summary>
        public int records { get; set; }

        /// <summary>
        /// Lista com os registros
        /// </summary>
        public List<TGridRow> rows { get; set; }

        public object rowsObj { get; set; }

    }
}
