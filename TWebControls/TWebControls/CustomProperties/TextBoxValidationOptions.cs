// -----------------------------------------------------------------------
// <copyright file="TextBoxValidationOptions.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Arquitetura.Web.WebControls
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel;
    using System.Web.UI;

    /// <summary>
    /// Opções de validação a serem utilizadas apenas para o TextBox
    /// </summary>
    [Serializable]
    public class TextBoxValidationOptions : ValidationOptions
    {
        public TextBoxValidationOptions()
        {
            this.MinLengt = -1;
        }

        /// <summary>
        /// Define o texto do indicador de obrigatoriedade para o controle.
        /// </summary>
        [DefaultValue("")]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [Description("Define o número mínimo de caracteres que o campo pode aceitar para ser considerado válido.")]
        public int MinLengt { get; set; }

    }
}
