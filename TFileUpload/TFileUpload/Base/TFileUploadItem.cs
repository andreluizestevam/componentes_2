using System;

namespace Arquitetura.Web.WebControls
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public sealed class TFileUploadItem
    {
        #region Propriedades

        /// <summary>
        /// O nome do arquivo.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// O caminho do arquivo.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// O tamanho do arquivo.
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// O tipo de conteúdo do arquivo.
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// O conteúdo binário do arquivo.
        /// </summary>
        public byte[] Bytes { get; set; }

        #endregion
    }
}
