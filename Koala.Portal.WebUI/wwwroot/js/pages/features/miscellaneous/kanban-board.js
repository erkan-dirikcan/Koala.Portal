"use strict";



var KTKanbanBoardDemo = function() {
    var _demo1 = function() {
        var kanban = new jKanban({
            element: '#ProjeKanban',
            gutter: '0',
            widthBoard: '250px',
            boards: [{
                    'id': '_inprocess',
                    'title': 'Ýþlemler',
                    'item': [{
                            'title': '<span class="font-weight-bold">Retim Adýmlarý Planlamasý</span>'
                        },
                        {
                            'title': '<span class="font-weight-bold">E-Devlet Entegrasyonu</span>'
                        },
                        {
                            'title': '<span class="font-weight-bold">Fatura Tasarýmlarýnýn Yapýlmasý</span>'
                        },
                        {
                            'title': '<span class="font-weight-bold">Eðitim</span>'
                        }
                    ]
                }, {
                    'id': '_working',
                    'title': 'Yapýlýyor',
                    'item': [{
                            'title': '<span class="font-weight-bold">Eski ERP Datalarýnýn Taþýnmasý</span>'
                        },
                        {
                            'title': '<span class="font-weight-bold">Tiger Firma ve Kullanýcý Tanýmlarý</span>'
                        }
                    ]
                }, {
                    'id': '_done',
                    'title': 'Tamamlandý',
                    'item': [{
                            'title': '<span class="font-weight-bold">Logo Tiger Lisans Ýþlemleri</span>'
                        },
                        {
                            'title': '<span class="font-weight-bold">Logo Tiger Kurulumu</span>'
                        }
                    ]
                }
            ]
        });
    }


    // Public functions
    return {
        init: function() {
            _demo1();
         
        }
    };
}();

jQuery(document).ready(function() {
    KTKanbanBoardDemo.init();
});
