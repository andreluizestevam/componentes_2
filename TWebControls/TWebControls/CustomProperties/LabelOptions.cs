using System;
using System.ComponentModel;
using System.Globalization;
using System.Web.UI;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Classe que customiza a visualização do tipo do controle no visual studio.
    /// </summary>
    public class LabelOptionsConverter : ExpandableObjectConverter
    {
        /// <summary>
        /// Método que converte a visualização do tipo de controle.
        /// </summary>
        /// <param name="context">O contexto descritor de tipo.</param>
        /// <param name="culture">A cultura de globalização.</param>
        /// <param name="value">O valor.</param>
        /// <param name="destType">O tipo destino.</param>
        /// <returns>object</returns>
        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destType)
        {
            return string.Empty;
        }
    }

    /// <summary>
    /// Classe que representa o label a ser colocado nos controles.
    /// </summary>
    [TypeConverterAttribute(typeof(LabelOptionsConverter))]
    [Serializable]
    public class LabelOptions
    {
        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public LabelOptions()
        {
            this.ShowLabel = true;
            this.LabelText = string.Empty;
            this.LabelCssClass = string.Empty;
        }

        /// <summary>
        /// Define a exibição ou não do Label do Controle.
        /// </summary>
        [Category("Tbiz Behavior")]
        [DefaultValue(true)]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [Description("Define a exibição ou não do label do controle.")]
        public bool ShowLabel { get; set; }

        /// <summary>
        /// Define o Texto para o Label do Controle.
        /// </summary>
        [Category("Tbiz Appearance")]
        [DefaultValue("")]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [Description("Define o texto para o label do controle.")]
        public string LabelText { get; set; }

        /// <summary>
        /// Define a Classe CSS para o Label do Controle.
        /// </summary>
        [Category("Tbiz Appearance")]
        [DefaultValue("")]
        [CssClassProperty]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [Description("Define a classe CSS para o label do controle.")]
        public string LabelCssClass { get; set; }
    }
}
