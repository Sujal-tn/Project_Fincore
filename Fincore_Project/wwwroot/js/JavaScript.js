
$(document).ready(function () {
    $("#btnAdd").click(function () {
        $("#AddModal").modal("show");
    });



//Account Master Start

    $("#openmodal").click(function () {
        $("#AddModal").modal("show");
    });


    //Add Account

$("#addaccount").click(function (e) {

    e.preventDefault();

    var obj = $("#formadd").serialize();


    $.ajax({
        url: '/AccountMaster/AddAccount',
        type: 'POST',
        data: obj,
        dataType: 'json',
        success: function (res) {
            alert(res.message);
            $("#AddModal").modal('hide');
        },
        error: function () {
            alert("error");
        }
    });
    AccountMasterFetch();
});


//Update Account

    $("#updateaccount").click(function(e) {

        e.preventDefault();

        var obj = $("#formupdate").serialize();

        $.ajax({
            url: 'AccountMaster/Update',
            type: 'POST',
            dataType: 'json',
            data: obj,
            success: function (res) {
                alert(res.message);
                $("#UpdateModal").modal("hide");
                AccountMasterFetch();
            },
            error: function () {
                alert("Error");
            }
        });
    });

    AccountMasterFetch();

});


//Fetch All Account Data
function AccountMasterFetch() {

    $.ajax({

        url: '/AccountMaster/GetAccounts',
        type: 'GET',
        dataType: 'json',
        success: function (res) {
            var obj = '';
            $.each(res, function (row, item) {
                obj += "<tr>";
                obj += "<td>" + item.accountId + "</td>";
                obj += "<td>" + item.accountCode + "</td>";
                obj += "<td>" + item.accountName + "</td>";
                obj += "<td>" + item.accountType + "</td>";
                if (item.isActive) {
                    obj += "<td><span class='badge bg-success'>Active</span></td>";
                }
                else {
                    obj += "<td><span class='badge bg-danger'>Inactive</span></td>";
                }
                obj += "<td>";

                obj += "<button class='btn btn-warning btn-sm' onclick='EditAccount(" + item.accountId + ")'>Edit</button> ";
                obj += "<button class='btn btn-danger btn-sm' onclick='DeleteAccount("+ item.accountId +")'>Delete</button>"; 

                obj += "</td>";
                obj += "</tr>";

            });
            $("#accountdata").html(obj);
        },
        error: function () {
            alert("Error");
        }

    });

}

//Edit Account
function EditAccount(id) {

    $.ajax({
        url: '/AccountMaster/Edit?id=' + id,
        type: 'GET',
        dataType: 'json',

        success: function (res) {

            $("#UpdateAccountId").val(res.accountId);
            $("#UpdateAccountName").val(res.accountName);
            $("#UpdateAccountType").val(res.accountType);
            $("#UpdateIsActive").val(res.isActive);

            $("#UpdateModal").modal("show");
        },
        error: function () {
            alert("Error");
        }
    });
}

//Delete Account

function DeleteAccount(id)
{
    var result = confirm("Are you sure you want to delete this account ?");

    if (result == false) {
        return;
    }

    $.ajax({
        url: 'AccountMaster/Delete?id=' + id,
        type: 'POST',
        dataType: 'json',
        success: function (res) {
            alert(res.message);
            AccountMasterFetch();
        },
        error: function () {
            alert("Error");
        }
    });
}


//Account Master End