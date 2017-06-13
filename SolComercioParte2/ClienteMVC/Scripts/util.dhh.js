$(function ($) {
    $.datepicker.regional['es'] = {
        closeText: 'Cerrar',
        prevText: '<Ant',
        nextText: 'Sig>',
        currentText: 'Hoy',
        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
        dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mié', 'Juv', 'Vie', 'Sáb'],
        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
        weekHeader: 'Sm',
        dateFormat: 'dd/mm/yy',
        firstDay: 1,
        isRTL: false,
        showMonthAfterYear: false,
        yearSuffix: ''
    };
    $.datepicker.setDefaults($.datepicker.regional['es']);
});

function castFechaCorta(fechaJson) {
    if (fechaJson == null) {
        return "";
    }
    var fullDate = new Date(parseInt(fechaJson.substr(6)));
    var twoDigitMonth = ((fullDate.getMonth().length + 1) === 1) ? '0' + (fullDate.getMonth() + 1) : (fullDate.getMonth() + 1);
    var currentDate = fullDate.getDate() + "/" + twoDigitMonth + "/" + fullDate.getFullYear();
    return currentDate;
};

$(function () {
    $('#selectMenuMain').selectpicker();
    setHeight();
});

function setHeight() {
    if (!($(window).width() <= 600)) {
        $("#menuLeft").css('height', $('#contentDocument').height() + 42);
    } else {
        $("#menuLeft").css('height', 'auto');
    }
}

$(window).resize(function () {
    var a = $("#menuLeft");

    if (a.css('position') == 'absolute') {
        setHeight();
    }
});

$(window).on('load', function () {
    $('.selectpicker').selectpicker();
});


//$(document).ajaxStart($.blockUI).ajaxStop($.unblockUI);
$(document).ready(function () {
    $.ajaxSetup({ cache: false });
    $('body').on("click", ".modalGC", function () {

        var url = $(this).attr('data-url');

        $.get(url, function (data) {
            $('.seccionModal').html(data);
            $('.contenedor').modal('show');
            $(".modal-content").draggable({
                handle: ".modal-header",
                cursor: "move"
            });
        });
    });


    bootbox.setDefaults({
        locale: "es"
    });
   



    (function ($) {
        $.fn.clickToggle = function (func1, func2) {
            var funcs = [func1, func2];
            this.data('toggleclicked', 0);
            this.click(function () {
                var data = $(this).data();
                var tc = data.toggleclicked;
                $.proxy(funcs[tc], this)();
                data.toggleclicked = (tc + 1) % 2;
            });
            return this;
        };
    }(jQuery));


    $('.arrowColapse').clickToggle(function () {
        var a = $("#menuLeft");
        var b = $("ul.menuDHH");
        var c = $("#contentRight");
        var d = $(".arrowColapse");
        a.css({ 'display': 'none', 'width': '100%', 'position': 'static', 'margin': '-20px 0 20px 0', 'height': 'auto' });
        b.css({ 'margin-top': '10px' });
        c.css({ 'padding-left': '0' });
        d.css({ 'left': '-9px' });
    },
    function () {
        var a = $("#menuLeft");
        var b = $("ul.menuDHH");
        var c = $("#contentRight");
        var d = $(".arrowColapse");
        a.css({ 'display': '', 'width': '', 'position': '', 'margin': '', 'height': '' });
        b.css({ 'margin-top': '' });
        c.css({ 'padding-left': '' });
        d.css({ 'left': '' });
        setHeight();
    });



});


function FormatearFecha(date) {
    var year = date.getFullYear();
    var month = (1 + date.getMonth()).toString();
    month = month.length > 1 ? month : '0' + month;
    var day = date.getDate().toString();
    day = day.length > 1 ? day : '0' + day;
    return day + '/' + month + '/' + year;
}

function convertirToDate(stringDate) {
    var parts = stringDate.split('/');
    var mydate = new Date(parts[2], parts[1] - 1, parts[0]);
    return mydate;
}

