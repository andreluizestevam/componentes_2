<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.Grid.WebForm1" %>

<%@ Register Assembly="Arquitetura.Web.WebControls.Grid" Namespace="Arquitetura.Web.WebControls.Grid"
    TagPrefix="TGrd" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link href="../CSS/jquery-ui-1.8.21.custom.css" rel="stylesheet" type="text/css" />
    <link href="JavaScript/css/ui.jqgrid.css" rel="stylesheet" type="text/css" />
    <script src="../JavaScript/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="JavaScript/js/i18n/grid.locale-pt-br.js" type="text/javascript"></script>
    <script src="JavaScript/js/jquery.jqGrid.src.js" type="text/javascript"></script>
    <title></title>
</head>
<body>
    <script>
        //        $(document).ready(function () {
        //            var grid = $('#grid-grdTeste');
        //            grid.jqGrid({
        //                datatype: chamaDados,
        //                colNames: ["nome", "telefone"],
        //                colModel:
        //            [
        //                { "name": "nome", "index": 0, "width": 100 },
        //                { "name": "telefone", "index": 0, "width": 100, formatter: 'date' }
        //            ],
        //                rowNum: 10,
        //                rowList: [10, 20, 30],
        //                sortorder: "asc",
        //                viewrecords: true,
        //                height: "100%",
        //                sortName: "nome"
        //            });

        //            function chamaDados(dataPost) {
        //                debugger;
        //                $.ajax({
        //                    url: 'WebForm1.aspx/GetDados',
        //                    type: "POST",
        //                    contentType: "application/json; charset=utf-8",
        //                    dataType: "json",
        //                    success: function (data, st) {
        //                        if (st == "success") {
        //                            var dataJson = $.parseJSON(data.d)
        //                            grid.jqGrid('clearGridData');
        //                            var m = dataJson.rows.length;
        //                            for (var i = 0; i < m; i++) {
        //                                grid.addRowData(i + 1, dataJson.rows[i]);
        //                            }
        //                        }
        //                    },
        //                    error: function (error) {
        //                        debugger;
        //                        alert("Error with AJAX callback");
        //                    }
        //                });
        //            }

        //        });

        $(document).ready(function () {
            var grid = $('#grid-grdTeste');
            grid.jqGrid({
                url: 'WebForm1.aspx/GetDados',
                mtype: 'POST',
                datatype: 'json',
                ajaxGridOptions: { contentType: "application/json" },
                serializeGridData: function (postData) {
                    var propertyName, propertyValue, dataToSend = {};
                    for (propertyName in postData) {
                        if (postData.hasOwnProperty(propertyName)) {
                            propertyValue = postData[propertyName];
                            if ($.isFunction(propertyValue)) {
                                dataToSend[propertyName] = propertyValue();
                            } else {
                                dataToSend[propertyName] = propertyValue
                            }
                        }
                    }
                    return JSON.stringify(dataToSend);
                },
                jsonReader: {
                    root: "d.rows",
                    page: "d.page",
                    total: "d.total",
                    records: "d.records"
                },
                colNames: ["nome", "telefone"],
                colModel:
            [
                { "name": "nome", "index": 0, "width": 200 },
                { "name": "telefone", "index": 0, "width": 200, formatter: 'date' }
            ],
                rowNum: 10,
                rowList: [10, 20, 30],
                sortorder: "asc",
                viewrecords: true,
                height: "auto",
                sortName: "nome",
                loadtext: "Aguarde....",
                shrinkToFit: false,
                autowidth: true,
                pager: '#pager-grdTeste',
                emptyrecords: "Nenhum registro foi encontrado."
            });

            $('#grid-grdTeste').jqGrid('navGrid', '#pager-grdTeste', { edit: false, add: false, del: true, excel: false, search: false });
        });

    </script>
    <form id="form1" runat="server">
    <div>
        <ul>
            <li>a</li>
            <li>a1</li>
            <li>a2</li>
            <li>a3</li>
        </ul>
        <div style="float: right">
            <ul>
                <li>a</li>
                <li>a1</li>
                <li>a2</li>
                <li>a3</li>
            </ul>
        </div>
    </div>
    <div>
        <TGrd:TGrid ID="grdTeste" runat="server" Width="450px">
        </TGrd:TGrid>
    </div>
    </form>
</body>
</html>
