//'Some services are not able to be constructed (Error while validating the service descriptor '
//ServiceType: Koala.Portal.Core.CrmServices.ICrmSupportService 
//Lifetime: Scoped 
//ImplementationType: Koala.Portal.Service.CrmServices.CrmSupportService': 
//Unable to resolve service for type 'Koala.Portal.Core.Repositories.IUserRepository' while attempting to activate 'Koala.Portal.Service.CrmServices.CrmSupportService'.)'


//{"ApplicationGuid":"6b51155c-efdf-4aed-af2d-4f54ee45ebce","CpuId":"BFEBFBFF000906ED","MainboardId":"200771785910642","PcName":"ERKAN-PC"}


"use strict";

var CreateApplication = function () {
    var initPage = function () {
       

        $('#ExpDate_date').datetimepicker({
            locale: 'tr',            
            format: 'DD-MM-YYYY'
        });
        //$("#IsMultiModuleApplication").on('change', function () {
        //    var checked = $(this).is(':checked');
        //    alert(checked);

        //});
        
        //$("#FirmId").on('change', function () {
        //    var firmId = $(this).find(":selected").val();
        //    if (!firmId) {
        //        return;
        //    }
        //    $.get("/Firm/GetFirmContactsSelectList?firmId=" + firmId).done(function (result) {
        //        if (result.isSuccess) {
        //            $('#FirmPersonId').val(null).trigger('change');
        //            $("#FirmPersonId").empty();
        //            $.each(result.data, function (i, val) {
        //                var opt = new Option(val.text, val.value, false, false);
        //                $("#FirmPersonId").append(opt).trigger('change');
        //            });
        //        } else {
        //            toastr.error("Bir Hata Oluþtu", result.message);
        //        }

        //    });
        //});

    }
    return {
        init: function () {
            initPage();
        }

    };

}();


jQuery(document).ready(function () {
    CreateApplication.init();
});