using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Arquitetura.Web.WebControls.JavaScript;
using System.Web.UI.HtmlControls;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Classe utilitária para os controles.
    /// </summary>
    internal static class ControlUtils
    {
        private static String[] GetScripts()
        {
            //                "TechBiz.stringUtils.js",
            //                "Techbiz.Mask.DateTime.js",
            //    "Techbiz.TTextBox.Mask.js",
            //    "Techbiz.Mask.Number.js",
            //"jquery-1.7.2.min.js",

            //"jquery-1.7.2.min.js",
            //"jquery.jgrowl.js",
            //"Techbiz.multiSelectControl.js",

            String[] scripts = new String[]
            {
                "jquery-ui-1.8.20.custom.min.js",
                "jquery-ui-timepicker-addon.js",
                "jquery.validate.js",
                "jquery.additional-methods.js",
                "jquery.inputmask.js",
                "jquery.inputmask.extentions.js",
                "jquery.inputmask.numeric.extentions.js",
                "jquery.inputmask.date.extentions.js",
                "TechBiz.formatInputs.js",
                "TechBiz.fieldValueValidate.js",
                "TechBiz.textAreaControl.js",
                "jquery.metadata.js",
                "TechBiz.messageBox.js",
                "jquery.searchabledropdown-1.0.7.src.js",
                "jquery.simplemodal-1.4.2.js",
                "jquery.cookie.js",
                "Techbiz.Principal.js"
            };

            return scripts;
        }

        public static void RegisterStaticFiles(Type type, Page page)
        {
            if (!page.ClientScript.IsClientScriptIncludeRegistered("!_TControlsScript0"))
            {
                //var cssLink = new HtmlLink();
                //cssLink.ID = "css";
                //cssLink.Href = page.ClientScript.GetWebResourceUrl(type, "Arquitetura.Web.WebControls.JavaScript.bootstrap.min.css");
                //cssLink.Attributes.Add("rel", "stylesheet");
                //page.Header.Controls.Add(cssLink);
            }

            RegisterScripts(type, page.ClientScript);

            //if (page.Header.FindControl("css") == null)
            //{
            //    var cssLink = new HtmlLink();
            //    cssLink.ID = "css";
            //    cssLink.Href = page.ClientScript.GetWebResourceUrl(type, "Arquitetura.Web.WebControls.bootstrap.css.bootstrap.min.css");
            //    cssLink.Attributes.Add("rel", "stylesheet");
            //    page.Header.Controls.Add(cssLink);

            //    ////Arquitetura.Web.WebControls.CSS.jquery.jgrowl.css

            //    //var cssLink2 = new HtmlLink();
            //    //cssLink2.ID = "css1";
            //    //cssLink2.Href = page.ClientScript.GetWebResourceUrl(type, "Arquitetura.Web.WebControls.CSS.jquery-ui-1.8.21.custom.css");
            //    //cssLink2.Attributes.Add("rel", "stylesheet");
            //    //page.Header.Controls.Add(cssLink2);
            //}
        }


        private static void RegisterScripts(Type type, ClientScriptManager scriptManager)
        {
            if (!scriptManager.IsClientScriptIncludeRegistered("!_TControlsScript0"))
            {
                string[] scripts = GetScripts();

                for (int i = 0; i < scripts.Length; i++)
                {
                    RegisterScript(type, scriptManager, scripts[i], i);
                }
            }
        }

        private static void RegisterScript(Type type, ClientScriptManager scriptManager, string url, int idScript)
        {
            string key = string.Concat("!_TControlsScript", idScript);

            scriptManager.RegisterClientScriptInclude(key, scriptManager.GetWebResourceUrl(type, string.Concat("Arquitetura.Web.WebControls.JavaScript.", url)));
        }

        /// <summary>
        /// Cria o validação baseada nas configuração de validação do controle.
        /// </summary>
        /// <param name="controle">O controle que está sendo usado.</param>
        /// <returns>ClientValidation</returns>
        public static ClientValidation CreateClientValidation(IValidationControl controle)
        {
            ClientValidation obj = new ClientValidation();

            if (controle.Validation.Required)
            {
                obj.required = true;
            }

            if (!string.IsNullOrWhiteSpace(controle.Validation.RegularExpression))
            {
                obj.validaRegex = controle.Validation.RegularExpression;

                if (!string.IsNullOrWhiteSpace(controle.Validation.RequiredErrorText))
                {
                    obj.messages = new CustomMessages() { validaRegex = controle.Validation.RequiredErrorText };
                }
            }

            if (!string.IsNullOrWhiteSpace(controle.Validation.CustomClientValidator))
            {
                obj.customJS = controle.Validation.CustomClientValidator;

                if (!string.IsNullOrWhiteSpace(controle.Validation.ErrorText))
                {
                    if (obj.messages == null)
                    {
                        obj.messages = new CustomMessages();
                    }

                    obj.messages = new CustomMessages() { customJS = controle.Validation.ErrorText };
                }
            }

            if (!string.IsNullOrEmpty(controle.Validation.ServerValidator))
            {
                obj.serverVltd = controle.Validation.ServerValidator;
            }


            if (!string.IsNullOrWhiteSpace(controle.Validation.RequiredErrorText))
            {
                if (obj.messages == null)
                {
                    obj.messages = new CustomMessages();
                }

                obj.messages.required = controle.Validation.RequiredErrorText;
            }

            if (controle.Validation.MinLength != -1)
            {
                obj.minTam = controle.Validation.MinLength;
            }

            if (controle.Validation.MinValue != -1 && controle.Validation.MaxValue != -1)
            {
                obj.rangeDecimal = new System.Collections.Generic.List<decimal>();

                obj.rangeDecimal.Add(controle.Validation.MinValue);
                obj.rangeDecimal.Add(controle.Validation.MaxValue);
            }

            return obj;
        }

        /// <summary>
        /// Configura o texto do indicador de obrigatoriedade do controle.
        /// </summary>
        /// <param name="writer">O escritor HTML.</param>
        /// <param name="controle">O controle que está sendo usado.</param>
        public static void ConfigureRequiredValidation(HtmlTextWriter writer, IValidationControl controle)
        {
            //Caso o controle esteja ReadOnly ou Enabled false não precisa de validação
            WebControl control = controle as WebControl;

            if (!control.Enabled)
            {
                return;
            }

            if (controle.Validation.Required)
            {
                writer.WriteBeginTag("span");
                writer.WriteAttribute("class", string.IsNullOrWhiteSpace(controle.Validation.RequiredCssClass) ? "requiredClass" : controle.Validation.RequiredCssClass);
                writer.Write(">");
                writer.Write(controle.Validation.RequiredErrorIndicator);
                writer.WriteEndTag("span");
            }
        }

        /// <summary>
        /// Configura a máscara do controle.
        /// </summary>
        /// <param name="writer">O escritor HTML.</param>
        /// <param name="controle">O controle que está sendo usado.</param>
        public static void ConfigureMaskField(HtmlTextWriter writer, ITControl controle)
        {
            //Caso o controle esteja ReadOnly ou Enabled false não precisa de máscara
            if (!(controle as WebControl).Enabled)
            {
                return;
            }
        }

        /// <summary>
        /// Usado para configurar a div que será o container do controle
        /// </summary>
        /// <param name="writer">O escritor HTML.</param>
        /// <param name="controle">O controle que está sendo usado.</param>
        public static void ConfigureDivContainer(HtmlTextWriter writer, ITControl controle)
        {
            writer.WriteBeginTag(string.Concat("div id=", (controle as WebControl).UniqueID, "dvCnt"));
            writer.WriteAttribute("class", string.IsNullOrEmpty(controle.ContainerCssClass) ? "divContainer" : controle.ContainerCssClass);
            writer.Write(">");
        }

        /// <summary>
        /// Configura o label do controle
        /// </summary>
        /// <param name="writer">O escritor HTML.</param>
        /// <param name="controle">O controle que está sendo usado.</param>
        public static void ConfigureLabel(HtmlTextWriter writer, ILabelControl controle)
        {
            if (controle.Label.ShowLabel && !string.IsNullOrEmpty(controle.Label.LabelText))
            {
                writer.WriteBeginTag("label");
                writer.WriteAttribute("for", ((WebControl)controle).ClientID);
                writer.WriteAttribute("class", string.IsNullOrEmpty(controle.Label.LabelCssClass) ? "labelClass" : controle.Label.LabelCssClass);
                writer.Write(">");

                if (controle is IValidationControl)
                {
                    ConfigureRequiredValidation(writer, controle as IValidationControl);
                }

                writer.WriteEncodedText(controle.Label.LabelText);
                writer.WriteEndTag("label");
            }
        }
    }
}
