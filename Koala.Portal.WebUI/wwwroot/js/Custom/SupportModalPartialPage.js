"use strict";
var SupportModalPartialPage = function () {
    var selectedId = "";
    var appointedUserOid = "";
    var workUserOid = "";
    var loginedUserOid = "";
    var isContinue = "False";

    var modalMethods = function () {

        $(".detail").click(function () {

            var supportId = $(this).data("id");
            var isProjectUser = $(this).attr('data-isProjectUser');
            var isTransferUser = $(this).attr('data-isTransferUser');
            var isProjectFirm = $(this).attr('data-isProjectFirm');
            var moduleName = $(this).attr('data-module');
            var isFirm = $(this).attr('data-isFirm');






            //$("#det_pr_assign_bt").attr("hidden", "hidden");
            //$("#det_pr_start_bt").attr("hidden", "hidden");
            //
            /*
             <button type="button" class="btn btn-primary font-weight-bold" id="det_start_bt">Üzerine Al/Başla</button>
                <button type="button" class="btn btn-danger font-weight-bold" id="det_pr_assign_bt">Kullanıcıya Ata</button>
                <button type="button" class="btn btn-warning font-weight-bold" id="det_update_bt">Güncelle</button>
            
            */

            $.get("/Support/GetSupportDetail?supportId=" + supportId).done(function (result) {
                if (result.isSuccess) {
                    var now = new Date($.now());
                    var ld = new Date(result.data.firmSupportStatus.logoSupportExpDate);
                    var nld = new Date(result.data.firmSupportStatus.newLogoSupportExpDate);
                    var td = new Date(result.data.firmSupportStatus.tecnicalSupportExpDate);
                    var ntd = new Date(result.data.firmSupportStatus.newTecnicalSupportExpDate);
                    appointedUserOid = result.data.AssignedToOid;
                    workUserOid = result.data.ActiveWorkingUserOid;

                    //Swichler
                    if (result.data.firmSupportStatus.logoSupport && now <= ld) {
                        $('#det_logo_cb').prop('checked', true);
                        $("#det_sup_logo_exp_lb").removeAttr("hidden");
                        $("#det_sup_logo_exp_lb").html(moment(ld).format('DD-MM-YYYY HH:mm'));
                    } else {
                        $('#det_logo_cb').prop('checked', false);
                        $("#det_sup_logo_exp_lb").attr("hidden", "hidden");
                        $("#det_sup_logo_exp_lb").html(moment(ld).format(''));
                    }
                    if (result.data.firmSupportStatus.newLogoSupport && now <= nld) {
                        $('#det_new_logo_sup_cb').prop('checked', true);
                        $("#det_sup_new_logo_exp_lb").removeAttr("hidden");
                        $("#det_sup_new_logo_exp_lb").html(moment(nld).format('DD-MM-YYYY HH:mm'));
                    } else {
                        $('#det_new_logo_sup_cb').prop('checked', false);
                        $("#det_sup_new_logo_exp_lb").attr("hidden", "hidden");
                        $("#det_sup_new_logo_exp_lb").html(moment(nld).format(''));
                    }
                    if (result.data.firmSupportStatus.tecnicalSupport && now <= td) {
                        $('#det_sup_tec_cb').prop('checked', true);
                        $("#det_tec_sup_exp_lb").removeAttr("hidden");
                        $("#det_tec_sup_exp_lb").html(moment(td).format('DD-MM-YYYY HH:mm'));
                    } else {
                        $('#det_sup_tec_cb').prop('checked', false);
                        $("#det_tec_sup_exp_lb").attr("hidden", "hidden");
                        $("#det_tec_sup_exp_lb").html(moment(td).format(''));
                    }
                    if (result.data.firmSupportStatus.newTecnicalSupport && now <= ntd) {
                        $('#det_new_tec_sup_cb').prop('checked', true);
                        $("#det_new_tec_sup_ex_lb").removeAttr("hidden");
                        $("#det_new_tec_sup_ex_lb").html(moment(ntd).format('DD-MM-YYYY HH:mm'));
                    } else {
                        $('#det_new_tec_sup_cb').prop('checked', false);
                        $("#det_new_tec_sup_ex_lb").attr("hidden", "hidden");
                        $("#det_new_tec_sup_ex_lb").html(moment(ntd).format(''));
                    }

                    $("#det_sup_category_sb").text(result.data.ticketMainCategory);
                    $("#det_sup_subcategory_sb").text(result.data.ticketSubCategory);

                    var priority = "Çok Düşük";

                    switch (result.data.ticketPriority) {
                        case 0:
                            priority = "Çok Düşük";
                            break;
                        case 1:
                            priority = "Düşük";
                            break;
                        case 2:
                            priority = "Normal";
                            break;
                        case 3:
                            priority = "Yüksek";
                            break;
                        case 4:
                            priority = "Çok Yüksek";
                            break;
                        default:
                            priority = "Belirtilmemiş";
                    }

                    $("#det_sup_priority_sb").text(priority);

                    $("#det_sup_firm_sb").text(result.data.ticketFirm);
                    $("#det_sup_firm_phones_sb").text(result.data.ticketFirmPhone);
                    $("#det_sup_contact_sb").text(result.data.ticketContact);
                    $("#det_sup_contact_phones_sb").text(result.data.ticketContactPhone);

                    $("#det_sup_department_sb").text(result.data.assignedDepartment);
                    $("#det_sup_assignedto_sb").text(result.data.assignedTo);

                    if (result.data.ticketAramaTarihi) {
                        var cd = new Date(result.data.ticketAramaTarihi);
                        $("#det_sup_call_time").text(moment(cd).format('DD-MM-YYYY HH:mm'));
                    }
                    if (result.data.ticketStartDate) {
                        var sd = new Date(result.data.ticketStartDate);
                        if (sd.getYear() < 2021) {
                            $("#det_sup_start_time").text("Henüz Başlanmamış");

                        } else {
                            $("#det_sup_start_time").text(moment(sd).format('DD-MM-YYYY HH:mm'));

                        }
                    }

                    $("#det_sup_active_working_user_sb").text(result.data.activeWorkingUser);
                    $("#det_sup_project_sb").text(result.data.projectCode);
                    $("#det_sup_project_line_sb").text(result.data.projectLineId);
                    $("#det_sup_project_line_work_sb").text(result.data.projectLineWorkId);
                    $("#det_sup_description_tb").text(result.data.notes);
                    $("#det_sup_notes_tb").text(result.data.note);

                    $("#det_sup_type_sb").text(result.data.ticketType);
                    //$("#support-detail-modal-label").text(result.data.ticketFirm + ' Destek Kaydı ');

                    if (result.data.fileUrl) {
                        if (result.data.fileType == 1) {
                            var link = "/SupportFile/GetSupportFile/" + result.Data.fileUrl;
                            $("#det_sup_file_sp").html('<a href="' + link + '" target="_blank">Dosyayı İndir</a>');
                        } else if (result.data.fileType == 2) {
                            $("#det_sup_file_sp").html('<a href="' + result.Data.fileUrl + '" target="_blank">Dosyayı İndir</a>');
                        }
                    } else {
                        $("#det_sup_file_sp").text('-');
                    }

                    switch (moduleName) {
                        case 'MySupport'://Benim Kayıtlarım
                            $("#det_pr_assign_bt").removeAttr("hidden");//Herkes ÜZerindeki Kayıdı bir başkasına atayabilir.
                            if (result.data.activeWorkingUserOid.toUpperCase() === result.data.loginedUserOid.toUpperCase()) {//Çalışan Kullanıcı Ben İsem
                                $("#det_start_bt").attr("hidden", "hidden");//Üzerine Al Başla Kapalı
                                $("#det_update_bt").removeAttr("hidden");//Güncelle Aktif
                            } else {//Çalışan kullanıcı ben değilsem
                                $("#det_start_bt").removeAttr("hidden"); //üzerine Al Başla Açık
                                $("#det_update_bt").attr("hidden", "hidden");//Güncelle Kapalı
                            }
                            break;
                        case 'Department'://Benim Olmayan Departman Kayıtları
                            $("#det_update_bt").attr("hidden", "hidden");//Güncelleme Kapalı
                            if (isProjectFirm === "True") {//Proje Firmasıysa
                                if (isProjectUser == "True") {//Proje Kullanıcısı
                                    $("#det_start_bt").removeAttr("hidden");//Üzerine alabilir
                                } else {//Proje Firması Değilse
                                    $("#det_start_bt").attr("hidden", "hidden");//Üzerine Alamaz
                                }
                                if (isTransferUser == "True") {//Transfer Kullanıcısıysa
                                    $("#det_pr_assign_bt").removeAttr("hidden");//Herhangi Bir Kullanıcıya Atayabilir
                                    $("#det_start_bt").removeAttr("hidden");//Kendi ÜZerine Alabilir
                                } else {//Transfer Kullanıcısı Değilse
                                    $("#det_pr_assign_bt").attr("hidden", "hidden");//Kullanıcıya Yönlendiremez
                                }
                            } else {
                                if (isTransferUser == "True") {//Transfer Kullanıcısı İse
                                    $("#det_pr_assign_bt").removeAttr("hidden");//Üzerine Alabilir
                                    $("#det_start_bt").removeAttr("hidden");//Kaydı üzerine alabilir
                                } else {//Transfer Kullanıcısı Değilse 
                                    $("#det_pr_assign_bt").attr("hidden", "hidden");//Kullanıcıya Atama Yapamaz
                                    $("#det_start_bt").attr("hidden", "hidden");//Üzerine Alamaz
                                }
                            }
                            break;
                        case 'CevapBekleyen':
                            $("#det_update_bt").attr("hidden", "hidden");//Güncelle Kapalı
                            if (isProjectFirm === "True") {//Proje Firması İse
                                if (isProjectUser == "True") {//Proje Kullanıcısı
                                    $("#det_start_bt").removeAttr("hidden");//Kaydı üzerine alabilir
                                } else {//Proje Kullanıcısıcı Değilse
                                    $("#det_start_bt").attr("hidden", "hidden");//Kaydı Üzerine Alamaz
                                }

                                if (isTransferUser == "True") {//Transfer Kullanıcısı İse
                                    $("#det_start_bt").removeAttr("hidden");//Üzerine Alabilir
                                    $("#det_pr_assign_bt").removeAttr("hidden");//Herhangi Bir Kullanıcıya Atayabilir
                                } else {//Transfer Kullanıcısı Değilse 
                                    $("#det_pr_assign_bt").attr("hidden", "hidden");//Atama Yapamaz
                                }
                            } else {//Proje Firması Değilse
                                $("#det_start_bt").removeAttr("hidden");//Tüm Kullanıcılar Üzerine Alabilir
                                if (isTransferUser == "True") {//Transfer Kullanıcı İse
                                    $("#det_pr_assign_bt").removeAttr("hidden");//Herhangi Bir KUllanıcıya Atayabilir
                                } else {//Transfer Kullanıcısı Değilse
                                    $("#det_pr_assign_bt").attr("hidden", "hidden");//Kullanıcıya Atayamaz
                                }
                            }
                            break;
                        case 'WebUser':
                            $("#det_update_bt").attr("hidden", "hidden");//Güncelle Kapalı
                            if (isProjectFirm === "True") {//Proje Firması İse
                                if (isProjectUser == "True") {//Proje Kullanıcısı
                                    $("#det_start_bt").removeAttr("hidden");//Kaydı üzerine alabilir
                                } else {//Proje Kullanıcısıcı Değilse
                                    $("#det_start_bt").attr("hidden", "hidden");//Kaydı Üzerine Alamaz
                                }

                                if (isTransferUser == "True") {//Transfer Kullanıcısı İse
                                    $("#det_start_bt").removeAttr("hidden");//Üzerine Alabilir
                                    $("#det_pr_assign_bt").removeAttr("hidden");//Herhangi Bir Kullanıcıya Atayabilir
                                } else {//Transfer Kullanıcısı Değilse 
                                    $("#det_pr_assign_bt").attr("hidden", "hidden");//Atama Yapamaz
                                }
                            } else {//Proje Firması Değilse
                                $("#det_start_bt").removeAttr("hidden");//Tüm Kullanıcılar Üzerine Alabilir
                                if (isTransferUser == "True") {//Transfer Kullanıcı İse
                                    $("#det_pr_assign_bt").removeAttr("hidden");//Herhangi Bir KUllanıcıya Atayabilir
                                } else {//Transfer Kullanıcısı Değilse
                                    $("#det_pr_assign_bt").attr("hidden", "hidden");//Kullanıcıya Atayamaz
                                }
                            }
                            break;
                        case 'FirmComplatedSupport':
                        case 'FirmOpenSupports':
                        case 'FirmWaitOnLogoSupport':
                            $("#det_update_bt").attr("hidden", "hidden");
                            $("#det_start_bt").attr("hidden", "hidden");
                            $("#det_pr_assign_bt").attr("hidden", "hidden");
                            break;
                    }

                    /*
                     var isProjectUser = $(this).attr('data-isProjectUser');
                     var isTransferUser = $(this).attr('data-isTransferUser');
                     var isProjectFirm = $(this).attr('data-isProjectFirm');
                     var moduleName = $(this).attr('data-module');
                     var isFirm = $(this).attr('data-isFirm');
                    */

                    //if (transferToUser != undefined) {
                    //    if (speCode5 == "PORTAL") {

                    //        $("#det_start_bt").attr("hidden", "hidden");
                    //        $("#det_update_bt").attr("hidden", "hidden");
                    //        if (transferToUser === "True") {
                    //            $("#det_pr_assign_bt").removeAttr("hidden");
                    //            $("#det_pr_start_bt").removeAttr("hidden");

                    //        } else {
                    //            $("#det_pr_assign_bt").attr("hidden", "hidden");
                    //            $("#det_pr_start_bt").attr("hidden", "hidden");

                    //            //if (result.data.activeWorkingUserOid.toUpperCase() === result.data.loginedUserOid.toUpperCase()) {
                    //            //    $("#det_start_bt").attr("hidden", "hidden");
                    //            //    $("#det_update_bt").removeAttr("hidden");
                    //            //} else {
                    //            //    $("#det_start_bt").removeAttr("hidden");
                    //            //    $("#det_update_bt").attr("hidden", "hidden");
                    //            //}
                    //        }
                    //    } else {
                    //        if (result.data.activeWorkingUserOid.toUpperCase() === result.data.loginedUserOid.toUpperCase()) {
                    //            $("#det_pr_assign_bt").attr("hidden", "hidden");
                    //            $("#det_pr_start_bt").attr("hidden", "hidden");
                    //            $("#det_start_bt").attr("hidden", "hidden");
                    //            $("#det_update_bt").removeAttr("hidden");
                    //        } else {
                    //            $("#det_pr_assign_bt").attr("hidden", "hidden");
                    //            $("#det_pr_start_bt").attr("hidden", "hidden");
                    //            $("#det_start_bt").removeAttr("hidden");
                    //            $("#det_update_bt").attr("hidden", "hidden");
                    //        }
                    //    }
                    //} else {
                    //    if (result.data.activeWorkingUserOid.toUpperCase() === result.data.loginedUserOid.toUpperCase()) {
                    //        $("#det_pr_assign_bt").attr("hidden", "hidden");
                    //        $("#det_pr_start_bt").attr("hidden", "hidden");
                    //        $("#det_start_bt").attr("hidden", "hidden");
                    //        $("#det_update_bt").removeAttr("hidden");
                    //    } else {
                    //        $("#det_pr_assign_bt").attr("hidden", "hidden");
                    //        $("#det_pr_start_bt").attr("hidden", "hidden");
                    //        $("#det_start_bt").removeAttr("hidden");
                    //        $("#det_update_bt").attr("hidden", "hidden");
                    //    }
                    //}



                    selectedId = supportId;
                    appointedUserOid = result.data.assignedToOid;
                    workUserOid = result.data.activeWorkingUserOid;
                    loginedUserOid = result.data.loginedUserOid;
                    isContinue = "False";


                    $("#support-detail-modal-label").text(result.data.ticketId + ' Numaralı Destek Kaydı Detayları')
                    $("#support-detail-modal").modal();
                } else {
                    toastr.error("Bir Hata Oluştu", result.message);
                }

            });

        });
        $(document).off('click', '.add-support').on('click', '.add-support', function () {
            // Support context extracted from button's data attributes
            var projCode = $(this).attr('data-project') || '';
            var projLineId = $(this).attr('data-lineid') || '';
            var projLineWorkId = $(this).attr('data-lineworkid') || '';
            
            $("#crt_sup_projectcode_hdn").val(projCode);
            $("#crt_sup_lineid_hdn").val(projLineId);
            $("#crt_sup_lineworkid_hdn").val(projLineWorkId);

            var explicitFirmOid = $(this).attr('data-firm');
            var firmOid = explicitFirmOid || window.location.pathname.substring(window.location.pathname.lastIndexOf("/") + 1);

            $('#crt_sup_firm_sb').val(firmOid).trigger('change');
            $("#support-create-modal").modal();
        });
    };

    var createMethods = function () {
        var firmOid = window.location.pathname.substring(window.location.pathname.lastIndexOf("/") + 1);

        $('#support-create-modal').on('shown.bs.modal',
            function () {


                $('#crt_sup_firm_sb').select2({
                    placeholder: "Destek Firması Seçin",
                    language: "tr"
                });

                $('#crt_sup_contact_sb').select2({
                    placeholder: "Yetkili Seçin"
                });

                $('#crt_sup_contact_mail_sb').select2({
                    placeholder: "Yetkili Mail Adresi Seçin"
                });

                $('#crt_sup_contact2_sb').select2({
                    placeholder: "Servis Yetkilisi Seçin",
                    allowClear: true
                });

                $('#crt_sup_contact2_mail_sb').select2({
                    placeholder: "Servis Yetkilisi Mail Adresi Seçin",
                    allowClear: true
                });

                $('#crt_sup_department_sb').select2({
                    placeholder: "İlgili Departman Seçin"
                });

                $('#crt_sup_assignedto_sb').select2({
                    placeholder: "Atanan Personel Seçin"
                });

                $('#crt_sup_category_sb').select2({
                    placeholder: "Destek Kategorisi Seçin",
                    allowClear: true
                });

                $('#crt_sup_subcategory_sb').select2({
                    placeholder: "Sestek Alt Kategorisi Seçin",
                    allowClear: true
                });

                $('#crt_sup_priority_sb').select2({
                    placeholder: "Destek Önceliği Seçin"
                });

                $('#crt_sup_type_sb').select2({
                    placeholder: "Destek Tipi Seçin",
                    allowClear: true
                });


                var nowDate = moment(new Date()).format('DD-MM-YYYY HH:mm');
                //$('#crt_sup_cal_time').val(nowDate);
                $('#crt_sup_cal_time').datetimepicker({
                    locale: 'tr',
                    use24hours: true,
                    format: 'DD-MM-YYYY HH:mm',
                    showMeridian: false
                });
                $('#crt_sup_cal_time_tb').val(nowDate);
            });
        $.get("/Support/GetCreateSupportModalData").done(function (result) {
            if (result.isSuccess) {

                $('#crt_sup_firm_sb').val(null).trigger('change');
                $("#crt_sup_firm_sb").empty();
                var opt = new Option('Destek Firması Seçiniz', '', false, false);
                $("#crt_sup_firm_sb").append(opt).trigger('change');
                $('#crt_sup_firm_sb').val(null).trigger('change');
                $.each(result.data.Firms, function (i, val) {
                    var opt = new Option(val.text, val.value, false, false);
                    $("#crt_sup_firm_sb").append(opt).trigger('change');
                });
                //###############################################################################################################
                $('#crt_sup_department_sb').val(null).trigger('change');
                $("#crt_sup_department_sb").empty();
                var opt = new Option('Departman Seçiniz', '', false, false);
                $("#crt_sup_department_sb").append(opt).trigger('change');
                $('#crt_sup_department_sb').val(null).trigger('change');
                $.each(result.data.Deps, function (i, val) {
                    var opt = new Option(val.text, val.value, false, false);
                    $("#crt_sup_department_sb").append(opt).trigger('change');
                });
                //###############################################################################################################
                $('#crt_sup_category_sb').val(null).trigger('change');
                $("#crt_sup_category_sb").empty();
                var opt = new Option('Kategori Seçiniz', '', false, false);
                $("#crt_sup_category_sb").append(opt).trigger('change');
                $('#crt_sup_category_sb').val(null).trigger('change');
                $.each(result.data.Categories, function (i, val) {
                    var opt = new Option(val.text, val.value, false, false);
                    $("#crt_sup_category_sb").append(opt).trigger('change');
                });
                //###############################################################################################################
                $('#crt_sup_priority_sb').val(null).trigger('change');
                $("#crt_sup_priority_sb").empty();
                var opt = new Option('Öncelik Seçiniz', '', false, false);
                $("#crt_sup_priority_sb").append(opt).trigger('change');
                $('#crt_sup_priority_sb').val(null).trigger('change');
                $.each(result.data.Priorities, function (i, val) {
                    var opt = new Option(val.key, val.val, false, false);
                    $("#crt_sup_priority_sb").append(opt).trigger('change');
                });
                //###############################################################################################################
                $('#crt_sup_type_sb').val(null).trigger('change');
                $("#crt_sup_type_sb").empty();
                var opt = new Option('Destek Türü Seçiniz', '', false, false);
                $("#crt_sup_type_sb").append(opt).trigger('change');
                $('#crt_sup_type_sb').val(null).trigger('change');
                $.each(result.data.Types, function (i, val) {
                    var opt = new Option(val.text, val.value, false, false);
                    $("#crt_sup_type_sb").append(opt).trigger('change');
                });
                //###############################################################################################################

            } else {
                toastr.error("Bir Hata Oluştu", result.message);
            }
        });

        $("#crt_sup_firm_sb").on('change',
            function () {
                var firmId = $(this).find(":selected").val();
                if (!firmId) {
                    return;
                }
                $.get("/Support/GetFirmOpenSupports?firmOid=" + firmId).done(function (result) {
                    if (result.isSuccess) {
                        if (result.data.length > 0) {
                            var htmlData = "";
                            $.each(result.data, function (i, val) {
                                htmlData += '<tr><td title="TicketId">' + val.ticketId + '</td>' +
                                    '<td title = "CallTime" >' + val.ticketAramaTarihi + '</td >' +
                                    '<td title="Apointed">' + val.assignedTo + '</td>' +
                                    '<td title="Description">' + val.description + '</td>' +
                                    '</tr > ';
                            });
                            $("#FirmOpenSupportTable tbody").html(htmlData);

                            $("#firm-open-support-modal").modal();


                        }
                    }
                });
                //Firma Açık Destek Kaydı Kontrol

                $.get("/Support/GetCreateSupportModalFirmData?firmOid=" + firmId).done(function (result) {
                    if (result.isSuccess) {
                        $('#crt_sup_contact_sb').val(null).trigger('change');
                        $("#crt_sup_contact_sb").empty();
                        //var opt = new Option('Yetkili Seçiniz', '', false, false);
                        //$("#crt_sup_contact_sb").append(opt).trigger('change');
                        //$('#crt_sup_contact_sb').val(null).trigger('change');
                        $.each(result.data.Contacts, function (i, val) {
                            var opt = new Option(val.text, val.value, false, false);
                            $("#crt_sup_contact_sb").append(opt).trigger('change');
                        });
                        //###############################################################################################################
                        $('#crt_sup_contact2_sb').val(null).trigger('change');
                        $("#crt_sup_contact2_sb").empty();
                        //var opt = new Option('Servis Yetkilisi Seçiniz', '', false, false);
                        //$("#crt_sup_contact2_sb").append(opt).trigger('change');
                        //$('#crt_sup_contact2_sb').val(null).trigger('change');
                        $.each(result.data.Contacts, function (i, val) {
                            var opt = new Option(val.text, val.value, false, false);
                            $("#crt_sup_contact2_sb").append(opt).trigger('change');
                            $('#crt_sup_contact2_sb').val(null).trigger('change');

                        });

                        //###############################################################################################################
                        var now = new Date($.now());
                        var ld = new Date(result.data.Supports.logoSupportExpDate);
                        var nld = new Date(result.data.Supports.newLogoSupportExpDate);
                        var td = new Date(result.data.Supports.tecnicalSupportExpDate);
                        var ntd = new Date(result.data.Supports.newTecnicalSupportExpDate);

                        if (result.data.Supports.logoSupport && now <= ld) {
                            $('#crt_logo_cb').prop('checked', true);
                            $("#crt_sup_logo_exp_lb").removeAttr("hidden");
                            $("#crt_sup_logo_exp_lb").html(moment(ld).format('DD-MM-YYYY HH:mm'));
                        } else {
                            $('#crt_logo_cb').prop('checked', false);
                            $("#crt_sup_logo_exp_lb").attr("hidden", "hidden");
                            $("#crt_sup_logo_exp_lb").html(moment(ld).format(''));
                        }
                        if (result.data.Supports.newLogoSupport && now <= nld) {
                            $('#crt_new_logo_sup_cb').prop('checked', true);
                            $("#crt_sup_new_logo_exp_lb").removeAttr("hidden");
                            $("#crt_sup_new_logo_exp_lb").html(moment(nld).format('DD-MM-YYYY HH:mm'));
                        } else {
                            $('#crt_new_logo_sup_cb').prop('checked', false);
                            $("#crt_sup_new_logo_exp_lb").attr("hidden", "hidden");
                            $("#crt_sup_new_logo_exp_lb").html(moment(nld).format(''));
                        }
                        if (result.data.Supports.tecnicalSupport && now <= td) {
                            $('#crt_sup_tec_cb').prop('checked', true);
                            $("#crt_tec_sup_exp_lb").removeAttr("hidden");
                            $("#crt_tec_sup_exp_lb").html(moment(td).format('DD-MM-YYYY HH:mm'));
                        } else {
                            $('#crt_sup_tec_cb').prop('checked', false);
                            $("#crt_tec_sup_exp_lb").attr("hidden", "hidden");
                            $("#crt_tec_sup_exp_lb").html(moment(td).format(''));
                        }
                        if (result.data.Supports.newTecnicalSupport && now <= ntd) {
                            $('#crt_new_tec_sup_cb').prop('checked', true);
                            $("#crt_new_tec_sup_ex_lb").removeAttr("hidden");
                            $("#crt_new_tec_sup_ex_lb").html(moment(ntd).format('DD-MM-YYYY HH:mm'));
                        } else {
                            $('#crt_new_tec_sup_cb').prop('checked', false);
                            $("#crt_new_tec_sup_ex_lb").attr("hidden", "hidden");
                            $("#crt_new_tec_sup_ex_lb").html(moment(ntd).format(''));
                        }

                    } else {
                        toastr.error("Bir Hata Oluştu", result.message);
                    }

                });


            });
        $("#crt_sup_contact_sb").on('change',
            function () {
                var contactId = $(this).find(":selected").val();
                if (!contactId) {
                    return;
                }
                $.get("/Support/GetCreateSupportFirmContactMailAddeses?contactOid=" + contactId).done(function (result) {
                    if (result.isSuccess) {
                        $('#crt_sup_contact_mail_sb').val(null).trigger('change');
                        $("#crt_sup_contact_mail_sb").empty();
                        //var opt = new Option('Yetkili Seçiniz', '', false, false);
                        //$("#crt_sup_contact_mail_sb").append(opt).trigger('change');
                        //$('#crt_sup_contact_mail_sb').val(null).trigger('change');
                        $.each(result.data, function (i, val) {
                            var opt = new Option(val.text, val.value, false, false);
                            $("#crt_sup_contact_mail_sb").append(opt).trigger('change');
                        });
                    } else {
                        toastr.error("Bir Hata Oluştu", result.message);
                    }
                });
            });
        $("#crt_sup_contact2_sb").on('change',
            function () {
                var contactId = $(this).find(":selected").val();
                if (!contactId) {
                    $('#crt_sup_contact2_mail_sb').val(null).trigger('change');
                    $("#crt_sup_contact2_mail_sb").empty();
                    return;
                }
                $.get("/Support/GetCreateSupportFirmContactMailAddeses?contactOid=" + contactId).done(function (result) {
                    if (result.isSuccess) {
                        $('#crt_sup_contact2_mail_sb').val(null).trigger('change');
                        $("#crt_sup_contact2_mail_sb").empty();
                        //var opt = new Option('Yetkili Seçiniz', '', false, false);
                        //$("#crt_sup_contact2_mail_sb").append(opt).trigger('change');
                        //$('#crt_sup_contact2_mail_sb').val(null).trigger('change');
                        $.each(result.data, function (i, val) {
                            var opt = new Option(val.text, val.value, false, false);
                            $("#crt_sup_contact2_mail_sb").append(opt).trigger('change');
                            $('#crt_sup_contact2_mail_sb').val(null).trigger('change');
                        });
                    } else {
                        toastr.error("Bir Hata Oluştu", result.message);
                    }
                });
            });
        $("#crt_sup_department_sb").on('change',
            function () {
                var departmentId = $(this).find(":selected").val();
                if (!departmentId) {
                    return;
                }
                $.get("/Support/GetCreateSupportDepartmentUsers?departmentOid=" + departmentId).done(function (result) {
                    if (result.isSuccess) {
                        $('#crt_sup_assignedto_sb').val(null).trigger('change');
                        $("#crt_sup_assignedto_sb").empty();
                        var opt = new Option('Yetkili Seçiniz', '', false, false);
                        $("#crt_sup_assignedto_sb").append(opt).trigger('change');
                        $('#crt_sup_assignedto_sb').val(null).trigger('change');
                        $.each(result.data, function (i, val) {
                            var opt = new Option(val.text, val.value, false, false);
                            $("#crt_sup_assignedto_sb").append(opt).trigger('change');
                        });
                    } else {
                        toastr.error("Bir Hata Oluştu", result.message);
                    }
                });
            });
        $("#crt_sup_category_sb").on('change',
            function () {
                var categoryId = $(this).find(":selected").val();
                if (!categoryId) {
                    return;
                }
                $.get("/Support/GetCreateSupportSubCategoryList?categoryOid=" + categoryId).done(function (result) {
                    if (result.isSuccess) {
                        $('#crt_sup_subcategory_sb').val(null).trigger('change');
                        $("#crt_sup_subcategory_sb").empty();
                        var opt = new Option('Alt Kategori Seçiniz', '', false, false);
                        $("#crt_sup_subcategory_sb").append(opt).trigger('change');
                        $('#crt_sup_subcategory_sb').val(null).trigger('change');
                        $.each(result.data, function (i, val) {
                            var opt = new Option(val.text, val.value, false, false);
                            $("#crt_sup_subcategory_sb").append(opt).trigger('change');
                        });
                    } else {
                        toastr.error("Bir Hata Oluştu", result.message);
                    }
                });
            });
        $("#crt_sup_save_bt").click(function () {
            $("#crt_sup_save_bt").attr("hidden", "hidden")
            var model = {
                Firm: $("#crt_sup_firm_sb").val(),
                Contact: $("#crt_sup_contact_sb").val(),
                ContactMail: $("#crt_sup_contact_mail_sb").val(),
                Contact2: $("#crt_sup_contact2_sb").val(),
                Contact2Mail: $("#crt_sup_contact2_mail_sb").val(),
                Department: $("#crt_sup_department_sb").val(),
                AssignedTo: $("#crt_sup_assignedto_sb").val(),
                MainCategory: $("#crt_sup_category_sb").val(),
                SubCategory: $("#crt_sup_subcategory_sb").val(),
                SupportType: $("#crt_sup_type_sb").val(),
                CallTime: $("#crt_sup_cal_time").find("input").val(),
                Priority: $("#crt_sup_priority_sb").val(),
                Description: $("#crt_sup_description_tb").val(),
                // Include Project Context
                ProjectCode: $("#crt_sup_projectcode_hdn").val(),
                ProjectLineId: $("#crt_sup_lineid_hdn").val(),
                ProjectLineWorkId: $("#crt_sup_lineworkid_hdn").val()
            }


            $.post("/Support/CreateSupport", { model: model }).done(function (result) {
                if (result.isSuccess) {
                    setTimeout(function () {
                        window.location.reload();
                    }, 3000);
                    toastr.success("Destek Kaydı Başarıyla Oluşturuldu", result.message);

                } else {
                    $("#crt_sup_save_bt").removeAttr("hidden");
                    toastr.error("Bir Hata Oluştu", result.message);
                }
            });
        });
    };

    var detailMethots = function () {

        $('#support-send-to-user-modal').on('shown.bs.modal',
            function () {
                $('#sup_send_user_sb').select2({
                    placeholder: "Kullanıcı Seçin",
                    language: "tr"
                });

                $("#sup_send_save_bt").click(function () {
                    /*$("#support-detail-modal").modal("toggle");*/
                    //
                    var userId = $("#sup_send_user_sb").val();
                    var model = {
                        TicketOid: selectedId,
                        UserId: userId,
                        Description: $("#sup_send_description_tb").val()
                    }
                    $.post("/Support/SupportSendToUser", { model: model }).done(function (result) {
                        if (result.isSuccess) {
                            /* if (result.data.isUpdated) {*/
                            //UpdateSupport();
                            //$("#support-detail-modal").modal("toggle");
                            toastr.success("Destek kaydı başarıyla kullanıcıya atandı", "Başarılı");
                            setTimeout(function () {
                                window.location.reload();
                            }, 3000);
                            /*  } else {*/
                            //    $("#takeonModalContentTitle").text(result.data.contentTitle);
                            //    $("#takeonModalDesc").text(result.data.contentDescription);
                            //    $("#takeOnSupportModalLabel").text(result.data.modalTitle);

                            //    $("#support-take-on-modal").modal();
                            //}
                        } else {
                            toastr.error("İşlem Başarısız", result.message);
                        }
                    });
                });

            });





        $("#det_pr_assign_bt").click(function () {


            $('#sup_send_user_sb').val(null).trigger('change');
            $("#sup_send_user_sb").empty();
            $.get("/UserAccount/GetCrmUserSelectList").done(function (result) {
                if (result.isSuccess) {
                    /* $("#sup_send_user_sb").html('').select2({ data: { id: null, text: null } });*/
                    $.each(result.data,
                        function (i, val) {
                            var opt = new Option(val.text, val.value, false, false);
                            $("#sup_send_user_sb").append(opt).trigger('change');
                            $('#sup_send_user_sb').val(null).trigger('change');
                        });

                    $("#support-detail-modal").modal("toggle");
                    $("#support-send-to-user-modal").modal();
                } else {

                }
            });
        });

        $("#det_start_bt").click(function () {
            $("#support-detail-modal").modal("toggle");
            //
            $.get("/Support/CheckTakeOnSupport?oid=" + selectedId).done(function (result) {
                if (result.isSuccess) {
                    if (result.data.isUpdated) {
                        //setTimeout(function () {
                        //    window.location.reload();
                        //}, 3000);
                        UpdateSupport();
                        $("#support-detail-modal").modal("toggle");
                        toastr.success("Başarılı", result.message);
                    } else {
                        $("#takeonModalContentTitle").text(result.data.contentTitle);
                        $("#takeonModalDesc").text(result.data.contentDescription);
                        $("#takeOnSupportModalLabel").text(result.data.modalTitle);

                        $("#support-take-on-modal").modal();
                    }
                } else {
                    toastr.error("İşlem Başarısız", result.message);
                }
            });
        });

        

        $("#det_pr_start_bt").click(function () {
            $("#support-detail-modal").modal("toggle");
            //
            $.get("/Support/CheckTakeOnSupport?oid=" + selectedId).done(function (result) {
                if (result.isSuccess) {
                    if (result.data.isUpdated) {
                        //setTimeout(function () {
                        //    window.location.reload();
                        //}, 3000);
                        UpdateSupport();
                        $("#support-detail-modal").modal("toggle");
                        toastr.success("Başarılı", result.message);
                    } else {
                        $("#takeonModalContentTitle").text(result.data.contentTitle);
                        $("#takeonModalDesc").text(result.data.contentDescription);
                        $("#takeOnSupportModalLabel").text(result.data.modalTitle);

                        $("#support-take-on-modal").modal();
                    }
                } else {
                    toastr.error("İşlem Başarısız", result.message);
                }
            });
        });

        $("#sup_accept_take_on_bt").click(function () {
            $("#support-take-on-modal").modal("toggle");
            var model = {
                TicketOid: selectedId,
                Description: $("#to_sup_description_tb").val(),
                UserOid: loginedUserOid
            };

            $.post("/Support/TakeOnSupport", { model: model }).done(function (result) {
                if (result.isSuccess) {
                    setTimeout(function () {
                        window.location.reload();
                    }, 3000);
                    toastr.success(result.message, "Başarılı");
                } else {
                    toastr.error(result.message, "İşlem Başarısız");
                }
            });

        });

        $("#det_update_bt").click(function () {
            UpdateSupport();
        });

        function UpdateSupport () {
            $.get("/Support/GetUpdateSupportInfo?supportId=" + selectedId).done(function (result) {
                if (result.isSuccess) {
                    var now = new Date($.now());
                    var ld = new Date(result.data.AgrDet.firmSupportStatus.logoSupportExpDate);
                    var nld = new Date(result.data.AgrDet.firmSupportStatus.newLogoSupportExpDate);
                    var td = new Date(result.data.AgrDet.firmSupportStatus.tecnicalSupportExpDate);
                    var ntd = new Date(result.data.AgrDet.firmSupportStatus.newTecnicalSupportExpDate);
                    //appointedUserOid = result.data.AssignedToOid;
                    //workUserOid = result.data.ActiveWorkingUserOid;

                    if (result.data.AgrDet.firmSupportStatus.logoSupport && now <= ld) {
                        $('#upt_logo_cb').prop('checked', true);
                        $("#upt_sup_logo_exp_lb").removeAttr("hidden");
                        $("#upt_sup_logo_exp_lb").html(moment(ld).format('DD-MM-YYYY HH:mm'));
                    } else {
                        $('#upt_logo_cb').prop('checked', false);
                        $("#upt_sup_logo_exp_lb").attr("hidden", "hidden");
                        $("#upt_sup_logo_exp_lb").html(moment(ld).format(''));
                    }
                    if (result.data.AgrDet.firmSupportStatus.newLogoSupport && now <= nld) {
                        $('#upt_new_logo_sup_cb').prop('checked', true);
                        $("#upt_sup_new_logo_exp_lb").removeAttr("hidden");
                        $("#upt_sup_new_logo_exp_lb").html(moment(nld).format('DD-MM-YYYY HH:mm'));
                    } else {
                        $('#upt_new_logo_sup_cb').prop('checked', false);
                        $("#upt_sup_new_logo_exp_lb").attr("hidden", "hidden");
                        $("#upt_sup_new_logo_exp_lb").html(moment(nld).format(''));
                    }
                    if (result.data.AgrDet.firmSupportStatus.tecnicalSupport && now <= td) {
                        $('#upt_sup_tec_cb').prop('checked', true);
                        $("#upt_tec_sup_exp_lb").removeAttr("hidden");
                        $("#upt_tec_sup_exp_lb").html(moment(td).format('DD-MM-YYYY HH:mm'));
                    } else {
                        $('#upt_sup_tec_cb').prop('checked', false);
                        $("#upt_tec_sup_exp_lb").attr("hidden", "hidden");
                        $("#upt_tec_sup_exp_lb").html(moment(td).format(''));
                    }
                    if (result.data.AgrDet.firmSupportStatus.newTecnicalSupport && now <= ntd) {
                        $('#upt_new_tec_sup_cb').prop('checked', true);
                        $("#upt_new_tec_sup_ex_lb").removeAttr("hidden");
                        $("#upt_new_tec_sup_ex_lb").html(moment(ntd).format('DD-MM-YYYY HH:mm'));
                    } else {
                        $('#upt_new_tec_sup_cb').prop('checked', false);
                        $("#upt_new_tec_sup_ex_lb").attr("hidden", "hidden");
                        $("#upt_new_tec_sup_ex_lb").html(moment(ntd).format(''));
                    }

                    $("#updateSupportModalLabel").text(result.data.Support.ticketId + " Numaralı Destek Kaydı Güncelle");


                    $("#upt_sup_description_tb").text(result.data.Support.notes);
                    $("#upt_sup_department_sb").text(result.data.Support.assignedDepartment);
                    $("#upt_sup_assignedto_sb").text(result.data.Support.assignedTo);
                    $("#upt_sup_firm_sb").text(result.data.Support.ticketFirm);
                    $("#upt_sup_contact_sb").text(result.data.Support.ticketContact);
                    $("#upt_sup_contact_phones_sb").text(result.data.AgrDet.ticketContactPhone);
                    $("#upt_sup_category_sb").text(result.data.Support.ticketMainCategory);
                    $("#upt_sup_subcategory_sb").text(result.data.Support.ticketSubCategory);



                    $("#upt_ticket_state").empty();
                    $('#upt_ticket_state').val(null).trigger('change');
                    $.each(result.data.State, function (i, val) {
                        var opt = new Option(val.text, val.value, false, val.selected);
                        $("#upt_ticket_state").append(opt).trigger('change');
                    });

                    $("#upt_support_type").empty();
                    $('#upt_support_type').val(null).trigger('change');
                    $.each(result.data.Type, function (i, val) {
                        var opt = new Option(val.text, val.value, false, val.selected);
                        $("#upt_support_type").append(opt).trigger('change');
                    });


                    $('#upt_ticket_state').val(result.data.Support.ticketState).trigger('change');
                    $('#upt_support_type').val(result.data.Support.ticketType).trigger('change');

                    $("#upt_sup_priority_sb").text(result.data.Support.ticketType);
                    $("#upt_sup_notlar_tb").val(result.data.Support.notlar);
                    switch (result.data.Support.ticketState.toUpperCase()) {
                        case "07D17E00-B999-4A39-8C01-4E0CEB1925FD"://Tamamlandı
                            $("#upt_sup_close_div").removeAttr("hidden");
                            $("#upt_sup_price_div").attr("hidden", "hidden");
                            $("#upt_sup_wait_inlogo_div").attr("hidden", "hidden");
                            $("#upt_sup_notes_div").removeAttr("hidden");
                            break;
                        case "BD6344E9-E338-47A3-B6C0-38D9385B80B4"://Ücreli Kapandı
                            $("#upt_sup_close_div").removeAttr("hidden");
                            $("#upt_sup_price_div").removeAttr("hidden");
                            $("#upt_sup_wait_inlogo_div").attr("hidden", "hidden");
                            $("#upt_sup_notes_div").removeAttr("hidden");
                            break;
                        case "439E8FB4-B576-4650-83DE-656EE3CFD3E7"://Logoda Bekliyor
                            $("#upt_sup_close_div").attr("hidden", "hidden");
                            $("#upt_sup_price_div").attr("hidden", "hidden");
                            $("#upt_sup_wait_inlogo_div").removeAttr("hidden");
                            $("#upt_sup_notes_div").removeAttr("hidden");
                            break;
                        case "7AD9A7AE-AD2C-4CAA-BE50-42130D1EB57F"://Destek Ücreti Onaylanmadı.
                        case "F3D3AD27-FFBF-48C2-B2A6-5761BC6E45E0"://Sistem Bilgisayar Onay Bekliyor
                        case "5D982B4A-4D94-43F2-960F-834743CBE1B0"://Açık Kayıt
                        case "56C7DB4D-EFB7-4103-952D-84A719C94020"://Ücret Onayı Bekleniyor.
                        case "B61F4BCF-B108-4676-8EDE-91AC3538E916"://Analizde
                        case "B35C770E-7D9E-4523-B3F6-C61BA273B61C"://Versiyon Bekleniyor
                        case "C6DAF753-63BF-4825-9476-D38872472727"://Parçalı Devir
                        case "A048AC84-9DDE-4A2C-86AA-D3EF76506103"://Proje Kapatma
                        case "2E1076A9-7B80-418A-A8BD-D72074D577B6"://Teklif Verilecek
                            $("#upt_sup_close_div").attr("hidden", "hidden");
                            $("#upt_sup_price_div").attr("hidden", "hidden");
                            $("#upt_sup_wait_inlogo_div").attr("hidden", "hidden");
                            $("#upt_sup_notes_div").attr("hidden", "hidden");
                            break;
                    }


                    //$("#").text(result.data.support.);

                    $("#support-detail-modal").modal("toggle");
                    $("#support-update-modal").modal();
                } else {

                }
            });
        }

    };

    var updateMethots = function () {
        $('#support-update-modal').on('shown.bs.modal',
            function () {

                $('#upt_ticket_state').select2({
                    placeholder: "Destek Durumu Seçin",
                    language: "tr"
                });
                $('#upt_support_type').select2({
                    placeholder: "Destek Türünü Seçin",
                    language: "tr"
                });
                $('#upt_currency_type').select2({
                    placeholder: "Döviz Türü Seçin",
                    language: "tr"
                });



                $('#upt_ticket_start_date').datetimepicker({
                    locale: 'tr',
                    use24hours: true,
                    format: 'DD-MM-YYYY HH:mm',
                    showMeridian: false
                });


                $('#upt_ticket_completed_date').datetimepicker({
                    locale: 'tr',
                    use24hours: true,
                    format: 'DD-MM-YYYY HH:mm',
                    showMeridian: false
                });

                $('#upt_register_date').datetimepicker({
                    locale: 'tr',
                    use24hours: true,
                    format: 'DD-MM-YYYY HH:mm',
                    showMeridian: false
                });


                //TODO : Eğer gerek olursa detay metotları yazılacak
            });

        $("#upt_ticket_state").change(function () {
            var val = $("#upt_ticket_state").val();

            if (!val) { return; }

            switch (val.toUpperCase()) {
                case "07D17E00-B999-4A39-8C01-4E0CEB1925FD"://Tamamlandı
                    $("#upt_sup_close_div").removeAttr("hidden");
                    $("#upt_sup_price_div").attr("hidden", "hidden");
                    $("#upt_sup_wait_inlogo_div").attr("hidden", "hidden");
                    $("#upt_sup_notes_div").removeAttr("hidden");
                    break;
                case "BD6344E9-E338-47A3-B6C0-38D9385B80B4"://Ücreli Kapandı
                    $("#upt_sup_close_div").removeAttr("hidden");
                    $("#upt_sup_price_div").removeAttr("hidden");
                    $("#upt_sup_wait_inlogo_div").attr("hidden", "hidden");
                    $("#upt_sup_notes_div").removeAttr("hidden");
                    break;
                case "439E8FB4-B576-4650-83DE-656EE3CFD3E7"://Logoda Bekliyor
                    $("#upt_sup_close_div").attr("hidden", "hidden");
                    $("#upt_sup_price_div").attr("hidden", "hidden");
                    $("#upt_sup_wait_inlogo_div").removeAttr("hidden");
                    $("#upt_sup_notes_div").removeAttr("hidden");
                    break;
                case "7AD9A7AE-AD2C-4CAA-BE50-42130D1EB57F"://Destek Ücreti Onaylanmadı.
                case "F3D3AD27-FFBF-48C2-B2A6-5761BC6E45E0"://Sistem Bilgisayar Onay Bekliyor
                case "5D982B4A-4D94-43F2-960F-834743CBE1B0"://Açık Kayıt
                case "56C7DB4D-EFB7-4103-952D-84A719C94020"://Ücret Onayı Bekleniyor.
                case "B61F4BCF-B108-4676-8EDE-91AC3538E916"://Analizde
                case "B35C770E-7D9E-4523-B3F6-C61BA273B61C"://Versiyon Bekleniyor
                case "C6DAF753-63BF-4825-9476-D38872472727"://Parçalı Devir
                case "A048AC84-9DDE-4A2C-86AA-D3EF76506103"://Proje Kapatma
                case "2E1076A9-7B80-418A-A8BD-D72074D577B6"://Teklif Verilecek
                    $("#upt_sup_close_div").attr("hidden", "hidden");
                    $("#upt_sup_price_div").attr("hidden", "hidden");
                    $("#upt_sup_wait_inlogo_div").attr("hidden", "hidden");
                    $("#upt_sup_notes_div").attr("hidden", "hidden");
                    break;
            }
        });
        $("#upt_sup_save_bt").click(function () {
            var model = {
                Oid: selectedId,
                _LastModifiedBy: loginedUserOid,
                TicketStartDate: $("#upt_ticket_start_date_tb").val(),
                TicketCompletedDate: $("#upt_ticket_completed_date_tb").val(),
                TicketYapilanIslem: $("#upt_sup_notes_tb").val(),
                TicketUcret: $("#upt_ticket_ucret").val(),
                CurrencyType: $("#upt_currency_type").val(),
                JiraOrSupportCode: $("#upt_jira_or_support_code").val(),
                RegisterDate: $("#upt_register_date_tb").val(),
                Version: $("#upt_version").val(),
                Notlar: $("#upt_sup_notlar_tb").val(),
                TicketState: $("#upt_ticket_state").val(),
                TicketType: $("#upt_support_type").val()
            }
            $.post("/Support/UpdateSupport", { model: model }).done(function (result) {
                if (result.isSuccess) {
                    setTimeout(function () {
                        window.location.reload();
                    }, 3000);
                    toastr.success(result.message, "Destek Kaydı Başarıyla Güncellendi");

                } else {
                    $("#crt_sup_save_bt").removeAttr("hidden");
                    toastr.error(result.message, "Bir Hata Oluştu");
                }
            });
        });

    };


    return {


        initBaseControls: function () {
            modalMethods();
            createMethods();
            detailMethots();
            updateMethots();
        }

    };

}();

jQuery(document).ready(function () {
    SupportModalPartialPage.initBaseControls();

});
