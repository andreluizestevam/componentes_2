(function ($) {
    $.fn.createMutlSelect = function () {
        function CreateValues(a) {
            var hdnSel = $("#" + a + "_hdnSel");
            hdnSel.val('');

            var listaSelecionado = $("#" + a + " .multiListSelected option");
            listaSelecionado.each(function () {
                hdnSel.val(hdnSel.val() + ',' + $(this).val());
            });
        }

        $('.btnRightOne').click(
                function (e) {
                    var listaDisponivel = $("#" + this.parentElement.id + " .multiListAvaliable" + " > option:selected");
                    var listaSelecionado = $("#" + this.parentElement.id + " .multiListSelected");
                    listaDisponivel.appendTo(listaSelecionado);
                    e.preventDefault();
                    SortList(this.parentElement.id, " .multiListSelected");
                    CreateValues(this.parentElement.id);
                });

        $('.btnRightAll').click(
                function (e) {
                    var listaDisponivel = $("#" + this.parentElement.id + " .multiListAvaliable" + " > option");
                    var listaSelecionado = $("#" + this.parentElement.id + " .multiListSelected");
                    listaDisponivel.appendTo(listaSelecionado);
                    e.preventDefault();
                    SortList(this.parentElement.id, " .multiListSelected");
                    CreateValues(this.parentElement.id);
                });

        $('.btnLeftOne').click(
                function (e) {
                    var listaSelecionado = $("#" + this.parentElement.id + " .multiListSelected" + " > option:selected");
                    var listaDisponivel = $("#" + this.parentElement.id + " .multiListAvaliable");
                    listaSelecionado.appendTo(listaDisponivel);
                    e.preventDefault();
                    SortList(this.parentElement.id, " .multiListAvaliable");
                    CreateValues(this.parentElement.id);
                });

        $('.btnLeftAll').click(
                function (e) {
                    var listaSelecionado = $("#" + this.parentElement.id + " .multiListSelected" + " > option");
                    var listaDisponivel = $("#" + this.parentElement.id + " .multiListAvaliable");
                    listaSelecionado.appendTo(listaDisponivel);
                    e.preventDefault();
                    SortList(this.parentElement.id, " .multiListAvaliable");
                    CreateValues(this.parentElement.id);
                });
    }
})(jQuery);

function SortList(parentId, listname) {
    var r = $("#" + parentId + listname + " > option");
    r.sort(function (a, b) {
        return (a.text < b.text) ? -1 : (a.text > b.text) ? 1 : 0;
        //or you can have a.text, b.text, etc
    });
    $(r).remove();
    $("#" + parentId + listname).append($(r));
} 