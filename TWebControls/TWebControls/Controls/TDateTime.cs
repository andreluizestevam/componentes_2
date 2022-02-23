using System;
using System.ComponentModel;
using System.Web.UI;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Componente TextBox customizado para data.
    /// </summary>
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:TDateTime runat=\"server\"></{0}:TDateTime>")]
    public class TDateTime : TTextBox
    {
        #region Construtores

        /// <summary>
        /// Construtor
        /// </summary>
        public TDateTime()
            : base()
        {
            this.MaskType = EMaskType.DateTime;
            this.MaxLength = 16;
        }

        #endregion

        #region Propriedades

        /// <summary>
        /// Define a exibição de um calendário para o controle.
        /// </summary>
        [Category("Tbiz DateTime")]
        [DefaultValue(false)]
        [NotifyParentProperty(true), PersistenceMode(PersistenceMode.Attribute)]
        [Description("Define a exibição de um calendário para o controle.")]
        public bool UseCalendar
        {
            get
            {
                return Convert.ToBoolean(this.ViewState["_!UseCalendar"]);
            }
            set
            {
                this.ViewState["_!UseCalendar"] = value;
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Configura o calendário em um controle TTextBox caso este esteja definido para isto.
        /// </summary>
        /// <param name="writer">O escritor HTML.</param>
        private void ConfigureCalendar(HtmlTextWriter writer)
        {
            if (this.UseCalendar)
            {
                writer.AddAttribute("-tbzCalendar", "true");
            }
        }

        /// <summary>
        /// Renderiza o componente.
        /// </summary>
        /// <param name="writer">O escritor HTML.</param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (!this.DesignMode)
            {
                if (this.Enabled && this.Visible)
                {
                    this.ConfigureCalendar(writer);
                }
            }

            base.Render(writer);
        }

        #endregion
    }
}
