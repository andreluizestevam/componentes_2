<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="WebApplication1.UploadFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<input id="fileupload" type="file" name="files[]" data-url="<%=ResolveUrl("FileUpload.ashx") %>" multiple>

    <script src="JavaScript/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="jQuery-File-Upload-master/js/vendor/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="jQuery-File-Upload-master/js/jquery.iframe-transport.js" type="text/javascript"></script>
    <script src="jQuery-File-Upload-master/js/jquery.fileupload.js" type="text/javascript"></script>
    <script src="Grid/JavaScript/js/i18n/grid.locale-pt-br.js" type="text/javascript"></script>
    <script language="javascript">
//        var divProgress = null;
//        function progressDiv() {

//            $.ajax({
//                url: '<%=ResolveUrl("UploadSession.ashx") %>',
//                success: function (data) {
//                    var a = $jsonParse(data);
//                }
//            });

//            if (divProgress == null) {
//                divProgress = $("#dvProgress");
//            }

//            for (var i = 0; i < 300; i++) {
//                divProgress.width(i);
//            }
//        }

        var modelo = '<div class="grd_Cabecalho largura80 float_E">FileName</div><div class="grd_Cabecalho largura10 float_E">Download</div><div class="grd_Cabecalho largura10 float_E">Excluir</div>';

        $(function () {

          
                $('#fileupload').fileupload({
                    dataType: 'json',
                    done: function (e, data) {
                        $.each(data.result.files, function (index, file) {
                            $('<p/>').text(file.name).appendTo(document.body);
                        });
                    }
                });



//            $('#xx').fileupload({
//                replaceFileInput: false,
//                dataType: 'json',
//                url: '<%=ResolveUrl("FileUpload.ashx") %>',
//                add: function (e, data) {
//                    //setTimeout(progressDiv, 500);
//                    data.submit();
//                },

//                done: function (e, data) {
//                    $.each(data.result, function (index, file) {
//                        debugger;
//                        var texto = modelo.replace('FileName', file[0].Name);

//                        $(texto).appendTo('#divResultado');
//                    });
//                }
//            });
        });
    </script>
    <form id="form1" runat="server">
    <div>
        <div >
            <input id="xx" type="file" name="file" multiple="multiple" runat="server" clientidmode="Static">
        </div>
        <div>
            <img src="../Images/error.gif" onclick="javascript:xx.click();" />
        </div>
        <div class="grd_Cabecalho largura80 float_E">
            Planta
        </div>
        <div class="grd_Cabecalho largura10 float_E">
            Download
        </div>
        <div class="grd_Cabecalho largura10 float_E">
            Excluir
        </div>
        <div id="divResultado">
        </div>
    </div>
    </form>
</body>
</html>
