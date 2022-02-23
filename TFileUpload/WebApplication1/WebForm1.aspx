<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<%@ Register Assembly="Arquitetura.Web.WC.TFileUpload" Namespace="Arquitetura.Web.WebControls"
    TagPrefix="wc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function fillCell(row, cellNumber, text) {
            var cell = row.insertCell(cellNumber);
            cell.innerHTML = text;
        }
        function addToClientTable(name, text) {
            var table = document.getElementById("<%= afutb.ClientID %>");
            var row = table.insertRow(0);
            fillCell(row, 0, name);
            fillCell(row, 1, text);
        }

        function uploadError(sender, args) {
            addToClientTable(args.get_fileName(), "<span style='color:red;'>" + args.get_errorMessage() + "</span>");
        }
        function uploadComplete(sender, args) {
            var contentType = args.get_contentType();
            var text = args.get_length() + " bytes";

            if (contentType.length > 0) {
                text += ", '" + contentType + "'";
            }

            addToClientTable(args.get_fileName(), text);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" EnablePartialRendering="true" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <ajax:AsyncFileUpload ID="afu" ClientIDMode="AutoID" PersistFile="false" UploadingBackColor="#E5E3FF"
                    ErrorBackColor="#FFE7D5" CompleteBackColor="#E3F9D5" Width="400px" ThrobberID="afuthb"
                    UploaderStyle="Modern" OnClientUploadError="uploadError" OnClientUploadComplete="uploadComplete"
                    runat="server" />
                <table id="afutb" runat="server">
                </table>
                <asp:Button ID="Button1" runat="server" Text="Button" />
                <%--<textarea id="traceConsole" rows="10" cols="50"></textarea>--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
<!-- OnUploadedComplete="fileUpload1_UploadedComplete" -->
