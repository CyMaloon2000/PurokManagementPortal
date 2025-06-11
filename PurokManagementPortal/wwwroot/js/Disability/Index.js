$(function () {


    DisabilityDT = $("#DisabilityDT").DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": "/Disability/GetListJson/",
            "type": "POST"
        },
        "columns": [
            {
                "data": "disabilityName",
                "className": "text-center",
                width: "50"
            },
            {
                "data": "legendRemarks",
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
                "data": 'disabilityId',
                "className": "text-center",
                "render": function (DisabilityId) {
                    return ` <div class="btn-group btn-group-sm">
                                <button class="btn btn-sm btn-primary px-4" data-url="/Disability/Edit/${DisabilityId}" data-id="editDisability" data-dialog-title="Edit Disability" data-dialog-width="modal-lg" data-process-button="Update" onclick="loadAndShowModal($(this))"><i class="fas fa-pen mr-2 ml-0"></i>Update</button>
                                <button class="btn btn-sm btn-danger px-4" data-url="/Disability/Delete/${DisabilityId}" data-id="deleteDisability" data-dialog-title="Delete Disability" data-dialog-width="modal-lg" data-process-button="Delete" onclick="loadAndShowModal($(this))"><i class="fas fa-trash mr-2 ml-0"></i>Delete</button>
                            </div>`;
                },
                width: "30%"
            },

        ]
    });
});