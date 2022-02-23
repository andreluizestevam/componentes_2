<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="WebApplication1.WebForm4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="http://code.jquery.com/jquery-latest.pack.js"></script>
    <script type="text/javascript">

        //select all the a tag with name equal to modal
        function fn_showModal(e) {
            //Cancel the link behavior
            //e.preventDefault();

            //Get the box
            var box = $('#UpdateProgress');

            //Get the screen height and width
            var maskHeight = $(document).height();
            var maskWidth = $(window).width();

            //Set heigth and width to mask to fill up the whole screen
            $('#UpdateProgressModal').css({ 'width': maskWidth, 'height': maskHeight, 'z-index': 9000 });

            //transition effect		
            $('#UpdateProgressModal').show();

            //Set the popup position
            box.css('top', 0);
            box.css('left', 0);
            box.css('z-index', 9999);

            //transition effect
            box.show();
        };

        $(window).resize(function () {
            //Get the box
            var box = $('#UpdateProgress');

            //Get the screen height and width
            var maskHeight = $(document).height();
            var maskWidth = $(window).width();

            //Set height and width to mask to fill up the whole screen
            $('#UpdateProgressModal').css({ 'width': maskWidth, 'height': maskHeight });

            //Get the window height and width
            //var winH = $(window).height();
            //var winW = $(window).width();

            //Set the popup window to center
            box.css('top', 0);
            box.css('left', 0);
        });

    </script>
    <style type="text/css">
        .updateprogress_modalstyle
        {
            left: 0;
            top: 0;
            display: none;
            position: absolute;
            background-color: #ececec;
            filter: alpha(opacity=40);
            opacity: 0.4;
        }
        .updateprogress_contentstyle
        {
            border: 1px solid #696969;
            background-color: #fff;
            margin: 2px;
            padding: 2px;
            top: 0px;
            left: 0px;
        }
        .updateprogress_imagestyle
        {
            vertical-align: middle;
            margin-right: 8px;
        }
        .updateprogress_labelstyle
        {
            color: black;
            font-size: 11px;
            font-weight: bold;
            font-family: Arial;
            letter-spacing: 2px;
        }
        .updateprogress_mainstyle
        {
            display: none;
            position: fixed;
            left: 0px;
            top: 0px;
            width: 200px;
            height: 200px;
            background-color: #fff;
        }
        
        /*        
        #mask
        {
            position: absolute;
            left: 0;
            top: 0;
            z-index: 9000;
            background-color: #000;
            display: none;
        }
        #boxes .window
        {
            position: fixed;
            left: 0;
            top: 0;
            width: 440px;
            height: 200px;
            display: none;
            z-index: 9999;
            padding: 20px;
        }
        #boxes #dialog
        {
            width: 375px;
            height: 203px;
            padding: 10px;
            background-color: #ffffff;
        }*/
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <a id="UpdateProgressTarget" onclick="javascript:fn_showModal(event);">Simple Window
        Modal</a>
    <%--<div id="boxes">
        <div id="dialog" class="window">
            Simple Modal Window | <a href="#" class="close" />Close it</a>
        </div>
        <div id="mask">
        </div>
    </div>--%>
    <div id="UpdateProgress" class="updateprogress_mainstyle">
        <div class="updateprogress_contentstyle" id="UpdateProgressContent">
            <img class="updateprogress_imagestyle" alt="Processando..." src="ajax.gif" />
            <span class="updateprogress_labelstyle">Processando...</span><br />
            <center>
                <span class="updateprogress_labelstyle" id="UpdateProgressCounterTimer">00:00:01</span>
            </center>
        </div>
        <div class="updateprogress_modalstyle" id="UpdateProgressModal">
        </div>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    </form>
</body>
</html>
