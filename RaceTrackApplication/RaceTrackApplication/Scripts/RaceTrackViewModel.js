function RaceTrackViewModel(rawModel) {
    var self = this;
    data = rawModel || {};



    self.VehicleId = ko.observable();
    self.TypeOfVehicle = ko.observable();
    self.Make = ko.observable();
    self.Model = ko.observable();
    self.Color = ko.observable(0);
    self.Price = ko.observable(0);
    self.Speed = ko.observable(0);
    self.TowStrap = ko.observable(false);
    self.MaxLift = ko.observable(false);
    self.MaxTireWear = ko.observable(false);

    self.context = null;

    self.SaveRaceTrackVehicle = function () {
        var data = {};
        //data.ID = self.VehicleID();
        data.TypeOfVehicle = self.TypeOfVehicle();
        data.Make = self.Make();
        data.Model = self.Model();
        data.Color = self.Color();
        data.Price = self.Price();
        data.Speed = self.Speed();
        data.TowStrap = self.TowStrap();
        data.MaxLift = self.MaxLift();
        data.MaxTireWear = self.MaxTireWear();

        var url = '';
        if ($('#TypeOfVehicle').val() == "Truck")
            url = '/Home/AddTruckData/';
        else
            url = '/Home/AddCarData/';

        $.ajax({
            type: "POST",
            url: url,
            contentType: 'application/json',
            dataType: 'json',
            data: JSON.stringify(data, null, 4),
            success: function (data) {
                if (data.OperationSucceeded) {
                    self.DoUpdate();
                    ShowSuccess(data.Message);
                } else {
                    self.ErrorCallBack(data);
                }
            },
            error: self.ErrorCallBack,
            complete: self.ModalLoading
        });
    };

    setTimeout(function () {
        self.DoUpdate();
    }, 2000);

    self.AddVehicleToTrack = function (vehicle) {
        var data = {};
        data.ID = vehicle.VehicleID();

        if (vehicle.TowStrap())
            data.IsTowStrapOn = true;
        else
            data.IsTowStrapOn = false;

        if (vehicle.TypeOfVehicle == 'Car' && vehicle.MaxLift())
            data.IfMaxLifted = true;
        else
            data.IfMaxLifted = false;

        if (vehicle.TypeOfVehicle == 'Truck' && vehicle.MaxTireWear())
            data.IfMaxTireWear = true;
        else
            data.IfMaxTireWear = false;
        if (data.IsTowStrapOn() && (data.IfMaxLifted() || data.IfMaxTireWear)) {


            $.ajax({
                type: "POST",
                url: '/Home/AddVehicleToTrack',
                contentType: 'application/json',
                dataType: 'json',
                data: JSON.stringify(data, null, 4),
                success: function (data) {
                    if (data.OperationSucceeded) {
                        self.DoUpdate();
                        ShowSuccess(data.Message);
                    } else {
                        self.ErrorCallBack(data);
                    }
                },
                error: self.ErrorCallBack,
                complete: self.ModalLoading
            });
        }
        else {
            alert('Vehicle does not meet inspection criteria');
        }
    };


    self.DoUpdate = function () {

        //self.IsLoading(true);

        self.datatable.TypeOfVehicle(self.TypeOfVehicle());
        self.datatable.Make(self.Make());
        self.datatable.Model(self.Model());
        self.datatable.Color(self.Color());
        self.datatable.Price(self.Price());
        self.datatable.Speed(self.Speed());
        self.datatable.TowStrap(self.TowStrap());
        self.datatable.MaxLift(self.MaxLift());
        self.datatable.MaxTireWear(self.MaxTireWear());

        self.datatable.LoadDatatable();

    };

    self.datatable = new RaceTrackDatatable({
        tableSelector: '#divRaceTrackTable',
        containerSelector: '#divRaceTrackTable',
        loadCallback: function () {
            self.IsLoading(false);
        },
        drawCallback: function () {
            self.IsLoading(false);
        },
        createdRow: function (row, data, dataIndex) {
            
        }
    }, data);


    self.InitView = function () {
        try {

                self.CleanFilters();
                self.DoUpdate();

        } catch (ex) {
            console.warn(ex);
        }

    };

    self.CleanFilters = function () {
        
        self.TypeOfVehicle('0');
        self.Make('');
        self.Model('');
        self.Color(0);
        self.Price(0);
        self.Speed(0);
        self.TowStrap(false);
        self.MaxLift(false);
        self.MaxTireWear(false);
    };

}