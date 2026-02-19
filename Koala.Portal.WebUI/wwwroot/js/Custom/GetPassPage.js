"use strict";
$(document).ready(function () {
    $("#data-Table-Search").on("keyup", function () {
        var value = $(this).val().toLowerCase();
        $("#data-Table tbody tr").filter(function () {
            $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
        });
    });
    //$("#data-Table").DataTable();
});

var selectedLine = '';
function AddModal() {
    $("#AddModal").modal();
}

$(".show-detail").click(function () {
    var id = $(this).data("id");
    $.get("/UserAccount/GetLineInfoGetPass?lineId=" + id).done(function (result) {
        if (result.isSuccess) {
            $("#ip_Det").html(result.data.ip);
            $("#localIp_Det").html(result.data.localIp);
            $("#port_Det").html(result.data.port);
            $("#userName_Det").html(result.data.userName);
            $("#password_Det").html(result.data.password);
            $("#DetailModal").modal();
        } else {

        }
    });
});

function UpdateModalShow(lineId) {
    selectedLine = lineId;

    $.post("/Home/GetUpdateData/" + lineId).done(function (result) {
        if (result.IsSuccess) {
            $("#UpdateFirmName").val(result.Data.FirmName);
            $("#UpdateIp").val(result.Data.Ip);
            $("#UpdateLocalIp").val(result.Data.LocalIp);
            $("#UpdatePassword").val(result.Data.Password);
            $("#UpdatePort").val(result.Data.Port);
            $("#UpdateServerTypeId").val(result.Data.ServerTypeId);
            $("#UpdateUserName").val(result.Data.UserName);
            $("#UpdateVpnAplication").val(result.Data.VpnAplication);
            $("#UpdateName").val(result.Data.Name);
            $("#UpdateDescription").val(result.Data.Description);


            $('#UpdateModal').modal();
        }
    });


}
function save() {
    var model = {
        ServerTypeId: $("#ServerTypeId").val(),
        FirmName: $("#FirmName").val(),
        Name: $("#Name").val(),
        Description: $("#Description").val(),
        VpnAplication: $("#VpnAplication").val(),
        Ip: $("#Ip").val(),
        LocalIp: $("#LocalIp").val(),
        Port: $("#Port").val(),
        UserName: $("#UserName").val(),
        Password: $("#Password").val()
    }

    $.post("/Home/AddLine", { model: model }).done(function (result) {
        if (result.IsSuccess) {
            location.reload(true);
        } else {
            Alert("Ekleme İşlemi Başarısız");
        }
    });


}

function update() {
    var model = {
        Id: selectedLine,
        ServerTypeId: $("#UpdateServerTypeId").val(),
        Name: $("#UpdateName").val(),
        Description: $("#UpdateDescription").val(),
        FirmName: $("#UpdateFirmName").val(),
        VpnAplication: $("#UpdateVpnAplication").val(),
        Ip: $("#UpdateIp").val(),
        LocalIp: $("#UpdateLocalIp").val(),
        Port: $("#UpdatePort").val(),
        UserName: $("#UpdateUserName").val(),
        Password: $("#UpdatePassword").val()
    }

    $.post("/Home/UpdateLine", { model: model }).done(function (result) {
        if (result.IsSuccess) {
            location.reload(true);
        } else {
            Alert("Güncelleme İşlemi Başarısız");
        }
    });


}

function Send2UserModalShow(lineId) {
    selectedLine = lineId;
    $.get("/Home/GetUserSelectList").done(function (result) {
        if (result.IsSuccess) {
            $("#send_User").html('').select2({ data: { id: null, text: null } });
            $.each(result.Data,
                function (i, val) {
                    var opt = new Option(val.Key, val.Value, false, false);
                    $("#send_User").append(opt).trigger('change');
                });
            $('#Send2UserModal').modal();
        }
    });

}

function Send2User() {
    var selectedUserId = $("#send_User").val();
    $.post("/Home/Send2User?lineId=" + selectedLine + "&userId=" + selectedUserId).done(function (result) {
        if (result.IsSuccess) {
            location.reload();
        }
    });

}

function RemoveLine(id) {
    $.post("/Home/RemoveLine?id=" + id).done(function (result) {
        if (result) {
            location.reload(true);
        } else {
            Alert("Silme İşlemi Başarısız");
        }
    });
}


var KTDatatablesExtensionsResponsive = function () {

    var initTable1 = function () {
        var table = $('#MyData');

        // begin first table
        table.DataTable({
            responsive: true,
            local: 'tr',

            columnDefs: [

                {
                    width: '150px',
                    targets: 2,
                    render: function (data, type, full, meta) {
                        var s = 0;
                        switch (data) {
                            case 'NAS': s = 1; break;
                            case 'Logo Tiger': s = 2; break;
                            case 'Panel': s = 3; break;
                            case 'VPN': s = 4; break;
                            case 'Logo-CRM': s = 5; break;
                            case 'Berq-WG-Modem-AP': s = 6; break;
                            case 'Logo Go': s = 7; break;
                            case 'Uzak Masaüstü': s = 8; break;
                            case 'E-Fatura': s = 9; break;
                            case 'Logo RestService': s = 10; break;
                            case 'Doruk Panel': s = 11; break;
                            case 'Office 365 Panel': s = 12; break;
                            case 'Firewall': s = 13; break;
                            case 'Virüs Programı': s = 14; break;
                            case 'Sql Server': s = 15; break;
                            case 'E-Arşiv': s = 16; break;
                            case 'Modem': s = 17; break;
                            case 'LOGO LSM': s = 18; break;
                            case 'Identity Server Resource': s = 19; break;
                            case 'Identity Server Client': s = 20; break;

                        }
                        var status = {
                            1: { 'title': 'NAS', 'class': 'label-light-primary' },
                            2: { 'title': 'Logo Tiger', 'class': ' label-light-success' },
                            3: { 'title': 'Panel ', 'class': ' label-light-primary' },
                            4: { 'title': 'VPN', 'class': ' label-light-warning' },
                            5: { 'title': 'Logo-CRM', 'class': ' label-light-success' },
                            6: { 'title': 'Berq-WG-Modem-AP', 'class': ' label-light-info' },
                            7: { 'title': 'Logo Go', 'class': ' label-light-success' },
                            8: { 'title': 'Uzak Masaüstü', 'class': ' label-light-warning' },
                            9: { 'title': 'E-Fatura', 'class': ' label-light-success' },
                            10: { 'title': 'Logo RestService', 'class': ' label-light-success' },
                            11: { 'title': 'Doruk Panel', 'class': ' label-light-primary' },
                            12: { 'title': 'Office 365 Panel', 'class': ' label-light-primary' },
                            13: { 'title': 'Firewall', 'class': ' label-light-danger' },
                            14: { 'title': 'Virüs Programı', 'class': ' label-light-danger' },
                            15: { 'title': 'Sql Server', 'class': ' label-light-warning' },
                            16: { 'title': 'E-Arşiv', 'class': ' label-light-success' },
                            17: { 'title': 'Modem', 'class': ' label-light-info' },
                            18: { 'title': 'LOGO LSM', 'class': ' label-light-danger' },
                            19: { 'title': 'Identity Server Resource', 'class': ' label-info' },
                            20: { 'title': 'Identity Server Client', 'class': ' label-primary' }
                        };
                        if (typeof status[s] === 'undefined') {
                            return '<span class="label label-lg font-weight-bold' + status[2].class + ' label-inline">' + status[2].title + '</span>'; //data;
                        }
                        return '<span class="label label-lg font-weight-bold' + status[s].class + ' label-inline">' + status[s].title + '</span>';
                    },
                },
                {
                    width: '200px',
                    targets: 3,
                },
                {
                    width: '150px',
                    targets: 4,
                }

            ]
        });
    };

    return {
        //main function to initiate the module
        init: function () {
            initTable1();
        }
    };
}();

jQuery(document).ready(function () {
    KTDatatablesExtensionsResponsive.init();
});

$('#send_User').select2({
    placeholder: 'Kullanıcı Seçiniz',
    formatNoMatches: "Eşleşen Öğe Bulunamadı"
});
