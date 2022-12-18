$("#modal-shadow").click((event) => {
    if (event.target.id === "modal-shadow" || event.target.id ==="close-X") {
        $("#modal-shadow").removeClass("d-block");
    }
});

$("#Create-modal").click(function () {
    console.log("Click Modla");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/PageGroups/Create", (res) => {
        $("#modal-title").html("Create Group");
        $("#modal-body").html(res);
    });
});

function EditGroup(id) {
    console.log("Click Edit");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/PageGroups/Edit/" + id, (res) => {
        $("#modal-title").html("Edit Group");
        $("#modal-body").html(res);
    });
}
function DetailsGroup(id) {
    console.log("Click Details");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/PageGroups/Details/" + id, (res) => {
        $("#modal-title").html("Details Group");
        $("#modal-body").html(res);
    });
}
function DeleteGroup(id) {
    console.log("Click Delete");
    $("#modal-shadow").addClass("d-block");
    $.get("/Admin/PageGroups/Delete/" + id, (res) => {
        $("#modal-title").html("Delete Group");
        $("#modal-body").html(res);
    });
}
