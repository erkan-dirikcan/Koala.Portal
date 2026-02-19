"use strict";

var CreateProject = function () {
    var initPage = function () {


        $('#StartDate_time').datetimepicker({
            locale: 'tr',
            use24hours: true,
            format: 'DD-MM-YYYY',
            showMeridian: false
        });
        //$('#FirmPersonId').select2({
        //    placeholder: "Firma Yetkilisi Seçin",
        //    language: "tr"
        //});
        //$('#FirmId').select2({
        //    placeholder: "Firma Seçin",
        //    language: "tr"
        //});
        //$('#ProjectManagerId').select2({
        //    placeholder: "Proje Yöneticisi Seçin",
        //    language: "tr"
        //});

      
            //var firmId = $(this).find(":selected").val();
            //if (!firmId) {
            //    return;
            //}
            //$.get("/Firm/GetFirmContactsSelectList?firmId=" + firmId).done(function (result) {
            //    if (result.isSuccess) {
            //        $('#FirmPersonId').val(null).trigger('change');
            //        $("#FirmPersonId").empty();
            //        $.each(result.data, function (i, val) {
            //            var opt = new Option(val.text, val.value, false, false);
            //            $("#FirmPersonId").append(opt).trigger('change');
            //        });
            //    } else {
            //        toastr.error("Bir Hata Oluştu", result.message);
            //    }

            //});

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