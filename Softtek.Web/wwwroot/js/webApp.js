var webApp = function () {
    return {
        init: function () {

        },
        JsonParam: function (url, param, callback) {
            $.post(url, param, function (data) {
                if (callback != null && typeof (callback) == "function")
                    return callback(data);
            });
        },
    }
}();