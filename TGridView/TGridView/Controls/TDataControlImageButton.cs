using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Classe TDataControlImageButton
    /// </summary>
    [SupportsEventValidation]
    internal sealed class TDataControlImageButton : ImageButton
    {
        #region Atributos

        /// <summary>
        /// Atributo com argumento do callback
        /// </summary>
        private string _callbackArgument;

        /// <summary>
        /// Atributo com o container de postback
        /// </summary>
        private IPostBackContainer _container;

        /// <summary>
        /// Atributo para habilitar o callback
        /// </summary>
        private bool _enableCallback;

        #endregion

        #region Propriedades

        /// <summary>
        /// Propriedade para habilitar validação
        /// </summary>
        public override bool CausesValidation
        {
            get { return false; }
            set
            {
                throw new NotSupportedException("Error. Can not set validation on data control buttons");
            }
        }

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor padrão.
        /// </summary>
        /// <param name="container">O container.</param>
        internal TDataControlImageButton(IPostBackContainer container)
        {
            this._container = container;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Método para habilitar o callback
        /// </summary>
        /// <param name="argument">O argumento.</param>
        internal void EnableCallback(string argument)
        {
            this._enableCallback = true;
            this._callbackArgument = argument;
        }

        /// <summary>
        /// Método para recuperar as opções de postback
        /// </summary>
        /// <returns>PostBackOptions</returns>
        protected sealed override PostBackOptions GetPostBackOptions()
        {
            if (this._container != null)
            {
                return this._container.GetPostBackOptions(this);
            }
            return base.GetPostBackOptions();
        }

        /// <summary>
        /// Método para renderizar
        /// </summary>
        /// <param name="writer">O renderizador</param>
        protected override void Render(HtmlTextWriter writer)
        {
            this.SetCallbackProperties();
            base.Render(writer);
        }

        /// <summary>
        /// Método para configurar as opções de callback
        /// </summary>
        private void SetCallbackProperties()
        {
            if (this._enableCallback)
            {
                ICallbackContainer container = this._container as ICallbackContainer;

                if (container != null)
                {
                    string callbackScript = container.GetCallbackScript(this, this._callbackArgument);

                    if (!string.IsNullOrEmpty(callbackScript))
                    {
                        this.OnClientClick = callbackScript;
                    }
                }
            }
        }

        #endregion
    }
}
