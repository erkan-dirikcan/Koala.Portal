"use strict";

var ProjectEditPage = function () {

    var initForm = function () {
        console.log("ProjectEditPage init başlatılıyor...");

        // Initialize Select2 for dropdowns
        $('.select2').select2({
            placeholder: 'Seçiniz',
            language: "tr",
            width: '100%'
        });

        // Initialize DateTimePicker
        $('#DueDate_time').datetimepicker({
            locale: 'tr',
            format: 'DD-MM-YYYY',
            showMeridian: false,
            autoclose: true
        });

        // Firm change handler - load firm contacts
        $('#FirmId').on('change', function () {
            var firmId = $(this).val();
            var $contactSelect = $('#FirmPersonId');

            if (firmId) {
                // Load firm contacts via AJAX
                $.get('/CrmFirm/GetFirmContacts', { firmId: firmId }).done(function (result) {
                    $contactSelect.empty().append('<option value="">Seçiniz</option>');
                    if (result && result.length > 0) {
                        $.each(result, function (i, item) {
                            $contactSelect.append('<option value="' + item.value + '">' + item.text + '</option>');
                        });
                    }
                }).fail(function () {
                    toastr.error('Firma yetkilileri yüklenirken hata oluştu!', 'Hata');
                });
            } else {
                $contactSelect.empty().append('<option value="">Seçiniz</option>');
            }
        });
    };

    return {
        init: function () {
            initForm();
        }
    };

}();

jQuery(document).ready(function () {
    console.log("Document ready, ProjectEditPage init çağrılıyor...");
    ProjectEditPage.init();
});
