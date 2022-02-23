(function ($) {
    
    $.formatInputs = function (options) {

        options = $.extend($.formatInputs.defaults, options);

        $('[-tbzMsk="' + $.formatInputs.defaults.integer + '"]').setIntegerMask();
        $('[-tbzMsk="' + $.formatInputs.defaults.integetNoSign + '"]').setSignedIntegerMask();
        $('[-tbzMsk="' + $.formatInputs.defaults.decimal + '"]').setDecimalMask();
        $('[-tbzMsk="' + $.formatInputs.defaults.decimalNoSign + '"]').setSignedDecimalMask();

        /* Máscara para inscrições de CNPJ e CPF. */
        $('[-tbzMsk="' + $.formatInputs.defaults.cpf + '"]').setCpfMask();
        $('[-tbzMsk="' + $.formatInputs.defaults.cnpj + '"]').setCnpjMask();

        /* Máscara para valores combinados de data e hora. */
        $('[-tbzMsk="' + $.formatInputs.defaults.dateTime + '"]').setDateTimeMask();
        $('[-tbzMsk="' + $.formatInputs.defaults.date + '"]').setDateMask();
        $('[-tbzMsk="' + $.formatInputs.defaults.monthAndYear + '"]').setMonthAndYearMask();
        $('[-tbzMsk="' + $.formatInputs.defaults.year + '"]').setYearMask();
        $('[-tbzMsk="' + $.formatInputs.defaults.hourAmount + '"]').setHourAmountMask();
        $('[-tbzMsk="' + $.formatInputs.defaults.hourDay + '"]').setHourDayMask();

        /* Máscara para CEP. */
        $('[-tbzMsk="' + $.formatInputs.defaults.cep + '"]').setCEPMask();

        /* Máscara para Telefone. */
        $('[-tbzMsk="' + $.formatInputs.defaults.telefone + '"]').setTelefoneMask();

        /* Máscara customizada. */
        $('[-tbzCMsk]').setCustomMask();
    }

    /* Definição de máscaras para números inteiros e decimais. */

    $.fn.setIntegerMask = function () {
        return this.each(function () {
            $(this).inputmask('non-negative-integer', { "repeat": "" + $(this).attr('maxLength') + "" });
        });
    }

    $.fn.setSignedIntegerMask = function () {
        return this.each(function () {
            $(this).inputmask('integer', { "repeat": "" + $(this).attr('maxLength') + ""});
        });
    }

    $.fn.setDecimalMask = function () {
        return this.each(function () {
            $(this).inputmask('non-negative-decimal', { "repeat": "" + $(this).attr('maxLength') + "" });
        });
    }

    $.fn.setSignedDecimalMask = function () {
        return this.each(function () {
            $(this).inputmask('decimal', { "repeat": "" + $(this).attr('maxLength') + "" });
        });
    }

    /* Definição de máscaras para inscrições de CNPJ e CPF. */

    $.fn.setCpfMask = function () {
        return this.each(function () {
            $(this).inputmask('999.999.999-99', { "placeholder": "_" });
        });
    }

    $.fn.setCnpjMask = function () {
        return this.each(function () {
            $(this).inputmask('99.999.999/9999-99', { "placeholder": "_" });
        });
    }

    /* Definição de máscaras para data e hora (Apenas formato. Não incluem calendário). */

    $.fn.setDateTimeMask = function () {
        return this.each(function () {
            $(this).inputmask('datetime', { "placeholder": "_" });
            if ($(this).attr('-tbzCalendar') == 'true') {
                $(this).datetimepicker({
                    // other options goes here 
                    onClose: function () {
                        // The "this" keyword refers to the input (in this case: #someinput) 
                        this.focus();
                    }
                });
            }
        });
    }

    $.fn.setDateMask = function () {
        return this.each(function () {
            $(this).inputmask('date', { "placeholder": "_" });
            if ($(this).attr('-tbzCalendar') == 'true') {
                $(this).datepicker({
                    // other options goes here 
                    onSelect: function () {
                        // The "this" keyword refers to the input (in this case: #someinput) 
                        this.focus();
                    }
                });
            }
        });
    }

    $.fn.setMonthAndYearMask = function () {
        return this.each(function () {
            $(this).inputmask('m\/y', { "placeholder": "_" });
        });
    }

    $.fn.setYearMask = function () {
        return this.each(function () {
            $(this).inputmask('y', { "placeholder": "_" });
        });
    }

    $.fn.setHourAmountMask = function () {
        return this.each(function () {
            $(this).inputmask('9999:s', { "placeholder": "_" });
        });
    }

    $.fn.setHourDayMask = function () {
        return this.each(function () {
            $(this).inputmask('h:s', { "placeholder": "_" });
        });
    }

    /* Definição de máscara de CEP. */

    $.fn.setCEPMask = function () {
        return this.each(function () {
            $(this).inputmask('99999-999', { "placeholder": "_" });
        });
    }

    /* Definição de máscara de Telefone. */

    $.fn.setTelefoneMask = function () {
        return this.each(function () {
            $(this).inputmask('(99) 9999-9999[9]', { "placeholder": "_" });
        });
    }

    /* Definição de máscara customizada. */

    $.fn.setCustomMask = function () {
        return this.each(function () {
            $(this).inputmask($(this).attr('-tbzCMsk'), { "placeholder": "_" });
        });
    }

    /*  Valores devault para classes css que definem o tipo de máscara para elementos. */

    $.formatInputs.defaults = {
        integer: 'IntegerMask',
        integetNoSign: 'SignedIntegerMask',
        decimal: 'DecimalMask',
        decimalNoSign: 'SignedDecimalMask',
        cpf: 'CPFMask',
        cnpj: 'CNPJMask',
        dateTime: 'DateTimeMask',
        date: 'DateMask',
        monthAndYear: 'MonthAndYearMask',
        year: 'YearMask',
        hourAmount: 'HourAmountMask',
        hourDay: 'HourDayMask',
        email: 'EmailMask',
        cep: 'CEPMask',
        custom: 'CustomMask',
        telefone: 'TelefoneMask'
    }

})(jQuery); 
