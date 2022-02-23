<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Mascaras.aspx.cs" EnableEventValidation="false"
    Inherits="Default2" %>

<%@ Register Assembly="Arquitetura.Web.WebControls" Namespace="Arquitetura.Web.WebControls"
    TagPrefix="tb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <script src="JavaScript/jquery-1.7.2.min.js" type="text/javascript"></script>
    
    <script src="JavaScriptControle/jquery-ui-1.8.20.custom.min.js" type="text/javascript"></script>
    <script src="JavaScriptControle/jquery-ui-timepicker-addon.js" type="text/javascript"></script>
    <script src="JavaScriptControle/JqueryValidation/jquery.validate.js" type="text/javascript"></script>
    <script src="JavaScriptControle/jquery.inputmask.js" type="text/javascript"></script>
    <script src="JavaScriptControle/jquery.inputmask.extentions.js" type="text/javascript"></script>
    <script src="JavaScriptControle/jquery.inputmask.numeric.extentions.js" type="text/javascript"></script>
    <script src="JavaScriptControle/jquery.inputmask.date.extentions.js" type="text/javascript"></script>
    <script src="JavaScriptControle/TechBiz.jquery.formatInputs.js" type="text/javascript"></script>
    <script src="JavaScriptControle/TechBiz.fieldValueValidate.js" type="text/javascript"></script>
    <script src="JavaScriptControle/TechBiz.jquery.textAreaControl.js" type="text/javascript"></script>
    <%-- TESTES THALES--%>
    <script src="JavaScriptControle/jquery.metadata.js" type="text/javascript"></script>
    <script src="JavaScriptJavaScriptControle/jquery.searchabledropdown-1.0.7.src.js" type="text/javascript"></script>
    <script src="JavaScriptControle/Techbiz.jquery.multiSelectControl.js" type="text/javascript"></script>
    <%-- TESTES THALES --%>
    <script src="JavaScriptControle/Techbiz.js" type="text/javascript"></script>
    <link href="css/jquery-ui-1.8.21.custom.css" rel="stylesheet" type="text/css" />
    <link href="css/Control.css" rel="stylesheet" type="text/css" />
    <title></title>
</head>
<body>
    <form id="frmPrincipal" runat="server">
    <div>
        <div class="requiredRadio">
            <%--<label id="horariodefuncionamentocomercial" class="labelClass">
                Horário de Funcionamento Comercial:</label>
            <tb:TRadioButton ID="rbH24HorarioFuncionamento" GroupName="horariodefuncionamentocomercial"
                runat="server" Text="H24" Validation-Required="True" Validation-ServerValidator=""
                Required="True" />
            <tb:TRadioButton ID="rbHorasHorarioFuncionamento" GroupName="horariodefuncionamentocomercial"
                runat="server" CssClass="labelClass largura7 float_E mgm_top5" Validation-ServerValidator="" />
            <tb:TRadioButton ID="rbNAHorarioFuncionamento" GroupName="horariodefuncionamentocomercial"
                runat="server" Text="Não Aplicável" />
            <asp:Button ID="Button1" runat="server" Text="Button" />--%>
            <tb:TDropDownList ID="TDropDownList1" Width="200px" runat="server" Label-LabelText="Teste DropDownList"
                Validation-Required="True" Validation-RequiredErrorText="É obrigatório este campo!!!!!!"
                AutoPostBack="True">
            </tb:TDropDownList>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Ver Selecionados" OnClick="Button1_Click" />
        <tb:TCheckBoxList ID="TCheckBoxList1" runat="server" Label-LabelText="CheckBoxList"
            Validation-Required="True" Validation-RequiredErrorText="Preenchimento Obrigatório">
            <asp:ListItem Value="1">Thales</asp:ListItem>
            <asp:ListItem Value="2">Henrique</asp:ListItem>
            <asp:ListItem Value="3">Ferreira</asp:ListItem>
            <asp:ListItem Value="4">Drosghic</asp:ListItem>
        </tb:TCheckBoxList>
        <tb:TRadioButtonList ID="TRadioButtonList1" runat="server" Validation-Required="true"
            Validation-RequiredErrorText="Obrigatório" Label-LabelText="RADIO BUTTONS">
            <asp:ListItem Value="1">teste</asp:ListItem>
            <asp:ListItem Value="2">atettete</asp:ListItem>
            <asp:ListItem Value="3">asdfhtertyu</asp:ListItem>
        </tb:TRadioButtonList>
        <tb:TCheckBox ID="TCheckBox1" runat="server" Text="INFRAERO" CssClass="cp_100" />
        <tb:TTextBox ID="TTextBox3" runat="server" Label-LabelText="Inteiro" MaskType="Integer"
            MaxLength="5" Validation-Required="True"></tb:TTextBox>
        <tb:TTextBox ID="TTextBox15" runat="server" Label-LabelText="Inteiro Sinal" MaskType="SignedInteger"
            MaxLength="5"></tb:TTextBox>
        <tb:TTextBox ID="TTextBox11" runat="server" Label-LabelText="Decimal" MaskType="Decimal"
            MaxLength="10"></tb:TTextBox>
        <tb:TTextBox ID="TTextBox14" runat="server" Label-LabelText="Decimal Sinal" MaskType="SignedDecimal"
            MaxLength="5"></tb:TTextBox>
        <tb:TTextBox ID="TTextBox5" runat="server" FieldName="SEQUENCIA" Label-LabelText="CNPJ"
            MaxLength="20" MaskType="CNPJ"></tb:TTextBox>
        <tb:TTextBox ID="TTextBox8" runat="server" Label-LabelText="CPF" MaskType="CPF" MaxLength="20"></tb:TTextBox>
        <tb:TTextBox ID="TTextBox17" runat="server" Label-LabelText="Hora Dia" MaskType="HourDay"
            MaxLength="20"></tb:TTextBox>
        <tb:TTextBox ID="TTextBox12" runat="server" Label-LabelText="Total Horas" MaskType="HourAmount"
            MaxLength="20"></tb:TTextBox>
        <tb:TTextBox ID="TTextBox13" runat="server" Label-LabelText="Mes/Ano" MaskType="MonthAndYear"
            MaxLength="20"></tb:TTextBox>
        <tb:TTextBox ID="TTextBox16" runat="server" Label-LabelText="Ano" MaskType="Year"
            MaxLength="20"></tb:TTextBox>
        <tb:TTextBox ID="TTextBox7" runat="server" Label-LabelText="CEP" MaskType="CEP" MaxLength="20"></tb:TTextBox>
        <tb:TTextBox ID="TTextBox18" runat="server" Label-LabelText="Telefone" MaskType="Telefone"
            MaxLength="20"></tb:TTextBox>
        <tb:TTextBox ID="TTextBox19" runat="server" CustomMask="(99) 9999-99999" Label-LabelText="Custom"
            MaskType="Custom" MaxLength="20"></tb:TTextBox>
        <tb:TTextBox ID="TTextBox22" runat="server" Validation-Required="true" ValidationType="Email"
            Label-LabelText="Email" MaxLength="100"></tb:TTextBox>
        <tb:TDateTime ID="TDateTime1" runat="server" Label-LabelText="Date" MaskType="Date"
            UseCalendar="True"></tb:TDateTime>
        <tb:TDateTime ID="TDateTime2" runat="server" Label-LabelText="Date Time" UseCalendar="True"
            MaskType="DateTime"></tb:TDateTime>
        <tb:TTextArea ID="TTextArea1" runat="server" Label-LabelText="Text Area" ShowCounters="true"
            MaxLength="34"></tb:TTextArea>
        <asp:Button ID="Button2" runat="server" Text="Só Submit" OnClick="Button2_Click" />
        <asp:TextBox ID="TextBox1" runat="server" Height="102px" TextMode="MultiLine" Width="251px"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" Height="102px" TextMode="MultiLine" Width="251px"></asp:TextBox>
    </div>
    </form>
</body>
</html>
