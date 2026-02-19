"use strict";
var UserTable = function () {

    var initTable = function () {
       
        var table = $('#ProjectTable');

        // begin first table
        table.DataTable({
            responsive: true,
            ordering: false,
            columnDefs: [

            ]
        });

    };

    return {


        init: function () {
            initTable();
        }

    };

}();

jQuery(document).ready(function () {
    UserTable.init();
});
