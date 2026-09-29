
$(document).ready(function () {
    $("#btnAdd").click(function () {
        $("#AddModal").modal("show");
    });

   
});


$(document).ready(function() {

    $('#btn').click(function() {
        $("#exampleModal").modal('show');
    });

    $('#closemodal').click(function() {
        $("#exampleModal").modal('hide');
    });

    $("#categoryform").submit(function(e) {

        e.preventDefault();   // IMPORTANT

        var obj = $(this).serialize();

        console.log(obj);

        $.ajax({
            url: '/VendorCategory/AddVendorCategory',
            type: 'POST',
            data: obj,
            dataType: 'json',

            success: function(response) {
                alert("Category added successfully!");

                $("#exampleModal").modal('hide');
                $("#categoryform")[0].reset();
               
            },

            error: function(xhr) {
                console.log(xhr);
                alert("Error");
            }
        });

    });

    
});

$(document).ready(function() {

    $('#btn').click(function() {
        $("#exampleModal").modal('show');
    });

    $('#closemodal').click(function() {
        $("#exampleModal").modal('hide');
    });

    $("#documentform").submit(function(e) {

        e.preventDefault();   // IMPORTANT

        var obj = $(this).serialize();

        console.log(obj);

        $.ajax({
            url: '/VendorCategory/AddDocumentType',
            type: 'POST',
            data: obj,
            dataType: 'json',

            success: function(response) {
                alert("document type added successfully!");

                $("#exampleModal").modal('hide');
                $("#documentform")[0].reset();

            },

            error: function(xhr) {
                console.log(xhr);
                alert("Error");
            }
        });

    });


});


$(document).ready(function() {

    $('#btn').click(function() {
        $("#exampleModal").modal('show');
    });

    $('#closemodal').click(function() {
        $("#exampleModal").modal('hide');
    });

    $("#PRform").submit(function(e) {

        e.preventDefault();   // IMPORTANT

        var obj = $(this).serialize();

        console.log(obj);

        $.ajax({
            url: '/PR/AddPR',
            type: 'POST',
            data: obj,
            dataType: 'json',

            success: function(response) {
                alert("document type added successfully!");

                $("#exampleModal").modal('hide');
                $("#PRform")[0].reset();

            },

            error: function(xhr) {
                console.log(xhr);
                alert("Error");
            }
        });

    });

});

//Asset
$(document).ready(function () {

    $("#openAssetModal").click(function () {
        $("#assetform")[0].reset();
        $("#assetModal").modal("show");
    });

    $("#closeAssetModal").click(function () {
        $("#assetModal").modal("hide");
    });

    $("#saveAssetBtn").click(function () {

        var obj = $("#assetform").serialize();

        $.ajax({
            url: '/Asset/AddAsset',
            type: 'POST',
            data: obj,
            dataType: 'json',
            success: function (res) {
                alert(res.message);
                $('#assetModal').modal('hide');
                AssetList();
            },
            error: function () {
                alert('error');
            }
        });
    });

    if ($('#assetdata').length) {
        AssetList();
    }

});

function AssetList() {
    $.ajax({
        url: '/Asset/FetchAll',
        type: 'GET',
        dataType: 'json',
        success: function (res) {
            var obj = '';
            $.each(res, function (i, item) {
                obj += "<tr>";
                obj += "<td>" + item.assetId + "</td>";
                obj += "<td>" + item.assetCode + "</td>";
                obj += "<td>" + item.assetName + "</td>";
                obj += "<td>" + item.vendorId + "</td>";
                obj += "<td>" + item.departmentId + "</td>";
                obj += "<td>" + item.status + "</td>";
                obj += "</tr>";
            });
            $('#assetdata').html(obj);
        },
        error: function () {
            console.log("Error");
        }
    });
}


//Asset history
$(document).ready(function() {

    $("#openHistoryModal").click(function() {
        $("#historyform")[0].reset();
        $("#historyModal").modal("show");
    });

    $("#closeHistoryModal").click(function() {
        $("#historyModal").modal("hide");
    });

    $("#saveHistoryBtn").click(function() {

        var obj = $("#historyform").serialize();

        $.ajax({
            url: '/AssetHistory/AddHistory',
            type: 'POST',
            data: obj,
            dataType: 'json',
            success: function(res) {
                alert(res.message);
                $('#historyModal').modal('hide');
                HistoryList();
            },
            error: function() {
                alert('error');
            }
        });
    });

    if ($('#historydata').length) {
        HistoryList();
    }

});

function HistoryList() {
    $.ajax({
        url: '/AssetHistory/FetchHistory',
        type: 'GET',
        dataType: 'json',
        success: function(res) {
            var obj = '';
            $.each(res, function(i, item) {
                obj += "<tr>";
                obj += "<td>" + item.assetHistoryId + "</td>";
                obj += "<td>" + item.assetId + "</td>";
                obj += "<td>" + item.action + "</td>";
                obj += "<td>" + (item.description || '') + "</td>";
                obj += "<td>" + (item.previousStatus || '') + "</td>";
                obj += "<td>" + (item.newStatus || '') + "</td>";
                obj += "<td>" + (item.performedBy || '') + "</td>";
                obj += "<td>" + item.actionDate + "</td>";
                obj += "</tr>";
            });
            $('#historydata').html(obj);
        }
    });
}