$(function () {


    HealthDT = $("#HealthDT").DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": "/HealthCondition/GetListJson/",
            "type": "POST"
        },
        "columns": [
            {
                "data": "healthConditionName",
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
                "data": 'healthConditionId',
                "className": "text-center",
                "render": function (HealthConditionId) {
                    return ` <div class="btn-group btn-group-sm">
                                <button class="btn btn-sm btn-primary px-4" data-url="/HealthCondition/Edit/${HealthConditionId}" data-id="editHealth" data-dialog-title="Edit Health" data-dialog-width="modal-lg" data-process-button="Update" onclick="loadAndShowModal($(this))"><i class="fas fa-pen mr-2 ml-0"></i>Update</button>
                                <button class="btn btn-sm btn-danger px-4" data-url="/HealthCondition/Delete/${HealthConditionId}" data-id="deleteHealth" data-dialog-title="Delete Health" data-dialog-width="modal-lg" data-process-button="Delete" onclick="loadAndShowModal($(this))"><i class="fas fa-trash mr-2 ml-0"></i>Delete</button>
                            </div>`;
                },
                width: "30%"
            },

        ]
    });
});