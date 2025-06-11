$(function () {

    ReligionDT = $("#ReligionDT").DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": "/Religion/GetListJson/",
            "type": "POST"
        },
        "responsive": true,
        "columns": [
            {
                "data": "religionName",
                "className": "text-center",
                width: "50"
            },
            {
                "data": 'isActive',
                "className": "text-center",
                "render": function (IsActive) {
                    if (IsActive) {
                        return '<a href="#" class="badge badge-primary">Active</a>';
                    }
                    else {
                        return '<a href="#" class="badge badge-danger">Inactive</a>';
                    }
                },
                width: "20%"
            },
            {
                "data": 'religionId',
                "className": "text-center",
                "render": function (ReligionId) {
                    return ` <div class="btn-group btn-group-sm">
                                <button class="btn btn-sm btn-primary px-4" data-url="/Religion/Edit/${ReligionId}" data-id="editGender" data-dialog-title="Edit Gender" data-dialog-width="modal-lg" data-process-button="Update" onclick="loadAndShowModal($(this))"><i class="fas fa-pen mr-2 ml-0"></i>Update</button>
                                <button class="btn btn-sm btn-danger px-4" data-url="/Religion/Delete/${ReligionId}" data-id="deleteGender" data-dialog-title="Delete Gender" data-dialog-width="modal-lg" data-process-button="Delete" onclick="loadAndShowModal($(this))"><i class="fas fa-trash mr-2 ml-0"></i>Delete</button>
                            </div>`;
                },
                width: "30%"
            },

        ]
    });
});