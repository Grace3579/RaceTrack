/*

    this.Save = function () {


        var data = {
            "TypeOfVehicle": $('#TypeOfVehicle').val(),
            "Make": $('#Make').val(),
            "Model": $('#Model').val(),
            "Color": $('#Color').val(),
            "Price": $('#Price').val(),
        };

        var url = '';
        if ($('#TypeOfVehicle').val() == "Truck")
            url = '/Home/AddTruckData/';
        else
            url = '/Home/AddCarData/';
        console.debug(data);
        //console.debug(JSON.stringify(data));

        $.ajax({
            type: "POST",
            url: url,
            data: JSON.stringify(data),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {

                if (data.OperationSucceeded) {


                    alert('Car saved');

                } else {
                    alert('some error occurred while saving Car');                   
                }

            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert('Unable to process data. some error occurred while saving Car');  
            },
            complete: function (data) {
                
            }
        });
    };

function GetAllVehicles() {
    $.ajax({
        type: "GET",
        url: '/Home/GetVehiclesData/',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {

            if (data.OperationSucceeded) {

                //Show in datatable vehicles fetched

            } else {
                alert('No vehicle exists');
            }

        }
    });
}
*/
$('#Type').change(function () {

    if ($(this).val() == 'Truck') {
        $('#TruckType').show();
        $('#CarType').hide();
    }
    else {
        $('#TruckType').hide();
        $('#CarType').show();
    }
    
});

$(document).ready(function () {
    $('#TruckType').hide();
    $('#CarType').hide();
    $('#divRaceTrackTable').DataTable();
});