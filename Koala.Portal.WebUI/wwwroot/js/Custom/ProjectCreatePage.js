"use strict";

var CreateProject = function () {
    var initPage = function () {


        $('#StartDate_time').datetimepicker({
            locale: 'tr',
            use24hours: true,
            format: 'DD-MM-YYYY',
            showMeridian: false
        });

        // Firma seçimi için Select2
        $('#FirmId').select2({
            placeholder: "Firma Seçin",
            language: "tr",
            allowClear: true,
            width: '100%'
        });

        // Firma Proje Yöneticisi için Select2
        $('#FirmPersonId').select2({
            placeholder: "Firma Yetkilisi Seçin",
            language: "tr",
            allowClear: true,
            width: '100%'
        });

        // Firma değiştiğinde personelleri yükle
        $('#FirmId').on('change', function () {
            var firmId = $(this).val();
            if (!firmId) {
                $('#FirmPersonId').empty().append('<option value="">Seçiniz</option>').trigger('change');
                return;
            }
            $.get("/Firm/GetFirmContactsSelectList?firmId=" + firmId).done(function (result) {
                if (result.isSuccess) {
                    $('#FirmPersonId').val(null).trigger('change');
                    $("#FirmPersonId").empty();
                    $("#FirmPersonId").append('<option value="">Seçiniz</option>');
                    $.each(result.data, function (i, val) {
                        var opt = new Option(val.text, val.value, false, false);
                        $("#FirmPersonId").append(opt);
                    });
                    $('#FirmPersonId').trigger('change');
                } else {
                    toastr.error("Bir Hata Oluştu", result.message);
                }
            });
        });

    }
    return {
        init: function () {
            initPage();
        }

    };

}();


jQuery(document).ready(function () {
    CreateProject.init();
});