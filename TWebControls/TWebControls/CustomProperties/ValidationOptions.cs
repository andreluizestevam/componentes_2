using System;
using System.ComponentModel;
using System.Globalization;
using System.Web.UI;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Classe que customiza a visualização do tipo do controle no visual studio.
    /// </summary>
    public class ValidationOptionsConverter : ExpandableObjectConverter
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
    /// Classe que representa as validações dos controles.
    /// </summary>
    [TypeConverterAttribute(typeof(ValidationOptionsConverter))]
    [Serializable]
    public class ValidationOptions : IValidation
    {
        /// <summary>
        /// Construtor padrão.
        /// </summary>
        public ValidationOptions()
        {
            this.RequiredErrorIndicator = "*";
            this.ErrorText = string.Empty;
            this.RequiredErrorText = string.Empty;
            this.RegularExpression = string.Empty;
            this.Required = false;
            this.RequiredCssClass = string.Empty;
            this.CustomClientValidator = string.Empty;
            this.MinLength = -1;
            this.MinValue = -1;
            this.MaxValue = -1;
        }

        /// <summary>
        /// Define o texto do erro customizado para o controle.
        /// </summary>
        [Category("Tbiz Appearance")]
        [DefaultValue("")]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [Description("Define o texto do erro customizado para o controle.")]
        public string ErrorText { get; set; }

        /// <summary>
        /// Define a expressão regular para validar o controle.
        /// </summary>
        [Category("Tbiz Behavior")]
        [DefaultValue("")]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [Description("Define a expressão regular para validar o controle.")]
        public string RegularExpression { get; set; }

        /// <summary>
        /// Define um método client-side (javascript) customizado a ser usado para validar o controle.
        /// </summary>
        [Category("Tbiz Behavior")]
        [DefaultValue("")]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [Description("Define um método javascript customizado a ser usado para validar o controle.")]
        public string CustomClientValidator { get; set; }

        /// <summary>
        /// Define um método server-side a ser usado para validar o controle.
        /// </summary>
        [Category("Tbiz Behavior")]
        [DefaultValue("")]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [Description("Define um método server-side a ser usado para validar o controle.")]
        public string ServerValidator { get; set; }

        /// <summary>
        /// Define se o controle é obrigatório.
        /// </summary>
        [Category("Tbiz Behavior")]
        [DefaultValue(false)]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [Description("Define se o controle é obrigatório.")]
        public bool Required { get; set; }

        /// <summary>
        /// Define a classe CSS para o indicador de obrigatoriedade.
        /// </summary>
        [Category("Tbiz Appearance")]
        [DefaultValue("")]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [CssClassProperty]
        [Description("Define a classe CSS para o indicador de obrigatoriedade.")]
        public string RequiredCssClass { get; set; }

        /// <summary>
        /// Define o texto do indicador de obrigatoriedade para o controle.
        /// </summary>
        [Category("Tbiz Appearance")]
        [Browsable(false)]
        [DefaultValue("*")]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [Description("Define o texto do indicador de obrigatoriedade para o controle.")]
        public string RequiredErrorIndicator { get; set; }

        /// <summary>
        /// Define o texto do indicador de obrigatoriedade para o controle.
        /// </summary>
        [Category("Tbiz Appearance")]
        [DefaultValue("")]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [Description("Define o texto que será exibido quando for verificado o campo obrigatório.")]
        public string RequiredErrorText { get; set; }

        /// <summary>
        /// Define o tamanho minimo de caracteres que o usuário deve informar para ser considerado válido
        /// </summary>
        [Category("Tbiz Behavior")]
        [DefaultValue(-1)]
        [Description("Define o tamanho minimo de caracteres que o usuário deve informar para ser considerado válido")]
        public int MinLength { get; set; }

        /// <summary>
        /// Define o valor mínimo para o campo, funciona apenas para números
        /// </summary>
        [Category("Tbiz Behavior")]
        [DefaultValue(-1)]
        [Description("Define o valor mínimo para o campo, funciona apenas para números")]
        public decimal MinValue { get; set; }

        /// <summary>
        /// Define o valor máximo para o campo, funciona apenas para números
        /// </summary>
        [Category("Tbiz Behavior")]
        [DefaultValue(-1)]
        [Description("Define o valor máximo para o campo, funciona apenas para números")]
        public decimal MaxValue { get; set; }
    }
}
