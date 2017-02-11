(function ($) {

    $(document).ready(function () { //document.ready(){

        var isAdvancedUpload = function () {
            var div = document.createElement('div');
            return (('draggable' in div) || ('ondragstart' in div && 'ondrop' in div)) && 'FormData' in window && 'FileReader' in window;
        }();

        var $form = $('.box');
        var $input = $form.find('input[type="file"]');
        var $errorMsg = $form.find('.box__error');

        if (isAdvancedUpload) {
            console.log(isAdvancedUpload);
            $form.addClass('has-advanced-upload');

            var droppedFiles = false;

            $form.on('drag dragstart dragend dragover dragenter dragleave drop', function (e) {
                e.preventDefault();
                e.stopPropagation();
            })
            .on('dragover dragenter', function () {
                $form.addClass('is-dragover');
            })
            .on('dragleave dragend drop', function () {
                $form.removeClass('is-dragover');
            })
            .on('drop', function (e) {
                droppedFiles = e.originalEvent.dataTransfer.files;
                $form.trigger('submit'); //automatically submit the form on file drop
            });
        }

        $form.on('submit', function (e) {
            if ($form.hasClass('is-uploading')) return false;

            $form.addClass('is-uploading').removeClass('is-error');

            if (isAdvancedUpload) {
                console.log('advanced upload')
                // ajax for modern browsers

                e.preventDefault();

                var ajaxData = new FormData();

                if (droppedFiles) {
                    $.each(droppedFiles, function (i, file) {
                        ajaxData.append($input.attr('name'), file);
                        console.log(file);
                    });

                    console.log(ajaxData);
                }

                $.ajax({
                    url: $form.attr('action'),
                    type: $form.attr('method'),
                    data: ajaxData,
                    dataType: 'json',
                    cache: false,
                    contentType: false,
                    processData: false,
                    complete: function() {
                        $form.removeClass('is-uploading');
                    },
                    success: function(data) {
                        $form.addClass( data.success == true ? 'is-success' : 'is-error' );
                        if (!data.success) $errorMsg.text(data.error);
                    },
                    error: function() {
                    // Log the error, show an alert, whatever works for you
                    }
                });
            } else {
                console.log('legacy upload');
                // ajax for legacy browsers
            }
        });
    })
})(jQuery);