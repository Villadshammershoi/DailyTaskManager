$(document).ready(function () {
    $('.check-holder').each(function () {

        $(this).find('.dtm-check-task').on('change', function () {
            if ($(this).prop('checked')) {
                $(this).closest('.dtm-check-container').addClass('bigBoiBackground');
                $(this).closest('.check-holder').find('.dtm-task-container').addClass('bigBoiBackground');
            }
            else {
                $(this).closest('.dtm-check-container').removeClass('bigBoiBackground');
                $(this).closest('.check-holder').find('.dtm-task-container').removeClass('bigBoiBackground');
            }
        });
    });
});