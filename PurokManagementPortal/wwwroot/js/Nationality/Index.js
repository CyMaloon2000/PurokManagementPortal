$(function () {


    NationalityDT = $("#NationalityDT").DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": "/Nationality/GetListJson/",
            "type": "POST"
        },
        "columns": [
            {
                "data": "nationalityName",
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
                "data": 'nationalityId',
                "className": "text-center",
                "render": function (NationalityId) {
                    return ` <div class="btn-group btn-group-sm">
                                <button class="btn btn-sm btn-primary px-4" data-url="/Nationality/Edit/${NationalityId}" data-id="editNationality" data-dialog-title="Edit Nationality" data-dialog-width="modal-lg" data-process-button="Update" onclick="loadAndShowModal($(this))"><i class="fas fa-pen mr-2 ml-0"></i>Update</button>
                                <button class="btn btn-sm btn-danger px-4" data-url="/Nationality/Delete/${NationalityId}" data-id="deleteNationality" data-dialog-title="Delete Nationality" data-dialog-width="modal-lg" data-process-button="Delete" onclick="loadAndShowModal($(this))"><i class="fas fa-trash mr-2 ml-0"></i>Delete</button>
                            </div>`;
                },
                width: "30%"
            },

        ]
    });
});