var mainServive = (function () {
    function mainService() {

    }

    mainServive.prototype.getAllData = function (uri, method, data) {
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        });
    };



}());
