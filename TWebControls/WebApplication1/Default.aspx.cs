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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //http://onehackoranother.com/projects/jquery/tipsy/#

        //http://labs.abeautifulsite.net/archived/jquery-alerts/demo/

        //http://craigsworks.com/projects/qtip/demos/

        //http://www.jacklmoore.com/colorbox/example5/


        //http://fgnass.github.com/spin.js/

        //http://jsfiddle.net/jonathansampson/VpDUG/170/

        //string a = string.Concat("$.messageBox(", Teste2(), ")");

       // this.Page.ClientScript.RegisterClientScriptBlock(typeof(string), "aa", a, true);

        TResponseClient a = new TResponseClient("aa");

        var aa = a.ToJson();
        
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


    [WebMethod(EnableSession = true)]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    private string Valida()
    {
        TResponseClient response = new TResponseClient();

        TClientMessage me = new TClientMessage(EMessageButtonType.YesOrNo);
        me.Message = "Dados inválidos";
        me.ButtonYes.Behavior = EMessageBehavior.StayOnField;
        me.WindowSize = new System.Drawing.Size(600, 200);

        response.Message = me;
        
        return response.ToJson();
    }

}