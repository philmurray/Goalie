$(function () {
    $('.edit-goal').on('click', function (e) {
        e.stopPropagation();
        var goalId = $(this).parents("tr").data('goalId');

    });

    $('.view-progress').on('click', function (e) {
        e.stopPropagation();
        var goalId = $(this).parents("tr").data('goalId');

    });

    $('.complete-goal').on('click', function (e) {
        e.stopPropagation();
        var goalId = $(this).parents("tr").data('goalId');

    });
});