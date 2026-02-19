"use strict";
var Page = function () {

    var initPage = function () {
        $("#Icon").select2();
        $("ColorClass").select2();

        // begin first table


    };

    $("#Icon").change(function () {
        $("#iconview").removeAttr('class');
        $("#iconview").attr('class', $("#Icon").val());
    });

    return {

        //main function to initiate the module
        init: function () {
            initPage();
        }

    };

}();

jQuery(document).ready(function () {
    Page.init();
});
