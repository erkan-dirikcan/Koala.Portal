"use strict";
var ProjectLineTable = function () {

    var initTable = function () {
        var id = window.location.pathname.substring(window.location.pathname.lastIndexOf("/") + 1);
        $("#open-add-project-line-modal").click(function () {
            $("#add-project-line-modal").modal();
        });

        $('#add-project-line-modal').on('shown.bs.modal',
            function () {

                $('#add_LineFirmOfficial').select2({
                    placeholder: 'Firma Yetkilisi Seçiniz',
                    formatNoMatches: "Eşleşen Öğe Bulunamadı"
                });
                $('#add_LineOfficialId').select2({
                    placeholder: 'Faz Yöneticisi Seçiniz',
                    formatNoMatches: "Eşleşen Öğe Bulunamadı"
                });
                $('#add_LinePriority').select2({
                    placeholder: 'Önceliği Seçiniz',
                    formatNoMatches: "Eşleşen Öğe Bulunamadı"
                });
                $('#add_DueDate').datepicker({
                    locale: 'tr',
                    use24hours: true,
                    format: 'dd-mm-yy',
                    showMeridian: false,
                    autoclose: true
                });


            });






        var table = $('#ProjectLineTable');






        // begin first table
        table.DataTable({
            responsive: true,
            ordering: false,
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
    ProjectLineTable.init();
});
