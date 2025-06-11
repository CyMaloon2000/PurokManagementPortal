$(function () {


    RelationshipDT = $("#RelationshipDT").DataTable({
        "processing": true,
        "serverSide": true,
        "ajax": {
            "url": "/Relationship/GetListJson/",
            "type": "POST"
        },
        "columns": [
            {
                "data": "relationshipName",
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
                "data": 'relationshipId',
                "className": "text-center",
                "render": function (RelationshipId) {
                    return ` <div class="btn-group btn-group-sm">
                                <button class="btn btn-sm btn-primary px-4" data-url="/Relationship/Edit/${RelationshipId}" data-id="editRelationship" data-dialog-title="Edit Relationship" data-dialog-width="modal-lg" data-process-button="Update" onclick="loadAndShowModal($(this))"><i class="fas fa-pen mr-2 ml-0"></i>Update</button>
                                <button class="btn btn-sm btn-danger px-4" data-url="/Relationship/Delete/${RelationshipId}" data-id="deleteRelationship" data-dialog-title="Delete Relationship" data-dialog-width="modal-lg" data-process-button="Delete" onclick="loadAndShowModal($(this))"><i class="fas fa-trash mr-2 ml-0"></i>Delete</button>
                            </div>`;
                },
                width: "30%"
            },

        ]
    });
});