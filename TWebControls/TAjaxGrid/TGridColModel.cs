using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arquitetura.Web.WebControls.Grid
{
    /// <summary>
    /// http://www.trirand.net/documentation/php/_2v70w5p2k.htm
    /// </summary>
    public class TGridColModel
    {
        /// <summary>
        /// Nome da coluna
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Descrição da coluna
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Posição de exibição no grid
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Tamanho da coluna
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Se ela é ordenavel
        /// </summary>
        public bool Sortable { get; set; }

        /// <summary>
        /// Se é editável
        /// </summary>
        public bool Editable { get; set; }

        /// <summary>
        /// Se é escondida
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// Tipo da coluna, para checkBox, Combo etc
        /// </summary>
        public string EditType { get; set; }

        /// <summary>
        /// string - Defines the alignment of the cell in the Body layer, not in header cell. Possible values: left, center, right.
        /// </summary>
        public EAlign Align { get; set; }

        /// <summary>
        /// This option allow to add classes to the column. If more than one class will be used a space should be set. By example classes:'class1 class2' will set a class1 and class2 to every cell on that column. In the grid css there is a predefined class ui-ellipsis which allow to attach ellipsis to a particular row. Also this will work in FireFox too.
        /// </summary>
        public string Classes { get; set; }

        /// <summary>
        /// Governs format of sorttype:date (when datetype is set to local) and editrules {date:true} fields. Determines the expected date format for that column. Uses a PHP-like date formatting. Currently ”/”, ”-”, and ”.” are supported as date separators. Valid formats are: 
        /// y,Y,yyyy for four digits year 
        /// YY, yy for two digits year 
        /// m,mm for months 
        /// d,dd for days. 
        /// </summary>
        public string Datefmt { get; set; }

        /// <summary>
        /// Formato da coluna
        /// </summary>
        public EFormat formatter { get; set; }

        /// <summary>
        /// Informa se esta coluna é a Key, só pode haver uma
        /// </summary>
        public bool Key { get; set; }

        ///// <summary>
        ///// Opções do tipo da coluna
        ///// </summary>
        //public TGridColModelEditOptions EditOptions { get; set; }
    }
}
