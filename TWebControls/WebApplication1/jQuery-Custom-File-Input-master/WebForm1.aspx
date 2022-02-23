<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.jQuery_Custom_File_Input_master.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/basic.css" rel="stylesheet" type="text/css" />
    <script src="../JavaScript/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="js/jQuery.fileinput.js" type="text/javascript"></script>
    <script src="js/example.js" type="text/javascript"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="file">
            <input type="file" id="file" /></div>
        <div >
            <img src="../Images/error.gif" onclick="javascript:file.click();" />
        </div>
    </div>
    </form>
</body>
</html>
