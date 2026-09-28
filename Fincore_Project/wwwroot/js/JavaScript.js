
$(document).ready(function () {
    $("#btnAdd").click(function () {
        $("#AddModal").modal("show");
    });

    $("#sbtn").click(function (e) {

        var obj = $("#roleform").serialize();
        $.ajax({
            url:'/Role/AddRole',
            type:'POST',
            data: obj,
            dataType: 'json',
            success: function (res) {
                alert(res);
                $("#AddModal").modal("hide");


            },
            error: function () {
                alert('Cannot Add');
            }


        });
    });

     $(document).on("click", ".editbtn", function () {

        var id = $(this).data("id");

        $.ajax({
            url: '/Role/GetRole',
            type: 'GET',
            data: { id: id },

            success: function (res) {

                if (res) {

                   $("#EditRoleId").val(res.roleId);
$("#EditRoleName").val(res.roleName);
$("#EditDescription").val(res.description);
$("#EditIsActive").val(res.isActive.toString());

                    $("#EditModal").modal("show");
                }
                else {
                    alert("Role Not Found");
                }
            },

            error: function () {
                alert("Cannot Get Role");
            }
        });

    });


    $("#ubtn").click(function(e){
        var obj = $("#editRoleForm").serialize();

         e.preventDefault();

         $.ajax({
        url: '/Role/EditRole',
        type: 'POST',
        data: obj,
          dataType: 'json',

         success: function (res){
             alert(res);
         },
         error:function(){
             alert("Cannot Update");
         },

        });
    });

    $("#editClose").click(function () {
        $("#EditModal").modal("hide");
    });

    $(document).on("click", ".delbtn", function () {

    var id = $(this).data("id");

    if (confirm("Are you sure you want to delete this role?")) {

        $.ajax({
            url: '/Role/DelRole',
            type: 'POST',
            data: { id: id },

            success: function (res) {

                alert(res);

                location.reload();
            },

            error: function () {

                alert("Cannot Delete Role");
            }
        });
    }
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