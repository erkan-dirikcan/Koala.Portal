"use strict";
var SupportTable = function () {

    var initSupportList = function () {
        $('#support_open_support_table').dataTable({
            scrollY: 500,
            deferRender: true,
            scroller: true
        });
        $('#support_department_table').dataTable({
            scrollY: 500,
            deferRender: true,
            scroller: true
        });
        $('#support_answer_waiting_table').dataTable({
            scrollY: 500,
            deferRender: true,
            scroller: true
        });
        $('#support_WebUser_table').dataTable({
            scrollY: 500,
            deferRender: true,
            scroller: true
        });
        $('#support_firm_open_support_table').dataTable({
            scrollY: 500,
            deferRender: true,
            scroller: true
        });

    };

    return {


        initSupportTable: function () {
            initSupportList();

        }

    };

}();

jQuery(document).ready(function () {
    SupportTable.initSupportTable();
});
