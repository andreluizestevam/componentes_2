using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Arquitetura.Web.WebControls.Messages;

public partial class Messages : System.Web.UI.Page
{
    TClientMessage message;

    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected override void OnPreRender(EventArgs e)
    {
        if (message != null)
        {
            string a = string.Concat("$.messageBox(", message.ToJson(), ")");

            this.Page.ClientScript.RegisterClientScriptBlock(typeof(string), "aa", a, true);
        }

        base.OnPreRender(e);
    }

    protected void btnErro_Click(object sender, EventArgs e)
    {
        message = new TClientMessage(Arquitetura.Web.WebControls.EMessageButtonType.Error, "Erro ao tentar salvar os dados");
    }

    protected void btnConfirmacao_Click(object sender, EventArgs e)
    {
        message = new TClientMessage(Arquitetura.Web.WebControls.EMessageButtonType.YesOrNoOrCancel, "Erro ao tentar salvar os dados");
        message.Title = "Confirma????";
        message.WindowSize = new System.Drawing.Size(600, 500);
    }
    
    protected void btnAlerta_Click(object sender, EventArgs e)
    {
        message = new TClientMessage("Dados salvos com sucesso!");
    }

    protected void BtnConfirmacao1_Click(object sender, EventArgs e)
    {
        message = new TClientMessage(Arquitetura.Web.WebControls.EMessageButtonType.YesOrNo, "Erro ao tentar salvar os dados");
    }
}