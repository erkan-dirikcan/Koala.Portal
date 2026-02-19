"use strict";

var KTCalendarBasic = function () {

    return {
        //main function to initiate the module
        init: function () {



            var todayDate = moment().startOf('day');
            var events = [];
            $.get("/Agenda/GetAgenda").done(function (result) {
                if (result.isSuccess) {
                    evn = {
                        id: result.Data[i].Id,
                        title: result.Data[i].Title,
                        start: sd,
                        end: ed,
                        allDay: false,
                        className: 'fc-event-default',
                        icon: 'fa fa-repeat',
                        backgroundColor: result.Data[i].BackColor,
                        borderColor: result.Data[ i ].FontColor,
                        textColor: result.Data[ i ].FontColor,
                        editable: edt,
                        startEditable: edt,
                        durationEditable: edt,
                        resourceEditable: edt,
                        contentHeight: 32,
                        extendedProps: {
                            eventCode: result.Data[ i ].EventCode,
                            agendaType: result.Data[ i ].AgendaType,
                            agendaTypeId: result.Data[ i ].AgendaTypeId,
                            firm: result.Data[ i ].Firm,
                            firmId: result.Data[ i ].FirmId,
                            location: result.Data[ i ].Location,
                            project: result.Data[ i ].Project,
                            projectId: result.Data[ i ].ProjectId,
                            ticket: result.Data[ i ].Ticket,
                            ticketId: result.Data[ i ].TicketId,
                            description: result.Data[ i ].Description,
                            noteForCustomer: result.Data[ i ].NoteForCustomer,
                            isCanceled: result.Data[ i ].IsCanceled,
                            isComplated: result.Data[ i ].IsComplated,
                            agendaFixtures: [],
                            firmOfficials: [],
                            users: []


                        }
                    }
                    events.push(evn);
                }
                else {

                }
            });
            //var YM = todayDate.format('YYYY-MM');
            //var YESTERDAY = todayDate.clone().subtract(1, 'day').format('YYYY-MM-DD');
            var TODAY = todayDate.format('YYYY-MM-DD');
            //var TOMORROW = todayDate.clone().add(1, 'day').format('YYYY-MM-DD');

            var calendarEl = document.getElementById('kt_calendar');


            var calendar = new FullCalendar.Calendar(calendarEl, {
                // plugins: [  'interaction', 'dayGrid', 'timeGrid', 'list' ],
                plugins: ['interaction', 'dayGrid',  'timeGrid', 'list', 'momentTimezone' ],
                timeZone: 'local',
                nowIndicator: true,
                //now: date.toJSON(),
                isRTL: KTUtil.isRTL(),

                header: {
                    left: 'prev,today,next  CreateEvent',
                    center: 'title',
                    right: 'dayGridMonth,timeGridWeek,timeGridDay'
                },
                buttonText: {
                    today: 'Bugün', //(Today)Bugün butonu yazısı
                    //listMonth: 'Aylık Ajanda',
                    //listWeek: 'Haftalık Ajanda'
                },
                themeSystem: 'bootstrap', //Tema
                defaultView: 'timeGridWeek', //Varsayılan Görünüm
                weekends: true, //Hafta Sonları Gösterilmesi
                //showNonCurrentDates:false,//Bulunduğum ay ha
                views: {
                    dayGridMonth: { buttonText: 'Aylık' },
                    timeGridWeek: { buttonText: 'Haftalık' },
                    timeGridDay: { buttonText: 'Günlük' }
                },
                
                editable: true,
                eventStartEditable: true,
                eventDurationEditable: true,
                //height: 800,//Header Footer hariç yükseklik

                contentHeight: 800,//Header Footer dahil yükseklik
                aspectRatio: 3,  //Kolon yükseklikleri Küçüldükçe Büyür, Büyüdükçe küçülür
                allDaySlot: false, //Tümgün İptal
                firstDay: 1, //İlk gün = 0 Pazar
                //now: TODAY + 'T09:25:00', // just for demo
                titleFormat: {
                    year: 'numeric',
                    month: 'long',
                    day: 'numeric'
                }, //Başlık farmatları
                slotDuration: '00:30:00', //Time grid görünümünde Zaman aralıklarını belirler
                slotLabelInterval: '00:30:00', //Time grid görünümünde satır başlıklarının sıklığını belirler
                slotLabelFormat: { hour: '2-digit', minute: '2-digit' }, //Time grid görünümünde satır başlıklarının görüntü formatını belirler
                eventOrder: 'start', //Eventları sıralama için kullanılır.
                titleRangeSeparator: ' - ', //Başlık ayırıcısı
                columnHeaderFormat: {
                    weekday: 'long',
                    //year: 'numeric',
                    month: 'long',
                    day: 'numeric'
                    // ,meridiem:'short'//İngilizce takvimde AM ve PM özelliğini aktif eder
                    //weekday: 'numeric'
                }, //Kolon başlık farmatı
                customButtons: {
                    CreateEvent: {
                        text: "Ekle",
                        click: function () {
                            $.get("/Agenda/GetNextEventId").done(function (result) {
                                if (result.IsSuccess) {
                                    $("#createEventHeader").html("Etkinlik Ekle - " + result.Data);
                                    $("#addNumber").val(result.Data);
                                    $("#CreateEventModal").modal();
                                } else {
                                    ErrorMessage("Hata", "", "danger");
                                }
                            });
                        }
                    }
                    //RemoveEvent: {
                    //    text: "Çıkar",
                    //    click: function () {
                    //        var event = calendar.getEventById(15);
                    //        event.remove();
                    //        //$("#CreateEventModal").modal();
                    //    }
                    //}
                }, //Custom buton özellikleri

                displayEventTime: true, //Event Başlangıç zamanını gösterir
                displayEventEnd: true, //Event Bitiş Zamanını gösterir
                eventTimeFormat: {
                    hour: '2-digit',
                    minute: '2-digit'
                    // second : '',
                },
                eventDragMinDistance: 10, //Event Süre Değiştirme Tepki mesafesi
                eventDragRevertDuration: 35000, //Event Hatalı alana çekilince geri düşüş süresi
                dragScroll: true, //Eventı kaydırırken sucrol otomatik kaysın mı?
                snapDuration: 10, //Kaydırma işleminin kaç dakika farkla yapılacağını belirler
                locale: "tr", //Takvim Dili


                defaultView: 'dayGridMonth',
                defaultDate: TODAY,

                
                eventLimit: true, // allow "more" link when too many events
                navLinks: true,
                events: [

                ],

                eventRender: function (info) {
                    var element = $(info.el);

                    if (info.event.extendedProps && info.event.extendedProps.description) {
                        if (element.hasClass('fc-day-grid-event')) {
                            element.data('content', info.event.extendedProps.description);
                            element.data('placement', 'top');
                            KTApp.initPopover(element);
                        } else if (element.hasClass('fc-time-grid-event')) {
                            element.find('.fc-title').append('<div class="fc-description">' + info.event.extendedProps.description + '</div>');
                        } else if (element.find('.fc-list-item-title').lenght !== 0) {
                            element.find('.fc-list-item-title').append('<div class="fc-description">' + info.event.extendedProps.description + '</div>');
                        }
                    }
                }
            });

            calendar.render();
        }
    };
}();

jQuery(document).ready(function () {
    KTCalendarBasic.init();
});
