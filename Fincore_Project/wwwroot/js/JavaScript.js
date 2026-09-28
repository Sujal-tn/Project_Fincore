
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