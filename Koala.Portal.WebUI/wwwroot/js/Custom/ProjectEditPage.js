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

        // Function to load firm contacts
        var loadFirmContacts = function (firmId, selectedContactId) {
            var $contactSelect = $('#FirmPersonId');

            if (!firmId) {
                $contactSelect.empty().append('<option value="">Seçiniz</option>').trigger('change');
                return;
            }

            $.get("/Firm/GetFirmContactsSelectList?firmId=" + firmId).done(function (result) {
                if (result.isSuccess && result.data) {
                    // Clear existing options and add default
                    $contactSelect.empty().append('<option value="">Seçiniz</option>');

                    // Add all options
                    $.each(result.data, function (i, val) {
                        var opt = new Option(val.text, val.value, false, false);
                        $contactSelect.append(opt);
                    });

                    // Set the selected value after all options are added
                    if (selectedContactId) {
                        $contactSelect.val(selectedContactId);
                    }

                    // Trigger change to update Select2
                    $contactSelect.trigger('change');

                    console.log("Firm contacts loaded. Selected:", selectedContactId);
                } else {
                    toastr.error("Firma yetkilileri yüklenirken hata oluştu!", "Hata");
                }
            }).fail(function () {
                toastr.error('Firma yetkilleri yüklenirken bir hata oluştu!', 'Hata');
            });
        };

        // On page load, if firm is already selected, load its contacts
        var initialFirmId = $('#FirmId').val();
        var initialContactId = $('#FirmPersonId').val();
        console.log("Initial FirmId:", initialFirmId, "Initial ContactId:", initialContactId);

        if (initialFirmId) {
            loadFirmContacts(initialFirmId, initialContactId);
        }

        // Firm change handler - load firm contacts
        $('#FirmId').on('change', function () {
            var firmId = $(this).val();
            // Clear contact selection when firm changes
            loadFirmContacts(firmId, null);
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
