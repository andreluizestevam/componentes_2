(function ($) {
    $.configureNumberMasks = function (options) {
        options = $.extend($.configureNumberMasks.defaults, options);

        $('[-tbzMsk="' + $.configureNumberMasks.defaults.integer + '"]').setIntegerMask();
        $('[-tbzMsk="' + $.configureNumberMasks.defaults.integetNoSign + '"]').setSignedIntegerMask();
        $('[-tbzMsk="' + $.configureNumberMasks.defaults.decimal + '"]').setDecimalMask();
        $('[-tbzMsk="' + $.configureNumberMasks.defaults.decimalNoSign + '"]').setSignedDecimalMask();
    }


    /* Definição de máscaras para números inteiros e decimais. */

    $.fn.setIntegerMask = function () {
        return this.each(function () {
            setNumberMask($(this), '^\\d{0,' + $(this).attr('maxLength') + '}$', 'right');
        });
    }

    $.fn.setSignedIntegerMask = function () {
        return this.each(function () {
            setNumberMask($(this), '^[\\+\\-]{0,1}\\d{0,' + ($(this).attr('maxLength') - 1) + '}$', 'right');
        });
    }

    $.fn.setDecimalMask = function () {
        return this.each(function () {
            setDecimalMask($(this), false);
        });
    }

    $.fn.setSignedDecimalMask = function () {
        return this.each(function () {
            setDecimalMask($(this), true);
        });
    }

    function setDecimalMask(element, signed) {
        var reservedChar = 1;
        var initMask = '^';

        if (signed) {
            reservedChar = 2;
            initMask = '^[\\+\\-]{0,1}';
        }

        maxLength = element.attr('maxLength') - reservedChar;
        setNumberMask(element, initMask + '\\d{0,' + maxLength + '}$', 'right', function () { formatDecimal(element, signed) });
    }

    function formatDecimal(element, signed) {
        var value = element.val();
        var sign = '';

        if (value.length == 0) {
            return;
        }

        value = replaceAll(value, ',', '');

        if (signed) {
            var match = value.match('^[\\+\\-]');

            // Verifica se o único valor do campo é o sinal.
            if ((value.length == 1) && (match)) {
                element.val('');
                return;
            }

            if (match) {
                sign = match[0];
                value = value.replace(sign, '');
            }
        }

        var currentLength = value.length;

        if (currentLength < 3) {
            value = value.addCharToLeft('0', 3 - currentLength);
        }

        currentLength = value.length;
        value = sign.concat(left(value, currentLength - 2) + ',' + right(value, 2));
        element.val(value);
    }

    function setNumberMask(element, mask, align, focusOutEvent) {
        // Se não houver seleção de elemento, o tipo do elemento não for input:text 
        // ou a máscara não for definida não iremos prosseguir nas configurações.
        if (element.length == 0 || !element.is('input:text') || mask == undefined || mask == '') {
            return;
        }

        // Alinhamento do texto no componente à direita.
        element.css('text-align', align);

        // Controle se seleção de texto com o tab ou shift-tab.
        element.select(function () {
            element.attr('isSelected', true);
        });

//        element.focusin(function () {
//            var value = replaceAll(replaceAll(element.val(), ',', ''), '.', '');
//            element.val(value);
//            element.select();
//            element.focus();
//        });

        if (focusOutEvent != undefined && focusOutEvent != null) {
            element.focusout(function () { focusOutEvent(element); });
        }

        element.keypress(function (event) {
            var length = element.attr('maxLength');

            // Se o valor estiver selecionado (seleção do texto), iremos considerar somente o caractere como 
            // valor do campo, pois todo o conteúdo anterior será apagado.
            var value = element.attr('isSelected') == 'true' ? String.fromCharCode(event.keyCode) : element.val() + String.fromCharCode(event.keyCode);

            // Se o texto não for aceito na máscara ou seu tamanho ultrapassar o tamanho máximo de caracteres 
            // permitido no campo iremos invalidar a inserção do novo caractere.
            if (value.match(mask) == null || value.length > length) {
                event.preventDefault();
            }
            else {
                // Se o valor estiver selecionado (seleção do texto), iremos apagar o conteúdo anteior
                // antes de permitir a inserção do novo caractere.
                if (element.attr('isSelected') == 'true') {
                    element.val('');
                    element.attr('isSelected', false);
                }
            }
        });
    }

    $.configureNumberMasks.defaults = {
        integer: 'IntegerMask',
        integetNoSign: 'SignedIntegerMask',
        decimal: 'DecimalMask',
        decimalNoSign: 'SignedDecimalMask'
    }

    //    $().AddStartupDelegate(function () {
    //        // Insere as máscaras de formatação de entrada.
    //        $.configureNumberMasks();
    //    });
})(jQuery);