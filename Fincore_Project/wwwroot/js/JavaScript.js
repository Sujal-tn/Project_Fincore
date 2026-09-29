
$(document).ready(function () {
    $("#btnAdd").click(function () {
        $("#AddModal").modal("show");
    });

   
});


$(document).ready(function() {

    $("#btn").click(function () {

        $("#categoryform")[0].reset();

        $("#VendorCategoryId").val("");

        $("#categorySavebtn").val("Save");

        $("#exampleModal").modal("show");
    });


   
    $("#closemodal").click(function () {
        $("#exampleModal").modal("hide");
    });

    $("#categoryform").submit(function(e) {

        e.preventDefault();   

        var obj = $(this).serialize();
         var categoryId = $("#VendorCategoryId").val();

        console.log(obj);

        var url = categoryId == ""
            ? "/VendorCategory/AddVendorCategory"
            : "/VendorCategory/UpdateVendorCategory";

        $.ajax({
            url: url,
            type: 'POST',
            data: obj,
            dataType: 'json',

            success: function(response) {
                if (categoryId == "") {
                    alert("Category added successfully!");
                }
                else {
                    alert("Category updated successfully!");
                }

                $("#exampleModal").modal('hide');
                $("#categoryform")[0].reset();

                 location.reload();
               
            },

            error: function(xhr) {
                console.log(xhr);
                alert("Error");
            }
        });

    });

     $(".editCategoryBtn").click(function () {

        var id = $(this).data("id");

        $.ajax({

            url: "/VendorCategory/getVendorCategoryById/" + id,

            type: "GET",

            success: function (response) {

                $("#VendorCategoryId")
                    .val(response.vendorCategoryId);

                $("input[name='CategoryName']")
                    .val(response.categoryName);

                $("input[name='Description']")
                    .val(response.description);

                $("select[name='IsActive']")
                    .val(response.isActive);

                $("#categorySavebtn")
                    .val("Update");

                $("#exampleModal").modal("show");
            },

            error: function (xhr) {

                console.log(xhr);

                alert("Error while loading category");
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

        e.preventDefault();   

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

        e.preventDefault(); 

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


$(document).ready(function() {

     $("#btn").click(function () {

        $("#vendorform")[0].reset();
        $("#VendorId").val("");
        $("#savebtn").val("Save");

        $("#exampleModal").modal("show");
    });

    $("#closemodal").click(function () {
        $("#exampleModal").modal("hide");
    });

    $("#vendorform").submit(function(e) {

        e.preventDefault();   

        var obj = $(this).serialize();
         var vendorId = $("#VendorId").val();

        console.log(obj);

        var url = vendorId == ""
        ? "/VendorCategory/AddVendor"
        : "/VendorCategory/EditVendor";

        $.ajax({
            url: url,
            type: 'POST',
            data: obj,
            dataType: 'json',

            success: function(response) {
                 if (vendorId == "") {
        alert("Vendor added successfully!");
    } else {
        alert("Vendor updated successfully!");
    }

                $("#exampleModal").modal('hide');
                $("#vendorform")[0].reset();

                 location.reload();

            },

            error: function(xhr) {
                console.log(xhr);
                alert("Error");
            }
        });

    });

    $(".editBtn").click(function () {

    var id = $(this).data("id");

    $.ajax({
        url: "/VendorCategory/getVendorById/" + id,
        type: "GET",

        success: function (response) {

            $("#VendorId").val(response.vendorId);
            $("input[name='VendorCode']").val(response.vendorCode);
            $("select[name='VendorCategoryId']").val(response.vendorCategoryId);
            $("select[name='CompanyId']").val(response.companyId);
            $("input[name='BankAccount']").val(response.bankAccount);
            $("input[name='PAN']").val(response.pan);
            $("select[name='IsActive']").val(response.isActive);

            $("#savebtn").val("Update");

            $("#exampleModal").modal("show");
        }
    });

    });


});


$(document).ready(function() {

    // Open Vendor Document modal
    $("#btnAddDocument").click(function() {

        $("#UploadDocumentform")[0].reset();

        $("#exampleModal").modal("show");
    });


    // Close Vendor Document modal
    $("#closeModal").click(function() {

        $("#documentModal").modal("hide");
    });


    // Submit Vendor Document form
    $("#UploadDocumentform").submit(function(e) {

        e.preventDefault();

        var formData = new FormData(this);

        $.ajax({
            url: "/VendorCategory/AddDocument",
            type: "POST",
            data: formData,
            processData: false,
            contentType: false,
            dataType: "json",

            success: function(response) {

                alert("Document uploaded successfully!");

                $("#exampleModal").modal("hide");

                $("#UploadDocumentform")[0].reset();

                location.reload();
            },

            error: function(xhr) {

                console.log(xhr);
                alert("Error while uploading document");
            }
        });

    });

});



