(function ($) {

    $.messageBox = function (options) {

        options = $.extend($.fn.messageBoxdefaults, options);

        if (options.messageType == 'Board') {

            $.jGrowl.defaults.limiter = options.limiter;
            $.jGrowl(options.message,
                {
                    sticky: true,
                    position: 'bottom-right',
                    check: 3,
                    open: function (e, m, o) {
                        if (options.callBack1 != null) {
                            options.callBack1();
                        }
                    }
                });
        }
        else {

            var classImg = 'img_Confirmacao';
            //            img_Confirmacao
            //            img_Erro
            //            img_Questao
            //            img_Informacao

            if (options.messageType == "Error") {
                classImg = 'img_Erro';
            }
            else if (options.messageType == 'YesOrNo' || options.messageType == 'YesOrNoOrCancel') {
                classImg = 'img_Questao';
            }

            var divMaster = $('<div id="messageBoxDialog"><p class="conteudo_Mensagem"><span class="' + classImg + '"></span>' + options.message + '</p></div>').appendTo('body');

            //$('#' + divMaster.attr('id') + ' > div > p').text(options.message);

            divMaster.dialog({
                modal: true,
                resizable: false,
                title: options.title,
                closeText: 'Fechar',
                width: options.width,
                height: options.height,
                buttons: createButtons(options, divMaster)
            });

            //            $('#messageBoxDialog')

            //divMaster.dialog('open');
        }

    }
    // Summary: Cria os campos da caixa de diálogo de validação de acordo com a parametrização do servidor.
    // Parameter options: As configurações retornadas pelo servidor.
    // Parameter field: O campo que está sendo validado.
    function createButtons(options, dialog) {
        var buttons = new Array();

        for (var i = 0; i < options.buttons.length; i++) {
            var button = options.buttons[i];

            var functionClick = function () { doAction(dialog, button.behavior); };

            buttons.push(
            {
                id: button.id,
                text: button.text,
                click: functionClick
            });
        }



        //        if (options.messageType == 'OK') {
        //            // Definição de botões para caixa de diálogo do tipo OK.
        //            buttons.push(
        //            {
        //                text: "Ok",
        //                click: function () { doAction(dialog, options.fieldBehavior1, options.callBack1, options.data1, options.fieldValidate); }
        //            });
        //        }
        //        else if (options.messageType == 'YesOrNo') {
        //            // Definição de botões para caixa de diálogo do tipo Sim ou Não.
        //            buttons.push(
        //            {
        //                text: "Sim", click: function () { doAction(dialog, options.fieldBehavior1, options.callBack1, options.data1, options.fieldValidate); }
        //            },
        //            {
        //                text: "Não", click: function () { doAction(dialog, options.fieldBehavior2, options.callBack2, options.data2, options.fieldValidate); }
        //            });
        //        }

        return buttons;
    }

    // Summary: Executa a ação para um determinado botão da caixa de diálogo.
    // Parameter field: O campo que está sendo validado.
    // Parameter fieldBehavior: O tipo de comportamento definido para o botão no servidor.
    // Parameter action: Uma ação de controlador associada ao botão.
    // Parameter actionData: Um objeto JSON para ser enviado a ação associada ao botão.
    function doAction(dialog, fieldBehavior, callBack, actionData, field) {
        switch (fieldBehavior) {
            case 'None':
                dialog.dialog('close');
                if (callBack != null) {
                    callBack();
                }
                break;
            case 'PageDefault':
                // Ação default da página.
                dialog.dialog('close');
                setFocusToNextFieldFrom(field);
                break;
            case 'StayOnField':
                // Mantém o foco no campo atual.
                dialog.dialog('close');
                field.focus();
                break;
            case 'StayOnFieldAndClear':
                // Mantém o foco no campo atual limpando o seu conteúdo.
                field.val('');
                dialog.dialog('close');
                field.focus();
                break;
            case 'Redirect':
                // Redireciona o fluxo para outra ação.
                $.ajax({
                    type: 'POST',
                    url: callBack,
                    async: false,
                    data: actionData
                });
        }
    }

    $.fn.messageBoxdefaults = {
        message: '',
        title: '',
        callBack1: null,
        callBack2: null,
        messageType: 'OK',
        buttons: null,
        limiter: 5
    }

    // Summery: Seta o foco para o próximo campo focável a partir de um determinado campo.
    // Parameter field: O campo de referência para definição do foco.
    function setFocusToNextFieldFrom(field) {
        var formFields = field.parents('form').find('button,input,textarea,select');

        if (formFields.length > 0) {
            var currentIndex = formFields.index(field);

            // Tenta setar o próximo campo focável a partir do campo atual.
            if (!setFirstFocusableFrom(currentIndex + 1, formFields)) {
                // Se não conseguir seta o primeira campo focável da página.
                setFirstFocusableFrom(0, formFields);
            }
        }
    };

    // Summary: Seta o foco para o primeiro campo focável de um conjunto de elementos a partir de uma determinada posição.
    // Parameter startIndex: O ponto de partida para a procuda do primeiro elemento focável.
    // Parameter range: O conjunto de elementos na qual a procura deve ser realizada.
    function setFirstFocusableFrom(startIndex, range) {
        for (var index = startIndex; index < range.length; index++) {
            var field = $(range[index]);

            // Se o campo não estiver invisível nem desabilitado ele está apto a ser receber o foco.
            if (field.is(':visible') && !field.is(':disabled')) {
                field.focus();
                return true;
            }
        }

        return false;
    }
})(jQuery); 
