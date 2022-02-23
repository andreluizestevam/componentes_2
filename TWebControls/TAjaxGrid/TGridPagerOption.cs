using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arquitetura.Web.WebControls.Grid
{
    public class TGridPagerOption
    {
        /// <summary>
        /// Contrutor
        /// </summary>
        public TGridPagerOption()
        {
            this.Edit = true;
            this.Add = true;
            this.Del = true;
            this.Search = false;
            this.Refresh = false;
            this.Editfunc = "setCustomForm";
            this.Addfunc = "setCustomForm";
            this.Delfunc = "setDeleteForm";
            this.Edittitle = "Editar Classe";
            this.Addtitle = "Adicionar Classe";
            this.Deltitle = "Excluir Classe";
        }

        /// <summary>
        /// Grid editável, se sim mostra o botão de editar
        /// </summary>
        public bool Edit { get; set; }

        /// <summary>
        /// Grid editável, se sim mostra o botão de inserir
        /// </summary>
        public bool Add { get; set; }

        /// <summary>
        /// Grid editável, se sim mostra o botão de excluir
        /// </summary>
        public bool Del { get; set; }

        /// <summary>
        /// Grid editável, se sim mostra o botão de pesquisar
        /// </summary>
        public bool Search { get; set; }

        /// <summary>
        /// Grid editável, se sim mostra o botão de pesquisar
        /// </summary>
        public bool Refresh { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Addfunc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Addtitle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Editfunc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Edittitle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Viewtitle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Delfunc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Deltitle { get; set; }
    }
}
