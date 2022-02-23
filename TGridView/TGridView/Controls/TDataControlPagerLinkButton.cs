using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Classe TDataControlPagerLinkButton
    /// </summary>
    [SupportsEventValidation]
    internal class TDataControlPagerLinkButton : TDataControlLinkButton
    {
        #region Propriedades

        /// <summary>
        /// Propriedade para habilitar validação
        /// </summary>
        public override bool CausesValidation
        {
            get { return false; }
            set
            {
                throw new NotSupportedException("Error. can not set validation on pager buttons");
            }
        }

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor padrão
        /// </summary>
        /// <param name="container">O container;</param>
        internal TDataControlPagerLinkButton(IPostBackContainer container)
            : base(container)
        {
        }

        #endregion
    }
}
