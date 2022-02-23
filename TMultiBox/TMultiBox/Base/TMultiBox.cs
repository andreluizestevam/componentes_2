using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Componente TMultiBox
    /// </summary>
    [ParseChildren(true)]
    [PersistChildren(true)]
    [Themeable(true)]
    [NonVisualControl]
    [ClientCssResource("Arquitetura.Web.WebControls.Resources.TMultiBox.css")]
    public abstract class TMultiBox : Panel, IScriptControl
    {
        #region Atributos

        /// <summary>
        /// 
        /// </summary>
        private ScriptManager sMgr;

        #endregion

        #region Propriedades

        /// <summary>
        /// Propriedade que determina os valores
        /// </summary>
        [PersistenceMode(PersistenceMode.EncodedInnerDefaultProperty)]
        [Category("Appearance")]
        [DefaultValue("")]
        public string Values
        {
            set { this.ViewState["_!Values"] = value; }
            get
            {
                if (this.ViewState["_!Values"] == null)
                {
                    this.ViewState["_!Values"] = string.Empty;
                }
                return this.ViewState["_!Values"].ToString();
            }
        }

        /// <summary>
        /// Propriedade que determina a quantidade maxima de valores.
        /// </summary>
        [PersistenceMode(PersistenceMode.EncodedInnerDefaultProperty)]
        [Category("Behavior")]
        [DefaultValue(-1)]
        public int MaxCount
        {
            set { this.ViewState["_!MaxCount"] = value; }
            get
            {
                if (this.ViewState["_!MaxCount"] == null)
                {
                    this.ViewState["_!MaxCount"] = -1;
                }
                return (int)this.ViewState["_!MaxCount"];
            }
        }

        #endregion

        #region Propriedades de Estilos

        /// <summary>
        /// CSS do elemento DIV - container principal
        /// </summary>
        [Category("Appearance")]
        [DefaultValue("tmultibox")]
        [CssClassProperty]
        public override string CssClass
        {
            get
            {
                if (string.IsNullOrEmpty(base.CssClass))
                {
                    base.CssClass = "tmultibox";
                }
                return base.CssClass;
            }
            set
            {
                base.CssClass = value;
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que retorna os descritores de script.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            // create instance descriptor
            ScriptControlDescriptor descriptor = new ScriptControlDescriptor("Arquitetura.Web.WebControls.TMultiBox", this.ClientID);

            // add properties default
            descriptor.AddProperty("MaxCount", this.MaxCount.ToString());
            descriptor.AddProperty("Enabled", this.Enabled);

            // add properties childrens
            this.GetScriptDescriptorChildren(descriptor);

            // return descriptor
            return new ScriptDescriptor[] { descriptor };
        }

        /// <summary>
        /// Método que retorna os atributos descritores filhos
        /// </summary>
        /// <param name="descriptor"></param>
        protected abstract void GetScriptDescriptorChildren(ScriptControlDescriptor descriptor);

        /// <summary>
        /// Metodo que retorna as referencias de script.
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<ScriptReference> GetScriptReferences()
        {
            List<ScriptReference> references = new List<ScriptReference>();

            references.Add(new ScriptReference()
            {
                Assembly = "AjaxControlToolkit",
                Name = "Common.Common.js"
            });

            references.Add(new ScriptReference()
            {
                Assembly = "AjaxControlToolkit",
                Name = "Compat.Timer.Timer.js"
            });

            references.Add(new ScriptReference()
            {
                Assembly = "AjaxControlToolkit",
                Name = "ExtenderBase.BaseScripts.js"
            });

            references.Add(new ScriptReference()
            {
                Assembly = "AjaxControlToolkit",
                Name = "MaskedEdit.MaskedEditValidator.js"
            });

            references.Add(new ScriptReference()
            {
                Assembly = "AjaxControlToolkit",
                Name = "MaskedEdit.MaskedEditBehavior.js"
            });

            references.Add(new ScriptReference()
            {
                Assembly = "Arquitetura.Web.WC.TMultiBox",
                Name = "Arquitetura.Web.WebControls.Resources.TMultiBox.js"
            });

            references.Add(new ScriptReference()
            {
                Assembly = "Arquitetura.Web.WC.TMultiBox",
                Name = "Arquitetura.Web.WebControls.Resources.FocusUtil.js"
            });

            return references.ToArray();
        }

        /// <summary>
        /// Metodo que renderiza o componente.
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (!this.DesignMode)
            {
                // registrando scripts
                sMgr.RegisterScriptDescriptors(this);

                // registrando css
                ScriptObjectBuilder.RegisterCssReferences(this);

                // regsitrando class container 
                writer.AddAttribute("class", this.CssClass);
            }

            base.Render(writer);
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Evento pre-render
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            if (!this.DesignMode)
            {
                // registrando scriptmanager
                sMgr = ScriptManager.GetCurrent(Page);

                if (sMgr == null)
                {
                    throw new HttpException("A ScriptManager control must exist on the page.");
                }

                // registrando scripts
                sMgr.RegisterScriptControl(this);

                // registrando css
                ScriptObjectBuilder.RegisterCssReferences(this);

                // registrando textbox
                TextBox txt = new TextBox();
                txt.ID = string.Concat(this.ID, "Values");
                txt.Text = this.Values;
                txt.Attributes.CssStyle.Add("display", "none");

                // add textbox
                this.Controls.Add(txt);
            }

            base.OnPreRender(e);
        }

        /// <summary>
        /// Evento load
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            if (this.Page.IsPostBack)
            {
                string strValues = this.Page.Request.Form[string.Concat(this.UniqueID, "Values")];

                if (string.IsNullOrEmpty(strValues))
                {
                    this.Values = string.Empty;
                }
                else
                {
                    string[] arrValues = strValues.Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

                    string strNewValues = string.Join(";", arrValues);

                    this.Values = strNewValues;
                }
            }

            base.OnLoad(e);
        }

        #endregion
    }
}
