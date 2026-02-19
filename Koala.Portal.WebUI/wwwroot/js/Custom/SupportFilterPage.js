"use strict";
var SupportTable = function () {

    var initTable = function () {
        var table = $('#supportTable');

        $('#StartDate_time').datetimepicker({
            locale: 'tr',
            use24hours: true,
            format: 'DD-MM-YYYY HH:mm',
            showMeridian: false
        });

        $('#EndDate_time').datetimepicker({
            locale: 'tr',
            use24hours: true,
            format: 'DD-MM-YYYY HH:mm',
            showMeridian: false
        });
        $('#ActiveWorkingUserOid').select2({
            placeholder: "Kullanıcı Seçin",
            allowClear: true
        });
        $('#Firm').select2({
            placeholder: "Firma Seçin",
            allowClear: true
        });
        $('#Statuses').select2({
            placeholder: "Destek Durumu Seçin",
            allowClear: true
        });

        $('#ActiveWorkingUserOid').val(null).trigger('change');
        $('#Firm').val(null).trigger('change');

        // begin first table
        table.DataTable({
            responsive: true,
            columnDefs: [

            ]
        });

    };

    return {


        init: function () {
            initTable();
        }

    };

}();

jQuery(document).ready(function () {
    SupportTable.init();
});