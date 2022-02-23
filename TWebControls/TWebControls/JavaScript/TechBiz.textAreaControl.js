(function ($) {
    $.fn.textAreaControl = function (options) {

        return this.each(function () {
            if ($(this).length == 0 || !$(this).is('textarea')) {
                return;
            }

            options = $.extend($.fn.textAreaControl.defaults, $.parseJSON($(this).attr('-tbzTpComp')));

            var maxLength = options.maxLength;
            var labelLegend = $('#' + this.id + 'lbl');

            labelLegend.html("Caracteres restantes: " + maxLength + '/' + maxLength);

            $(this).data('textAreaControl', { maxLength: parseInt(maxLength), count: labelLegend });

            $(this).keyup(function () {
                var textAreaControl = $(this).data('textAreaControl');

                if ($(this).val().length > textAreaControl.maxLength) {
                    $(this).val($(this).val().substring(0, textAreaControl.maxLength));
                }

                $(textAreaControl.count).html("Caracteres restantes: " + (textAreaControl.maxLength - $(this).val().length) + '/' + textAreaControl.maxLength);
            });
        });
    }

    $.fn.textAreaControl.defaults = {
        maxLength: 20
    };
})(jQuery);