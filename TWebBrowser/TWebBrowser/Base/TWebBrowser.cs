﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;
using System.Threading;
using HtmlAgilityPack;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// Classe de requisição customizada.
    /// </summary>
    public sealed class TWebRequest
    {
        #region Constantes

        /// <summary>
        /// Constante BUFFER_SIZE 
        /// </summary>
        private const int BUFFER_SIZE = 4096;

        /// <summary>
        /// Constante DEFAULT_TIMEOUT
        /// </summary>
        private const int DEFAULT_TIMEOUT = 60000;

        #endregion

        #region Atributos

        /// <summary>
        /// Atributo locationUrl
        /// </summary>
        private Uri locationUrl;

        /// <summary>
        /// Atributo acceptLanguage
        /// </summary>
        private string acceptLanguage;

        /// <summary>
        /// Atributo acceptEncoding
        /// </summary>
        private string acceptEncoding;

        /// <summary>
        /// Atributo accept
        /// </summary>
        private string accept;

        /// <summary>
        /// Atributo userAgent
        /// </summary>
        private string userAgent;

        /// <summary>
        /// Atributo acceptCharset
        /// </summary>
        private string acceptCharset;

        /// <summary>
        /// Atributo timeout
        /// </summary>
        private int timeout;

        #endregion

        #region Construtores

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public TWebRequest()
        {
        }

        /// <summary>
        /// Destrutor
        /// </summary>
        ~TWebRequest()
        {
        }

        #endregion

        #region Eventos

        /// <summary>
        /// Evento para request complete.
        /// </summary>
        public event EventHandler<TWebRequestEventArgs> RequestComplete;

        /// <summary>
        /// Evento para request close.
        /// </summary>
        public event EventHandler<TWebRequestEventArgs> RequestClose;

        /// <summary>
        /// Evento para request error
        /// </summary>
        public event EventHandler<TWebRequestEventArgs> RequestError;

        #endregion

        #region Propriedades

        /// <summary>
        /// Propridade Url
        /// </summary>
        [Category("Behavior")]
        [Editor("System.Web.UI.Design.UrlEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
        [DefaultValue("")]
        public Uri Url
        {
            get
            {
                return this.locationUrl;
            }
            set
            {
                this.locationUrl = value;

                this.Navigate(value);
            }
        }

        /// <summary>
        /// Propriedade AcceptLanguage
        /// </summary>
        [Category("Behavior")]
        [DefaultValue("pt-BR")]
        public string AcceptLanguage
        {
            get
            {
                if (string.IsNullOrEmpty(this.acceptLanguage))
                {
                    this.acceptLanguage = "pt-BR";
                }
                return this.acceptLanguage;
            }
            set
            {
                this.acceptLanguage = value;
            }
        }

        /// <summary>
        /// Propriedade AcceptEncoding
        /// </summary>
        [Category("Behavior")]
        [DefaultValue("gzip, deflate")]
        public string AcceptEncoding
        {
            get
            {
                if (string.IsNullOrEmpty(this.acceptEncoding))
                {
                    this.acceptEncoding = "gzip, deflate";
                }
                return this.acceptEncoding;
            }
            set
            {
                this.acceptEncoding = value;
            }
        }

        /// <summary>
        /// Propriedade Accept
        /// </summary>
        [Category("Behavior")]
        [DefaultValue("image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*")]
        public string Accept
        {
            get
            {
                if (string.IsNullOrEmpty(this.accept))
                {
                    this.accept = "image/jpeg, application/x-ms-application, image/gif, application/xaml+xml, image/pjpeg, application/x-ms-xbap, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                }
                return this.accept;
            }
            set
            {
                this.accept = value;
            }
        }

        /// <summary>
        /// Propriedade UserAgent
        /// </summary>
        [Category("Behavior")]
        [DefaultValue("Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1)")]
        public string UserAgent
        {
            get
            {
                if (string.IsNullOrEmpty(this.userAgent))
                {
                    this.userAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1)";
                }
                return this.userAgent;
            }
            set
            {
                this.userAgent = value;
            }
        }

        /// <summary>
        /// Propriedade AcceptCharset
        /// </summary>
        [Category("Behavior")]
        [DefaultValue("ISO-8859-1,utf-8,*")]
        public string AcceptCharset
        {
            get
            {
                if (string.IsNullOrEmpty(this.acceptCharset))
                {
                    this.acceptCharset = "ISO-8859-1,utf-8,*";
                }
                return this.acceptCharset;
            }
            set
            {
                this.acceptCharset = value;
            }
        }

        /// <summary>
        /// Propriedade Timeout
        /// </summary>
        [Category("Behavior")]
        [DefaultValue(60000)]
        public int Timeout
        {
            get
            {
                if (this.timeout <= 0)
                {
                    this.timeout = DEFAULT_TIMEOUT;
                }
                return this.timeout;
            }
            set
            {
                this.timeout = value;
            }
        }

        #endregion

        #region Metodos

        /// <summary>
        /// Método que inicia a navegação de url.
        /// </summary>
        /// <param name="url">A url para navegação.</param>
        public void Navigate(Uri url)
        {
            this.Navigate(url, string.Empty);
        }

        /// <summary>
        /// Método que re-inicia a navegação de url com post.
        /// </summary>
        /// <param name="url">A url para navegação.</param>
        /// <param name="postData">Os dados de post (ex: campo1=valor1&campo2=valor2).</param>
        public void Navigate(Uri url, string postData)
        {
            try
            {
                // armazenando
                this.locationUrl = url;

                // criando webrequest
                TWebRequest webrequest = new TWebRequest();
                webrequest.Accept = this.Accept;
                webrequest.AcceptCharset = this.AcceptCharset;
                webrequest.AcceptEncoding = this.AcceptEncoding;
                webrequest.AcceptLanguage = this.AcceptLanguage;
                webrequest.Timeout = this.Timeout;
                webrequest.UserAgent = this.UserAgent;
                webrequest.RequestComplete += this.RequestComplete;
                webrequest.RequestError += this.RequestError;
                webrequest.RequestClose += this.RequestClose;

                // criando invoker
                TWebRequestInvoker webinvoker = new TWebRequestInvoker();
                webinvoker.WebRequest = webrequest;
                webinvoker.Url = url;
                webinvoker.PostData = postData;

                // criando tarefa no pool de thread
                ThreadPool.QueueUserWorkItem(new WaitCallback(delegate(object state)
                {
                    TWebRequestInvoker invoker = (TWebRequestInvoker)state;

                    invoker.WebRequest.DoNavigate(invoker.Url, invoker.PostData);

                }), webinvoker);
            }
            catch (WebException wex)
            {
                // disparando evento error
                this.OnRequestError(new TWebRequestEventArgs() { Url = this.locationUrl, Exception = wex, });
            }
        }

        /// <summary>
        /// Método que faz a chamada internal do 
        /// </summary>
        /// <param name="url">A url para navegação.</param>
        /// <param name="postData">Os dados de post (ex: campo1=valor1&campo2=valor2).</param>
        private void DoNavigate(Uri url, string postData)
        {
            try
            {
                // criando locker
                ManualResetEvent locker = new ManualResetEvent(false);

                // armazenando url
                this.locationUrl = url;

                // criando a solicitacao da url
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.locationUrl);
                request.Headers.Add("Accept-Language", this.AcceptLanguage);
                request.Headers.Add("Accept-Encoding", this.AcceptEncoding);
                request.Headers.Add("Accept-Charset", this.AcceptCharset);
                request.Accept = this.Accept;
                request.ContentLength = 0;
                request.KeepAlive = true;
                request.Method = "GET";
                request.Timeout = this.Timeout;
                request.UseDefaultCredentials = true;
                request.UserAgent = this.UserAgent;

                // criando o estado do solicitacao
                TWebRequestState requestState = new TWebRequestState();
                requestState.Request = request;
                requestState.Locker = locker;

                // verificando metodo da solicitacao
                if (!string.IsNullOrWhiteSpace(postData))
                {
                    // convertando dados do psot
                    requestState.PostData = Encoding.UTF8.GetBytes(postData);

                    // configurando o post
                    request.Method = "POST";
                    request.Referer = this.locationUrl.ToString();
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = requestState.PostData.Length;

                    // iniciando callback da solicitacao
                    IAsyncResult requestAsyncResult = request.BeginGetRequestStream(new AsyncCallback(this.RequestCallback), requestState);

                    // registrando processo assincrono da solicitacao
                    ThreadPool.RegisterWaitForSingleObject(requestAsyncResult.AsyncWaitHandle, new WaitOrTimerCallback(this.TimeoutCallback), request, this.Timeout, true);

                    // aguardando liberado do recurso de solicitacao
                    locker.WaitOne();
                }

                // iniciando callback de resposta
                IAsyncResult responseAsyncResult = (IAsyncResult)request.BeginGetResponse(new AsyncCallback(this.ResponseCallback), requestState);

                // registrando processo assincrono
                ThreadPool.RegisterWaitForSingleObject(responseAsyncResult.AsyncWaitHandle, new WaitOrTimerCallback(this.TimeoutCallback), requestState, this.Timeout, true);

                // aguardando liberado do recurso de resposta
                locker.WaitOne();
            }
            catch (WebException wex)
            {
                // disparando evento error
                this.OnRequestError(new TWebRequestEventArgs() { Url = this.locationUrl, Exception = wex, });
            }
        }

        /// <summary>
        /// Método que faz a chamada internal do 
        /// </summary>
        /// <param name="url">A url para navegação.</param>
        public TWebRequestEventArgs Download(Uri url)
        {
            try
            {
                // armazenando url
                this.locationUrl = url;

                // criando a solicitacao da url
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.locationUrl);
                request.Headers.Add("Accept-Language", this.AcceptLanguage);
                request.Headers.Add("Accept-Encoding", this.AcceptEncoding);
                request.Headers.Add("Accept-Charset", this.AcceptCharset);
                request.Accept = this.Accept;
                request.ContentLength = 0;
                request.KeepAlive = true;
                request.Method = "GET";
                request.Timeout = this.Timeout;
                request.UseDefaultCredentials = true;
                request.UserAgent = this.UserAgent;

                // recuperar a resposta
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                // recuperando stream da resposta
                Stream responseStream = response.GetResponseStream();

                // verificando compressao
                if (response.ContentEncoding.Contains("gzip"))
                {
                    responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                    responseStream.Flush();
                }
                else if (response.ContentEncoding.Contains("deflate"))
                {
                    responseStream = new DeflateStream(responseStream, CompressionMode.Decompress);
                    responseStream.Flush();
                }

                // criando evento
                TWebRequestEventArgs e = new TWebRequestEventArgs();
                e.Url = this.locationUrl;
                e.Stream = responseStream;

                // verificando resposta
                string contextType = response.ContentType;

                // verificando o conteudo da resposta
                if (contextType.Contains("html"))
                {
                    // criando streamd e leitura da resposta
                    StreamReader streamReader = new StreamReader(responseStream);

                    // lendo a resposta
                    string htmlString = streamReader.ReadToEnd();

                    // criando documento html DOM
                    e.Document = new HtmlDocument();

                    // convertendo resposta string em DOM
                    e.Document.LoadHtml(htmlString);
                }
                else if (contextType.Contains("image"))
                {
                    // conversando resposta stream em image
                    e.Image = Image.FromStream(responseStream);
                }

                // fechando o response
                response.Close();

                // retornando
                return e;
            }
            catch (WebException wex)
            {
                // retornando
                return new TWebRequestEventArgs() { Url = this.locationUrl, Exception = wex, };
            }
        }

        #endregion

        #region Metodos Callbacks

        /// <summary>
        /// Evento callback para tratar a solicitacao.
        /// </summary>
        /// <param name="asyncResult">A chamada assincrona.</param>
        private void RequestCallback(IAsyncResult asyncResult)
        {
            // recuperar estado da solicitcao
            TWebRequestState requestState = (TWebRequestState)asyncResult.AsyncState;

            try
            {
                // recuperar a solicitacao
                HttpWebRequest request = requestState.Request;

                // recuperando stream da solicitacao
                Stream postStream = request.EndGetRequestStream(asyncResult);

                // escrevendo os dados do post
                postStream.Write(requestState.PostData, 0, requestState.PostData.Length);

                // fechando stream de escrita
                postStream.Close();
            }
            catch (WebException wex)
            {
                // disparando evento error
                this.OnRequestError(new TWebRequestEventArgs() { Url = this.locationUrl, Exception = wex, });
            }
            finally
            {
                // liberando recurso
                requestState.Locker.Set();
            }
        }

        /// <summary>
        /// Evento callback para tratar a resposta da solicitacao.
        /// </summary>
        /// <param name="asyncResult">A chamada assincrona.</param>
        private void ResponseCallback(IAsyncResult asyncResult)
        {
            // recuperar estado da solicitcao
            TWebRequestState requestState = (TWebRequestState)asyncResult.AsyncState;

            try
            {
                // recuperar a solicitacao
                HttpWebRequest request = requestState.Request;

                // recuperar a resposta
                requestState.Response = (HttpWebResponse)request.EndGetResponse(asyncResult);

                // recuperando stream da resposta
                Stream responseStream = requestState.Response.GetResponseStream();

                // verificando compressao
                if (requestState.Response.ContentEncoding.Contains("gzip"))
                {
                    responseStream = new GZipStream(responseStream, CompressionMode.Decompress);
                    responseStream.Flush();
                }
                else if (requestState.Response.ContentEncoding.Contains("deflate"))
                {
                    responseStream = new DeflateStream(responseStream, CompressionMode.Decompress);
                    responseStream.Flush();
                }

                // criando evento
                TWebRequestEventArgs e = new TWebRequestEventArgs();
                e.Url = this.locationUrl;
                e.Stream = responseStream;

                // verificando resposta
                string contextType = requestState.Response.ContentType;

                // verificando o conteudo da resposta
                if (contextType.Contains("html"))
                {
                    // criando streamd e leitura da resposta
                    StreamReader streamReader = new StreamReader(responseStream);

                    // lendo a resposta
                    string htmlString = streamReader.ReadToEnd();

                    // criando documento html DOM
                    e.Document = new HtmlDocument();

                    // convertendo resposta string em DOM
                    e.Document.LoadHtml(htmlString);

                    // fechando o response
                    requestState.Response.Close();
                }
                else if (contextType.Contains("image"))
                {
                    // conversando resposta stream em image
                    e.Image = Image.FromStream(responseStream);

                    // fechando o response
                    requestState.Response.Close();
                }

                // disparando evento complete
                this.OnRequestComplete(e);
            }
            catch (WebException wex)
            {
                // disparando evento error
                this.OnRequestError(new TWebRequestEventArgs() { Url = this.locationUrl, Exception = wex, });
            }
            finally
            {
                // limpando dados
                requestState.PostData = null;

                // fechando resposta da solicitacao
                if (requestState.Response != null)
                {
                    requestState.Response.Close();
                }

                // liberando recurso
                requestState.Locker.Set();

                // disparando evento complete
                this.OnRequestClose(new TWebRequestEventArgs() { Url = this.locationUrl });
            }
        }

        /// <summary>
        /// Evento para timeout.
        /// </summary>
        /// <param name="state">O estado.</param>
        /// <param name="timedOut">O timeout.</param>
        private void TimeoutCallback(object state, bool timedOut)
        {
            // se timeout
            if (timedOut)
            {
                // recuperar estado da solicitcao
                TWebRequestState requestState = (TWebRequestState)state;

                // recuperar a solicitacao
                HttpWebRequest request = requestState.Request;

                // validando a solicitacao
                if (request != null)
                {
                    // abortando
                    request.Abort();
                }

                // liberando recurso
                requestState.Locker.Set();
            }
        }

        #endregion

        #region Classes Internas

        /// <summary>
        /// Classe para queue da solicitação
        /// </summary>
        private class TWebRequestInvoker
        {
            /// <summary>
            /// Atributo WebRequest
            /// </summary>
            public TWebRequest WebRequest { get; set; }

            /// <summary>
            /// Atributo Url
            /// </summary>
            public Uri Url { get; set; }

            /// <summary>
            /// Atributo PostData
            /// </summary>
            public string PostData { get; set; }
        }

        /// <summary>
        /// Classe para estado da solicitação
        /// </summary>
        private class TWebRequestState
        {
            /// <summary>
            /// Atributo Request
            /// </summary>
            public HttpWebRequest Request = null;

            /// <summary>
            /// Atributo Response
            /// </summary>
            public HttpWebResponse Response = null;

            /// <summary>
            /// Atributo PostData
            /// </summary>
            public byte[] PostData = null;

            /// <summary>
            /// Atributo Locker
            /// </summary>
            public ManualResetEvent Locker { get; set; }
        }

        #endregion

        #region Metodos dos Eventos

        /// <summary>
        /// Método do evento complete
        /// </summary>
        /// <param name="e">O evento.</param>
        public void OnRequestComplete(TWebRequestEventArgs e)
        {
            if (this.RequestComplete != null)
            {
                this.RequestComplete(this, e);
            }
        }

        /// <summary>
        /// Método do evento close
        /// </summary>
        /// <param name="e">O evento.</param>
        public void OnRequestClose(TWebRequestEventArgs e)
        {
            if (this.RequestClose != null)
            {
                this.RequestClose(this, e);
            }
        }

        /// <summary>
        /// Método do evento error
        /// </summary>
        /// <param name="e">O evento.</param>
        public void OnRequestError(TWebRequestEventArgs e)
        {
            if (this.RequestError != null)
            {
                this.RequestError(this, e);
            }
        }

        #endregion
    }
}
