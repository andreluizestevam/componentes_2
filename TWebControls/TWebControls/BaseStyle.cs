using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TControlUtils
{
    public class BaseStyle
    {
        /// <summary>
        /// Define a cor de fundo
        /// </summary>
        public Color BackColor { get; set; }

        /// <summary>
        /// Define a cor do item
        /// </summary>
        public Color ForeColor { get; set; }
        
        /// <summary>
        /// Define o CSS do controle
        /// </summary>
        public string CssClass { get; set; }
    }
}
