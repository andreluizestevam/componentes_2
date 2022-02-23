$(document).ready(function () {
    //    setTimeout(function () { $('.flash').fadeOut('slow'); }, 5000);
    //    $('.flash').click(function () { $(this).fadeOut('fast'); });

    //    // Configura as Div do tipo TabSheet.
    //    $('.tabSheetContainer').each(function () {
    //        $(this).tabs();
    //    });

    // Configuração de datas estilo calendário.
    $.datepicker.regional['pt-BR'] = {
        closeText: 'Fechar',
        prevText: '&#x3c;Anterior',
        nextText: 'Pr&oacute;ximo&#x3e;',
        currentText: 'Hoje',
        monthNames: ['Janeiro', 'Fevereiro', 'Mar&ccedil;o', 'Abril', 'Maio', 'Junho', 'Julho', 'Agosto', 'Setembro', 'Outubro', 'Novembro', 'Dezembro'],
        monthNamesShort: ['Jan', 'Fev', 'Mar', 'Abr', 'Mai', 'Jun', 'Jul', 'Ago', 'Set', 'Out', 'Nov', 'Dez'],
        dayNames: ['Domingo', 'Segunda-feira', 'Ter&ccedil;a-feira', 'Quarta-feira', 'Quinta-feira', 'Sexta-feira', 'Sabado'],
        dayNamesShort: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
        dayNamesMin: ['Dom', 'Seg', 'Ter', 'Qua', 'Qui', 'Sex', 'Sab'],
        dateFormat: 'dd/mm/yy', firstDay: 0,
        showOn: 'button',
        buttonImage: '../App_Images/btn_calendario.gif',
        showButtonPanel: true,
        buttonImageOnly: true
    };

    $.datepicker.setDefaults($.datepicker.regional['pt-BR']);

    $.timepicker.regional['pt-BR'] = {
        timeOnlyTitle: 'Tempo',
        timeText: 'Horário',
        hourText: 'Hora',
        minuteText: 'Minuto',
        secondText: 'Segundo',
        millisecText: 'milissegundos',
        currentText: 'Hoje',
        closeText: 'Fechar',
        ampm: false
    };
    $.timepicker.setDefaults($.timepicker.regional['pt-BR']);

    $('.TMultiSelect').createMutlSelect();

    // Insere as máscaras de formatação de entrada.
    $.formatInputs();

    $('#frmPrincipal').validate(
    {
        errorElement: 'div',
        wrapper: 'li',  // a wrapper around the error message 
        onclick: false,
        onfocusout: false,

        errorPlacement: function (error, element) {
            offset = element.offset();
            error.insertBefore(element)
            error.addClass('message');  // add a class to the wrapper 
            error.css('position', 'absolute');
            error.css('left', offset.left + element.outerWidth() - 15);
            error.css('top', offset.top - 15);
            error.appendTo(element.parent().next().next());
        }
    }
    );

    //     highlight: function (element, errorClass) {
    //            $(element).fadeOut(function () {
    //                $(element).fadeIn();
    //            });
    //        },


    $.fieldValueValidate();

    // Configura campos do tipo TextArea.
    $('[-tbzTpComp]').textAreaControl();

    //    // Seta os serviços Ajax para validação de servidor de campos.
    //    $('[servervalidation]').fieldValidationServer();
    $.metadata.setType("attr", "validate");
});


