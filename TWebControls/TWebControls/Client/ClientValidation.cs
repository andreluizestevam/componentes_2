
using System;
using System.Collections.Generic;
namespace Arquitetura.Web.WebControls.JavaScript
{
    /// <summary>
    /// Classe para ser convertida para Json no cliente por isto deve obedecer o formato de construção de javascript, com a primeira em minúsculo
    /// Parametros usados na classe TechBiz.fieldValueValidate.js
    /// </summary>
    public sealed class ClientValidation
    {
        public bool? required { get; set; }
        public string customJS { get; set; }
        public string serverVltd { get; set; }
        public string validaRegex { get; set; }
        public bool? focusInvalid { get; set; }
        public CustomMessages messages { get; set; }
        public bool? telefone { get; set; }
        public bool? cnpj { get; set; }
        public bool? cpf { get; set; }
        public bool? date { get; set; }
        public bool? hourDay { get; set; }
        public bool? hourAmount { get; set; }
        public bool? email { get; set; }
        public int? minTam { get; set; }
        public int? minCheck { get; set; }
        public List<Decimal> rangeDecimal { get; set; }
    }

    /// <summary>
    /// Classe para ser convertida para Json no cliente por isto deve obedecer o formato de construção de javascript, com a primeira em minúsculo
    /// Parametros usados na classe TechBiz.fieldValueValidate.js
    /// </summary>
    public sealed class CustomMessages
    {
        public string required { get; set; }
        public string customJS { get; set; }
        public string validaRegex { get; set; }
    }

    /// <summary>
    /// Classe para ser convertida para Json no cliente por isto deve obedecer o formato de construção de javascript, com a primeira em minúsculo
    /// Parametros usados na classe TechBiz.fieldValueValidate.js
    /// </summary>
    public sealed class CustomTextArea
    {
        public string maxLength { get; set; }
    }

    ///// <summary>
    ///// Classe para ser convertida para Json no cliente por isto deve obedecer o formato de construção de javascript, com a primeira em minúsculo
    ///// </summary>
    //public sealed class TextArea
    //{
    //    public bool exibirTotal { get; set; }
    //    public string maxLength { get; set; }
    //}

    ///// <summary>
    ///// Classe para ser convertida para Json no cliente por isto deve obedecer o formato de construção de javascript, com a primeira em minúsculo
    ///// </summary>
    //public sealed class DropDownList
    //{
    //}
}
