//'Some services are not able to be constructed (Error while validating the service descriptor '
//ServiceType: Koala.Portal.Core.CrmServices.ICrmSupportService 
//Lifetime: Scoped 
//ImplementationType: Koala.Portal.Service.CrmServices.CrmSupportService': 
//Unable to resolve service for type 'Koala.Portal.Core.Repositories.IUserRepository' while attempting to activate 'Koala.Portal.Service.CrmServices.CrmSupportService'.)'


//{"ApplicationGuid":"6b51155c-efdf-4aed-af2d-4f54ee45ebce","CpuId":"BFEBFBFF000906ED","MainboardId":"200771785910642","PcName":"ERKAN-PC"}


"use strict";

var CreateApplicationModule = function () {
    var initPage = function () {
       

        $('#ApplicationId').select2({
            placeholder: 'Uygulama Seçiniz',
            formatNoMatches: "Eþleþen Öðe Bulunamadý",
            allowClear: true
        });

    }
    return {
        init: function () {
            initPage();
        }

    };

}();


jQuery(document).ready(function () {
    CreateApplicationModule.init();
});