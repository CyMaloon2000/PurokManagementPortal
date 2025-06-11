$(function () {
    //$("#GenderDT").DataTable();


    GenderDT = $("#GenderDT").DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": "/Gender/GetListJson/",
            "type": "POST"
        },
        "columns": [
            {
                "data": "genderName",
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
                "data": 'genderId',
                "className": "text-center",
                "render": function (GenderId) {
                    return ` <div class="btn-group btn-group-sm">
                                <button class="btn btn-sm btn-primary px-4" data-url="/Gender/Edit/${GenderId}" data-id="editGender" data-dialog-title="Edit Gender" data-dialog-width="modal-lg" data-process-button="Update" onclick="loadAndShowModal($(this))"><i class="fas fa-pen mr-2 ml-0"></i>Update</button>
                                <button class="btn btn-sm btn-danger px-4" data-url="/Gender/Delete/${GenderId}" data-id="deleteGender" data-dialog-title="Delete Gender" data-dialog-width="modal-lg" data-process-button="Delete" onclick="loadAndShowModal($(this))"><i class="fas fa-trash mr-2 ml-0"></i>Delete</button>
                            </div>`;
                },
                width: "30%"
            },

        ]
    });
});