$(function () {
    var $goalModal = $('#goalModal'),
        $modalBody = $goalModal.find('.modal-body'),
        $modalTitle = $goalModal.find('.modal-title');

    $goalModal.on('click', '.save-changes', function () {
        $modalBody.find('form').submit();
    });

    $('.edit-goal').on('click', function (e) {
        e.stopPropagation();

        $modalBody.load($(this).data('viewUrl'), function () {
            $modalTitle.html("Edit Goal");
            $goalModal.modal("show");
        });
    });

    $('.add-goal').on('click', function (e) {
        e.stopPropagation();

        $modalBody.load($(this).data('viewUrl'), function () {
            $modalTitle.html("Add New Goal");
            $goalModal.modal("show");
        });
    });

    $('.complete-goal').on('click', function (e) {
        e.stopPropagation();

        $modalBody.load($(this).data('viewUrl'), function () {
            $modalTitle.html("Complete Goal?");

            $goalModal.modal("show");
            $modalBody.find('#Completed').val("True");
        });

    });
});