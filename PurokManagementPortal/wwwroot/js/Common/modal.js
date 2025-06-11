function bindFormValidation(target) {
    $.validator.unobtrusive.parse($(target));
}
function formSubmitHandler($form) {
    var json = false;
    if (!$form.valid || $form.valid()) {
        $.ajax({
            async: false,
            type: 'POST',
            url: $form.attr('action'),
            data: $form.serializeArray(),
            dataType: 'json',
            /*contentType: 'application/json; charset=utf-8',*/
            error: function (result) {
                
            },
            success: function (data) {
                json = data;
            }
        });
    }
    return json;
}
function loadAndShowModal(elementTag) {
    var url = elementTag.data('url');
    var dialogTitle = elementTag.data('dialog-title') || "Dialog";
    var dialogWidth = elementTag.data('dialog-width') || "modal-lg";
    var processButtonName = elementTag.data('process-button') || "Submit";
    var dataId = elementTag.data('data-id');
    var helpId = elementTag.data('help-id');


    // Clear previous content
    $('#modalBody').html('<div class="text-center p-3"><div class="spinner-border text-primary"></div></div>');
    $('#modalFooter').empty();
    $('#modalTitle').text(dialogTitle);
    $('#staticBackdrop .modal-dialog').removeClass().addClass('modal-dialog ' + dialogWidth);

    // Load content via AJAX
    $.get(url, function (content) {
        $('#modalBody').html(content);
        var $form = $('#modalBody').find('form');       
        console.log($form.length);
        $('#modalTitle').text(dialogTitle);
        // Add buttons
        if ($form.length > 0) {
            var formId = $form.attr('id');
            $('#modalFooter').html(`
                <button type="submit" class="btn btn-primary" form="${formId}">${processButtonName}</button>
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cancel</button>
            `);            

            //Rebinding jquery-validator
            bindFormValidation('#modalBody');
        } else {
            $('#modalFooter').html(`<button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>`);
        }

        // Optional help banner
        if (helpId) {
            let helpBanner = `
                <div class="alert alert-info d-flex justify-content-between align-items-center">
                    <span>Need help? Click <a href="#" onclick="loadAndShowDialogReload($(this))" data-url="/Help/Detail/${helpId}" data-id="ViewHelpDetail" data-dialog-title="Help Detail" data-dialog-width="modal-xl">here</a> to open help.</span>
                    <button type="button" class="btn-close" onclick="$(this).parent().remove()"></button>
                </div>`;

            $('#modalBody').prepend(helpBanner);
        }

        $('#GenericModal').modal({
            keyboard: false,
            backdrop: 'static'
        });

        $('#GenericModal').modal('show');
    })
    .fail(function (jqXHR, textStatus, errorThrown) {
        $('#modalBody').html(`
            <div class="alert alert-danger">
                <strong>Error:</strong> Could not load the dialog. ${errorThrown}
            </div>
        `);
        $('#modalFooter').html(`
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        `);

        $('#GenericModal').modal({
            keyboard: false,
            backdrop: 'static'
        });

        $('#GenericModal').modal('show');
    });
}


function displaySuccessMessage(form, message) {
    let alertMessage =
        $(`<div class="alert alert-success alert-dismissible fade show" role="alert" style="display: none;">${message}
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            </div>`).prependTo(form);

    alertMessage.slideDown(200);
}

function displayErrorMessage(form, message) {
    let alertMessage = $(`<div class="alert alert-danger alert-dismissible fade show" role="alert" style="display: none;">${message}
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
            </div>`).prependTo(form);

    alertMessage.slideDown(200);
}