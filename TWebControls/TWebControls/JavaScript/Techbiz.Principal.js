//Principal

function Voltar() {
    history.back();
    return false;
}

function Redirecionar(url) {
    $(window).attr("location", url);
    return false;
}

function showProcessModal() {
    $.modal('<div><div class="img_processando"></div><span class="txt_processando">Processando...</span></div>', {
        autoResize: true,
        closeHTML: "",
        focus:false,
        escClose: false,
        overlayClose: false,
        opacity: 30,
        containerCss: {
            opacity: 30,
            padding: 2
        },
        overlayCss: {
            opacity: 30,
            backgroundColor: '#202020'
        }
    });
}

function ShowPagina(site) {
    var data = {
        url: site,
        width: 800,
        height: 430
    };
    ModalPopup(data);
}

function ModalPopup(data) {
    var url = data.url;
    var width = data.width;
    var height = data.height;

    $.modal('<iframe frameborder="0" src="' + url + '" height="' + height + '" width="' + width + '" />', {
        autoPosition: true,
        focus:false,
        escClose: false,
        overlayClose: true,
        containerCss: {
            backgroundColor: "#FFFFFF",
            borderColor: "#FFFFFF",
            height: height,
            opacity: 100,
            padding: 5,
            width: width
        }
    });
}

$(document).ready(function () {

    $(".btnSubmitMessage").click(function (e) {
        var btn = $(this);
        var msg = btn.attr('tbiz-msg');

        if (msg == undefined) {
            showProcessModal();
        }
        else {

            if (!ShowSubmitMessage(msg, btn.attr('id'))) {
                e.preventDefault();
            }
            else {
                showProcessModal();
            }
        }
    });

    $(".btnGoBackMessage").click(function (e) {
        if (e.preventDefault) {
            e.preventDefault();
        }
        else {
            e.returnValue = false;
        }
        e.stopPropagation();

        var btn = $(this);
        var msg = btn.attr('tbiz-msg');

        ShowGoBackMessage(msg);
        return false;
    });

    $(".btnRedirectMessage").click(function (e) {
        if (e.preventDefault) {
            e.preventDefault();
        }
        else {
            e.returnValue = false;
        }
        e.stopPropagation();

        var btn = $(this);
        var msg = btn.attr('tbiz-msg');
        var pageName = btn.attr('tbiz-rdtPg');

        ShowRedirectMessage(msg, pageName);
        return false;
    });


    //$("[type=submit]").click(function () { showProcessModal(); return true; });

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
        showButtonPanel: true,
        buttonImageOnly: true,
        buttonText: 'Calendário'
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


    // Insere as máscaras de formatação de entrada.
    $.formatInputs();

    $('#frmPrincipal').validate(
    {
        errorElement: 'div',
        wrapper: 'li',  // a wrapper around the error message 
        onclick: false,
        onfocusout: false,
        ignore: "",
        ignoreTitle: true,
        errorPlacement: function (error, element) {
            offset = element.offset();
            error.insertBefore(element);
            error.addClass('divValidation');  // add a class to the wrapper 
            error.css('position', 'absolute');

            if (element[0] != undefined && element[0].tagName != undefined) {
                if (element[0].tagName == "SELECT") {
                    error.css('top', element[0].clientTop - 15);
                    error.css('left', element[0].clientLeft + element[0].clientWidth + 15);
                }
                else {
                    error.css('top', offset.top - 15);
                    error.css('left', offset.left + element.outerWidth() - 15);
                }
            }
        }
    }
    );

    $.fieldValueValidate();

    // Configura campos do tipo TextArea.
    $('[-tbzTpComp]').textAreaControl();

    $(document).ajaxStart(function () {
        showProcessModal();
    });

    $(document).ajaxStop(function () {
        $.modal.close();
    });


    $("select:not(:disabled)").searchable({
        maxMultiMatch: 100000, 				            // how many matching entries should be displayed
        exactMatch: false, 					            // Exact matching on search
        wildcards: true, 					            // Support for wildcard characters (*, ?)
        ignoreCase: true, 					            // Ignore case sensitivity
        latency: 100, 						            // how many millis to wait until starting search
        warnMultiMatch: '',                             // string to append to a list of entries cut short by maxMultiMatch 
        warnNoMatch: 'Nenhum resultado encontrado...', 	// string to show in the list when no entries match
        zIndex: 'auto'							        // zIndex for elements generated by this plugin
    });

    $.metadata.setType("attr", "validate");
});