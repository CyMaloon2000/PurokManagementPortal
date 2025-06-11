$(function () {

    PersonDT = $("#PersonDT").DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": "/Person/GetListJson/",
            "type": "POST"
        },
        "columns": [
            {
                "data": "fullName",
                "className": "text-center"
            },
            {
                "data": "gender.GenderName",
                "className": "text-center"
            },
            {
                "data": "birthDate",
                "className": "text-center"
            },
            {
                "data": "maritalStatus.MaritalStatusName",
                "className": "text-center"
            },
            {
                "data": 'HasBirthCert',
                "className": "text-center",
                "render": function (IsActive) {
                    if (IsActive) {
                        return '<a href="#" class="badge badge-primary"><i class="fa fa-check-circle" aria-hidden="true"></i></a>';
                    }
                    else {
                        return '<a href="#" class="badge badge-danger"><i class="fa fa-times-circle" aria-hidden="true"></i></a>';
                    }
                }
            },
            {
                "data": 'personId',
                "className": "text-center",
                "render": function (PersonId) {
                    return ` <div class="btn-group btn-group-sm">
                                <button class="btn btn-sm btn-primary px-4" data-url="/Person/Edit/${PersonId}" data-id="editPerson" data-dialog-title="Edit Person" data-dialog-width="modal-lg" data-process-button="Update" onclick="loadAndShowModal($(this))"><i class="fas fa-pen mr-2 ml-0"></i>Update</button>
                                <button class="btn btn-sm btn-danger px-4" data-url="/Person/Delete/${PersonId}" data-id="deletePerson" data-dialog-title="Delete Person" data-dialog-width="modal-lg" data-process-button="Delete" onclick="loadAndShowModal($(this))"><i class="fas fa-trash mr-2 ml-0"></i>Delete</button>
                            </div>`;
                }
            },

        ]
    });
});