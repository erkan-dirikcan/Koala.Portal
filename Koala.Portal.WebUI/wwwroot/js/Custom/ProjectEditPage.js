"use strict";

var ProjectEditPage = function () {

    var initForm = function () {
        console.log("ProjectEditPage init başlatılıyor...");

        // Initialize DateTimePicker
        $('#DueDate_time').datetimepicker({
            locale: 'tr',
            format: 'DD-MM-YYYY',
            showMeridian: false,
            autoclose: true
        });

        // Get initial values BEFORE initializing Select2
        var initialFirmId = $('#FirmId').val();
        var initialContactId = $('#FirmPersonId').data('selected-value');

        console.log("Page load - Initial FirmId:", initialFirmId, "Initial ContactId:", initialContactId);

        // Initialize Select2 for Firm dropdown
        $('#FirmId').select2({
            placeholder: "Firma Seçin",
            language: "tr",
            allowClear: true,
            width: '100%'
        });

        // Initialize Select2 for Contact dropdown
        $('#FirmPersonId').select2({
            placeholder: "Firma Yetkilisi Seçin",
            language: "tr",
            allowClear: true,
            width: '100%'
        });

        // Function to load firm contacts
        var loadFirmContacts = function (firmId, selectedContactId) {
            var $contactSelect = $('#FirmPersonId');

            if (!firmId) {
                $contactSelect.empty().append('<option value="">Seçiniz</option>').val(null).trigger('change');
                return;
            }

            console.log("Loading firm contacts for firmId:", firmId, "selectedContactId:", selectedContactId);

            $.get("/Firm/GetFirmContactsSelectList?firmId=" + firmId, function (result) {
                console.log("AJAX response:", result);
                if (result.isSuccess && result.data) {
                    // Get current value before clearing
                    var currentValue = $contactSelect.val();

                    // Clear existing options and add default
                    $contactSelect.empty().append('<option value="">Seçiniz</option>');

                    // Add all options
                    $.each(result.data, function (i, val) {
                        var opt = new Option(val.text, val.value, false, false);
                        $contactSelect.append(opt);
                    });

                    // Set the selected value
                    var valueToSet = selectedContactId || currentValue;
                    if (valueToSet) {
                        console.log("Setting selected value:", valueToSet);
                        $contactSelect.val(valueToSet);
                    }

                    // Trigger change to update Select2
                    $contactSelect.trigger('change');
                } else {
                    console.error("Failed to load firm contacts:", result);
                    toastr.error("Firma yetkilileri yüklenirken hata oluştu!", "Hata");
                }
            }).fail(function (xhr, status, error) {
                console.error("AJAX failed:", error);
                toastr.error('Firma yetkilleri yüklenirken bir hata oluştu!', 'Hata');
            });
        };

        // Load contacts on page load if firm is selected
        if (initialFirmId) {
            loadFirmContacts(initialFirmId, initialContactId);
        }

        // Firm change handler - load firm contacts
        $('#FirmId').on('change', function () {
            var firmId = $(this).val();
            console.log("Firm changed to:", firmId);
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
