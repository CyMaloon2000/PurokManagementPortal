$(function () {

    PhilhealthDT = $("#PhilhealthDT").DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": "/PhilHealthSource/GetListJson/",
            "type": "POST"
        },
        "columns": [
            {
                "data": "philHealthSourceName",
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
                "data": 'philHealthSourceId',
                "className": "text-center",
                "render": function (PhilHealthSourceId) {
                    return ` <div class="btn-group btn-group-sm">
                                <button class="btn btn-sm btn-primary px-4" data-url="/PhilHealthSource/Edit/${PhilHealthSourceId}" data-id="editPhilHealthSource" data-dialog-title="Edit PhilHealth Source" data-dialog-width="modal-lg" data-process-button="Update" onclick="loadAndShowModal($(this))"><i class="fas fa-pen mr-2 ml-0"></i>Update</button>
                                <button class="btn btn-sm btn-danger px-4" data-url="/PhilHealthSource/Delete/${PhilHealthSourceId}" data-id="deletePhilHealthSource" data-dialog-title="Delete PhilHealth Source" data-dialog-width="modal-lg" data-process-button="Delete" onclick="loadAndShowModal($(this))"><i class="fas fa-trash mr-2 ml-0"></i>Delete</button>
                            </div>`;
                },
                width: "30%"
            },

        ]
    });
});