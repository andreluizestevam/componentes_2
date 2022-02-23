using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arquitetura.Web.WebControls.Grid
{
    public class TGridEditOptions
    {
        /// <summary>
        /// construtor
        /// </summary>
        public TGridEditOptions()
        {
            this.beforeShowForm = string.Empty;
        }

        /// <summary>
        /// Evento a ser chamado antes do grid ser editado
        /// </summary>
        public string beforeShowForm { get; set; }
    }
}
