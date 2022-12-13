$("#modal-shadow").click((event) => {
    if (event.target.id === "modal-shadow" || event.target.id ==="close-X") {
        $("#modal-shadow").removeClass("d-block");
    }
});

$("#Personal").click(() => {
    $("#show-data").addClass("d-none");
});

$("#Group").click((event) => {
    event.preventDefault();
    $("#show-data").removeClass("d-none");
    $("#tHead").html("<tr><th>Groups</th><th>Remotes</th></tr>");

});

$("#Page").click(() => {
    event.preventDefault();
    $("#show-data").removeClass("d-none");
    $("#tHead").html("<tr><th>Groups</th><th>Title</th><th>Description</th><th>Text</th><th>Visits</th><th>CreateTime</th><th>Remotes</th></tr>");
});

$("#Comment").click(() => {
    event.preventDefault();
    $("#show-data").removeClass("d-none");
    $("#tHead").html("<tr><th>Groups</th><th>Name</th><th>Email</th><th>Comment</th><th>Remotes</th></tr>");
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
