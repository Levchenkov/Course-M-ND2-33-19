var App = App || {};
App.Post = App.Post || {};
App.Post.Edit = (function () {

    function init(saveButton, title, editPostUrl) {
        saveButton.click(function(e) {
            e.preventDefault();

            var titleValue = title.val();
            if (confirm('Do you want to Save Post with title: ' + titleValue)) {

                var formdata = $("form").serializeArray();
                var data = {};
                $(formdata).each(function (index, obj) {
                    data[obj.name] = obj.value;
                });

                $.ajax({
                    url: editPostUrl,
                    type: "post",
                    data: data,
                    success: function(data) {
                        console.log('Saved');
                    }
                });
            }
        });
    }

    var instance = {
        Initialize: init
    };

    return instance;
})();


