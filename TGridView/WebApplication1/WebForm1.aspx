<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<%@ Register Assembly="Arquitetura.Web.WC.TGridView" Namespace="Arquitetura.Web.WebControls"
    TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <cc1:TGridView ID="GridView1" AllowPaging="true" AllowSorting="true" CustomPagerMode="NumericNextPreviousFirstLast"
            CustomPagerShowDots="true" runat="server" PagerSettings-FirstPageText="Primeiro"
            PagerSettings-LastPageText="Último" PagerSettings-NextPageText="Próximo" PagerSettings-PreviousPageText="Anterior"
            PagerSettings-PageButtonCount="20" AutoGenerateColumns="false" Width="100%">
            <Columns>
                <asp:BoundField DataField="NOM_ARQUIVO" SortExpression="NOM_ARQUIVO" HeaderText="NomeArquivo" />
                <asp:BoundField DataField="NOM_ARQUIVO_SERVIDOR" SortExpression="NOM_ARQUIVO_SERVIDOR"
                    HeaderText="NomeArquivoServidor" />
            </Columns>
        </cc1:TGridView>
        <%--<asp:LinqDataSource ID="DataSource1" runat="server" ContextTypeName="WebApplication1.Entidades.CmaWebContext"
            TableName="CAD_ARQUIVO" AutoSort="true" AutoPage="true" AutoGenerateOrderByClause="false"
            AutoGenerateWhereClause="false" Where="SEQ_ARQUIVO <= 33" OrderBy="SEQ_ARQUIVO">
        </asp:LinqDataSource>--%>
        <%--<asp:SqlDataSource ID="DataSource1" runat="server" DataSourceMode="DataSet" ConnectionString="<%$ConnectionStrings:CmaWeb2%>"
            SelectCommand="SELECT * FROM CAD_ARQUIVO WHERE SEQ_ARQUIVO <= 33"></asp:SqlDataSource>--%>
        <%--<asp:ObjectDataSource ID="DataSource1" runat="server" SelectMethod="GetArquivos"
            TypeName="WebApplication1.Entidades.CtrlArquivo" SortParameterName="sortExpression">
        </asp:ObjectDataSource>--%>
        <!--SortParameterName="sortExpression" StartRowIndexParameterName="pageIndex" MaximumRowsParameterName="pageSize"-->
    </div>
    </form>
</body>
</html>
