using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using Arquitetura.TechBiz.Web.Utils;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    [ParseChildren(true)]
    [PersistChildren(true)]
    [Themeable(true)]
    [NonVisualControl]
    public sealed class TFileUpload : Panel, IScriptControl, IPostBackDataHandler
    {
        #region Atributos

        /// <summary>
        /// 
        /// </summary>
        private ScriptManager sManager;

        /// <summary>
        /// 
        /// </summary>
        private TFileUploadStrategy fuStrategy;

        #endregion

        #region Propriedades

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(false)]
        public bool AllowMultiples
        {
            get
            {
                if (this.ViewState["_!AllowMultiples"] == null)
                {
                    this.ViewState["_!AllowMultiples"] = false;
                }
                return Convert.ToBoolean(this.ViewState["_!AllowMultiples"]);
            }
            set { this.ViewState["_!AllowMultiples"] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [DefaultValue(false)]
        public TFileUploadStrategyStore StrategyStore
        {
            get
            {
                if (this.ViewState["_!StrategyStore"] == null)
                {
                    this.ViewState["_!StrategyStore"] = TFileUploadStrategyStore.None;
                }
                return (TFileUploadStrategyStore)this.ViewState["_!StrategyStore"];
            }
            set { this.ViewState["_!StrategyStore"] = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<TFileUploadItem> Files
        {
            get { return this.GetStrategy().GetFiles(); }
        }

        #endregion

        #region ScriptControls

        /// <summary>
        /// Metodo que retorna as referencias de script.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ScriptReference> GetScriptReferences()
        {
            List<ScriptReference> references = new List<ScriptReference>();

            references.Add(new ScriptReference()
            {
                Assembly = "Arquitetura.Web.WC.TFileUpload",
                Name = "Arquitetura.Web.WebControls.Resources.TFileUpload.js"
            });

            references.Add(new ScriptReference()
            {
                Assembly = "Arquitetura.Web.WC.TFileUpload",
                Name = "Arquitetura.Web.WebControls.Resources.FocusUtil.js"
            });

            return references;
        }

        /// <summary>
        /// Metodo que retorna os descritores de script.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ScriptDescriptor> GetScriptDescriptors()
        {
            // get descriptors
            List<ScriptDescriptor> descriptors = new List<ScriptDescriptor>();

            // create instance descriptor
            ScriptControlDescriptor descriptor = new ScriptControlDescriptor("Arquitetura.Web.WebControls.TFileUpload", this.ClientID);

            // add descriptos
            descriptors.Add(descriptor);

            // return descriptor
            return descriptors;
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Metodo que renderiza o componente.
        /// </summary>
        /// <param name="writer"></param>
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);

            if (!this.DesignMode)
            {
                sManager.RegisterScriptDescriptors(this);
            }
        }

        /// <summary>
        /// Evento pre-render
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            if (!this.DesignMode)
            {
                // registrando scriptmanager
                sManager = ScriptManager.GetCurrent(Page);

                if (sManager == null)
                {
                    throw new HttpException("A ScriptManager control must exist on the page.");
                }

                // registrando scripts
                sManager.RegisterScriptControl(this);
            }

            base.OnPreRender(e);
        }

        /// <summary>
        /// Evento load
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            this.Page.RegisterRequiresPostBack(this);

            if (this.Page.IsPostBack)
            {
                this.GetStrategy().RefreshFiles();
            }

            base.OnLoad(e);
        }

        /// <summary>
        /// Método que cria os controle internos.
        /// </summary>
        protected override void CreateChildControls()
        {
            // config client id mode
            this.ClientIDMode = System.Web.UI.ClientIDMode.AutoID;

            // create asyncfileupload
            Panel pnl1 = new Panel();
            pnl1.ClientIDMode = System.Web.UI.ClientIDMode.AutoID;
            pnl1.ID = string.Concat(this.ID, "TBAFU");
            pnl1.Attributes.CssStyle.Add("display", "inline-block");
            pnl1.Attributes.CssStyle.Add("float", "left");
            pnl1.Attributes.CssStyle.Add("width", "95%");

            AsyncFileUpload afu = new AsyncFileUpload();
            afu.ClientIDMode = System.Web.UI.ClientIDMode.AutoID;
            afu.ID = string.Concat(this.ID, "AFU");
            afu.PersistFile = false;
            afu.UploadingBackColor = Color.FromArgb(229, 227, 255);
            afu.ErrorBackColor = Color.FromArgb(255, 231, 231);
            afu.CompleteBackColor = Color.FromArgb(227, 249, 213);
            afu.Width = Unit.Percentage(100);
            afu.ThrobberID = string.Concat(this.ID, "THB");
            afu.UploaderStyle = AsyncFileUpload.UploaderStyleEnum.Traditional;
            afu.UploadedComplete += new EventHandler<AsyncFileUploadEventArgs>(OnUploadedCompleteAsync);
            afu.UploadedFileError += new EventHandler<AsyncFileUploadEventArgs>(OnUploadedErrorAsync);

            pnl1.Controls.Add(afu);

            // create throbber
            Panel pnl2 = new Panel();
            pnl2.ClientIDMode = System.Web.UI.ClientIDMode.AutoID;
            pnl2.ID = string.Concat(this.ID, "THB");
            pnl2.Attributes.CssStyle.Add("display", "none");
            pnl2.Attributes.CssStyle.Add("float", "right");
            pnl2.Attributes.CssStyle.Add("border", "1px solid #ccc");

            System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image();
            img.ClientIDMode = System.Web.UI.ClientIDMode.AutoID;
            img.ID = string.Concat(this.ID, "IMG");
            img.ImageUrl = this.Page.ClientScript.GetWebResourceUrl(this.GetType(), "Arquitetura.Web.WebControls.Resources.ajax.gif");
            img.ImageAlign = ImageAlign.Middle;

            pnl2.Controls.Add(img);

            // add controls
            this.Controls.Add(pnl1);
            this.Controls.Add(pnl2);
        }

        /// <summary>
        /// Evento uploadedComplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnUploadedCompleteAsync(object sender, AsyncFileUploadEventArgs e)
        {
            // get asynfileupload
            AsyncFileUpload afu = (AsyncFileUpload)sender;

            // verify has file
            if (!afu.HasFile)
            {
                return;
            }

            // create item
            TFileUploadItem item = new TFileUploadItem();

            // config item
            item.Name = Path.GetFileName(afu.PostedFile.FileName);
            item.Path = Path.GetDirectoryName(afu.PostedFile.FileName);
            item.ContentType = afu.PostedFile.ContentType;
            item.Bytes = afu.FileBytes;
            item.Length = int.Parse(e.filesize);

            //Armazena somente um item se AllowMultiples for false
            if (!this.AllowMultiples)
            {
                this.GetStrategy().ClearFiles();
            }

            // add file
            this.GetStrategy().AddFile(item);
        }

        /// <summary>
        /// Evento uploadederror
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnUploadedErrorAsync(object sender, AsyncFileUploadEventArgs e)
        {
            // tem que ser declarada para tratar eventos internos do asynfileupload
            // e nao gerar window.alert.
        }

        /// <summary>
        /// Evento uploadedComplete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnUploadedComplete(object sender, AsyncFileUploadEventArgs e)
        {
            // verify exist event
            if (UploadCompleted == null)
            {
                return;
            }

            // get itens
            List<TFileUploadItem> itens = this.GetStrategy().GetFiles();

            // create item
            TFileUploadItem item = itens[itens.Count - 1];

            // create eventargs
            TFileUploadEventArgs eventArgs = new TFileUploadEventArgs();
            eventArgs.Item = item;
            eventArgs.PersistFile = true;
            eventArgs.State = (TFileUploadState)(int)e.state;
            eventArgs.Message = e.statusMessage;

            // handler event
            UploadCompleted(this, eventArgs);

            // verificando se e pra salvar na sessao
            if (!eventArgs.PersistFile)
            {
                this.GetStrategy().RemoveFile(item);
            }
        }

        /// <summary>
        /// Evento uploadederror
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnUploadedError(object sender, AsyncFileUploadEventArgs e)
        {
            // verify exist event
            if (UploadFailed == null)
            {
                return;
            }

            // verify state unknow to not file especify
            if ((TFileUploadState)(int)e.state == TFileUploadState.Unknown)
            {
                return;
            }

            // get asynfileupload
            AsyncFileUpload afu = (AsyncFileUpload)sender;

            // create item
            TFileUploadItem item = new TFileUploadItem();

            // config item
            item.Name = Path.GetFileName(e.filename);
            item.Path = Path.GetDirectoryName(e.filename);
            item.Length = int.Parse(e.filesize);

            // create eventargs
            TFileUploadEventArgs eventArgs = new TFileUploadEventArgs();
            eventArgs.Item = item;
            eventArgs.PersistFile = false;
            eventArgs.State = (TFileUploadState)(int)e.state;
            eventArgs.Message = e.statusMessage;

            // handler event
            UploadFailed(this, eventArgs);
        }

        /// <summary>
        /// Método que limpa os arquivos.
        /// </summary>
        public void ClearAllFiles()
        {
            this.GetStrategy().ClearFiles();
        }

        #endregion

        #region Eventos

        /// <summary>
        /// 
        /// </summary>
        [Bindable(true)]
        [Category("Events")]
        public event EventHandler<TFileUploadEventArgs> UploadCompleted;

        /// <summary>
        /// 
        /// </summary>
        [Bindable(true)]
        [Category("Events")]
        public event EventHandler<TFileUploadEventArgs> UploadFailed;

        #endregion

        #region Auxiliares

        /// <summary>
        /// Método que a instancia da estratégia escolhida.
        /// </summary>
        /// <returns></returns>
        private TFileUploadStrategy GetStrategy()
        {
            if (fuStrategy == null)
            {
                switch (this.StrategyStore)
                {
                    case TFileUploadStrategyStore.Session: fuStrategy = new TFileUploadSessionStrategy(this); break;
                    case TFileUploadStrategyStore.Cache: fuStrategy = new TFileUploadCacheStrategy(this); break;
                    default: throw new ArgumentException("A estratégia de armazenamento deve ser configurada.");
                }
            }

            return fuStrategy;
        }

        #endregion

        #region Evento PostBack

        /// <summary>
        /// Atributo que contém os dados enviados pelo evento postback.
        /// </summary>
        private string postBackData;

        /// <summary>
        /// Método que captura os dados do evento postback.
        /// </summary>
        /// <param name="postDataKey"></param>
        /// <param name="postCollection"></param>
        /// <returns></returns>
        public bool LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
        {
            if (!string.Equals(postDataKey, this.UniqueID))
            {
                return false;
            }

            string keyTarget = postCollection["__EVENTTARGET"];

            if (!string.IsNullOrEmpty(keyTarget)
                && (keyTarget.StartsWith(this.UniqueID)
                    || keyTarget.StartsWith(this.ClientID)))
            {
                this.postBackData = postCollection["__EVENTARGUMENT"];

                return !string.IsNullOrEmpty(this.postBackData)
                        && this.postBackData.StartsWith("UPLOAD");
            }

            string keyTarget2 = postCollection["__EVENTTARGET"];

            if (!string.IsNullOrEmpty(keyTarget2)
                && (keyTarget2.Replace("_", "$").StartsWith(this.UniqueID)
                    || keyTarget2.Replace("_", "$").StartsWith(this.ClientID)))
            {
                this.postBackData = postCollection["__EVENTARGUMENT"];

                return !string.IsNullOrEmpty(this.postBackData)
                        && this.postBackData.StartsWith("UPLOAD");
            }

            string keyEvent = postCollection.Keys[postCollection.Count - 1];

            if (!string.IsNullOrEmpty(keyEvent)
                && (keyEvent.StartsWith(this.UniqueID)
                    || keyEvent.StartsWith(this.ClientID)))
            {
                this.postBackData = postCollection["__EVENTARGUMENT"];

                return !string.IsNullOrEmpty(this.postBackData)
                        && this.postBackData.StartsWith("UPLOAD");
            }

            //if (!string.IsNullOrEmpty(postCollection["__EVENTARGUMENT"])
            //    && postCollection["__EVENTARGUMENT"].StartsWith("UPLOAD"))
            //{
            //    this.postBackData = postCollection["__EVENTARGUMENT"];

            //    return !string.IsNullOrEmpty(this.postBackData)
            //            && this.postBackData.StartsWith("UPLOAD");
            //}

            return false;
        }

        /// <summary>
        /// Método que trata os dados do evento postback. 
        /// </summary>
        public void RaisePostDataChangedEvent()
        {
            AsyncFileUpload afu = (AsyncFileUpload)ControlUtil.FindControl(this, string.Concat(this.ID, "AFU"), EFindControlStrategy.TopDown);

            string[] values = this.postBackData.Split(new char[] { ';' });

            if (values[0].Equals("UPLOADERROR"))
            {
                this.OnUploadedError(afu, new AsyncFileUploadEventArgs(AsyncFileUploadState.Failed, values[3], values[1], values[2]));
            }
            if (values[0].Equals("UPLOADSUCCESS"))
            {
                this.OnUploadedComplete(afu, new AsyncFileUploadEventArgs(AsyncFileUploadState.Success, values[3], values[1], values[2]));
            }

            this.postBackData = string.Empty;
        }

        #endregion
    }
}
