function RaceTrackDatatable(opt, data) {
    var self = this;
    window.RaceTrackDatatable = self;

    data = data || {};

    opt = $.extend(true, {}, {
        tableSelector: null,
        containerSelector: null,
        customizePdfCallback: function (doc) { },
        preDrawCallback: null,
        drawCallback: null,
        loadCallback: null,
        createdRow: null
    }, opt);

    // Parameters for search 

    self.TypeOfVehicle = ko.observable();
    self.Make = ko.observable();
    self.Model = ko.observable();
    self.Color = ko.observable(0);
    self.Price = ko.observable(0);
    self.Speed = ko.observable(0);
    self.TowStrap = ko.observable(false);
    self.MaxLift = ko.observable(false);
    self.MaxTireWear = ko.observable(false);

    // Non-observable Properties 
    self.customizePdfCallback = opt.customizePdfCallback;
    self.preDrawCallback = opt.preDrawCallback;
    self.drawCallback = opt.drawCallback;
    self.loadCallback = opt.loadCallback;
    self.createdRow = opt.createdRow;

    // Private Properties 
    self._datatable = null;
    self._tableSelector = opt.tableSelector;
    self._containerSelector = opt.containerSelector;

    // functions
    self.LoadDatatable = function () {
        if (self._datatable == null)
            self.InitDatatable();
        else
            self._datatable.ajax.reload(self.loadCallback);
    };


    self.InitDatatable = function () {

        var opt = {
            ajax: {
                url: '/Home/GetVehiclesData/',
                type: 'GET',
                dataType: 'json'
            },
            initComplete: self.loadCallback,
            pageLength: 25,
            lengthMenu: [[25, 50, -1], [25, 50, "All"]],
            preDrawCallback: self.preDrawCallback,
            drawCallback: self.OnDrawDatatable,
            columns: [],


        };
        opt.columns = [
            {
                title: '',
                data: 'TypeOfVehicle',
                sortable: true,
            },
            {
                title: 'Make',
                className: '',
                sortable: true,
            }];



        opt.columns.push(...[
            {
                data: 'Model',
                title: 'Model'
            },
            {
                data: 'Color',
                title: 'Color'
            },
            {
                data: 'Price',
                title: 'Price'
            },
            {
                data: 'Speed',
                title: 'Speed'
            },
            {
                data: 'TowStrap',
                title: 'Tow Strap',
            },
            {
                data: 'MaxLift',
                title: 'Max Lift',
            },
            {
                data: 'MaxTireWear',
                title: 'Max Tire Wear',
            }
        ]);

        opt.order = [[1, 'asc']];

        opt.ajax.data = function (data, settings) {
            data.TypeOfVehicle = self.TypeOfVehicle();
            data.Make = self.Make();
            data.Model = self.Model();
            data.Color = self.Color();
            data.Price = self.Price();
            data.Speed = self.Speed();
            data.TowStrap = self.TowStrap();
            data.MaxLift = self.MaxLift();
            data.MaxTireWear = self.MaxTireWear();
        };

        opt.createdRow = function (row, data, dataIndex) {
            self.createdRow(row, data, dataIndex);

            if (dataIndex % 2 == 1) {
                $(row).addClass('odd-row');
            }
        };

        self._datatable = $(self._tableSelector).DataTable(opt);
    };

};