'use strict';
var ClaimToUserSelectList = function () {


    var userClaimList = function () {
        // Dual Listbox
        var _this = document.getElementById('Claims');

        // init dual listbox
        var dualListBox = new DualListbox(_this, {
            addEvent: function (value) {
                console.log(value);
            },
            removeEvent: function (value) {
                console.log(value);
            },
            availableTitle: 'Mevcut Yetkiler',
            selectedTitle: 'Seçili Yetkiler',
            addButtonText: 'Ekle',
            removeButtonText: 'Çıkart',
            addAllButtonText: 'Tümünü Ekle',
            removeAllButtonText: 'Tümünü Çıkart'
        });
    };

    return {
        // public functions
        init: function () {
            userClaimList();
        },
    };
}();

window.addEventListener('load', function () {
    ClaimToUserSelectList.init();
});
