using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Arquitetura.Web.WebControls.Messages;
using Arquitetura.Web.WebControls;
using System.Web.Services;
using System.Web.Script.Services;

public partial class FileTeste : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //http://onehackoranother.com/projects/jquery/tipsy/#

        //http://pixeline.be/experiments/jqUploader/test.php

        //http://www.plupload.com/example_all_runtimes.php

        //string a = string.Concat("$.messageBox(", Teste3(), ")");

        //this.Page.ClientScript.RegisterClientScriptBlock(typeof(string), "aa", a, true);

    }

    private string Teste1()
    {
        TClientMessage me = new TClientMessage("Gravado com sucesso!!!");
        return me.ToJson();
    }

    private string Teste3()
    {
        TClientMessage me = new TClientMessage(EMessageButtonType.Board);
        me.Message = "Gravado com sucesso!!!";
        return me.ToJson();
    }

    private string Teste2()
    {
        TClientMessage me = new TClientMessage(EMessageButtonType.YesOrNo);
        me.Message = "Deseja realmente salvar?";
        me.ButtonYes.Behavior = EMessageBehavior.SubmitPage;
        me.WindowSize = new System.Drawing.Size(600, 200);
        return me.ToJson();
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)] 
    private string Valida()
    {
        TClientMessage me = new TClientMessage(EMessageButtonType.YesOrNo);
        me.Message = "Dados inválidos";
        me.ButtonYes.Behavior = EMessageBehavior.StayOnField;
        me.WindowSize = new System.Drawing.Size(600, 200);
        return me.ToJson();
    }

}