<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Serialize.aspx.cs" Inherits="Serialize" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="JavaScript/jquery-1.7.2.min.js" type="text/javascript"></script>
    <%-- 
    <script src="JavaScript/jquery.livequery.min.js" type="text/javascript"></script>
    <script src="JavaScript/TechBiz.jquery.messageBox.js" type="text/javascript"></script>
    <script src="JavaScript/TechBiz.jquery.fieldValidationServer.js" type="text/javascript"></script>
    <script src="JavaScript/TechBiz.jquery.textAreaControl.js" type="text/javascript"></script>
    --%>
    <script src="JavaScript/jquery-ui-1.8.20.custom.min.js" type="text/javascript"></script>
    <script src="JavaScript/jquery-ui-timepicker-addon.js" type="text/javascript"></script>


     <script language="javascript">

         function aa() {
             var i = $('#form1').serializeArray();
         }

    </script>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ListBox ID="ListBox1" runat="server">
            <asp:ListItem>d</asp:ListItem>
            <asp:ListItem>c</asp:ListItem>
            <asp:ListItem>b</asp:ListItem>
            <asp:ListItem>a</asp:ListItem>
        </asp:ListBox>
        <input type="button" onclick="aa();" value="ok" />
    </div>
    </form>
</body>
</html>
