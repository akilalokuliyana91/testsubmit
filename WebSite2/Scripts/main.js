function listCustomers() {
    $.ajax({
        url: 'http://localhost:5400/api/Customers',
        type: 'GET',
        success: function (result) {
            $("#customer-list").empty();
            $("#customer-list-template").tmpl(result, { index: function (item) { return $.inArray(item, result); } }).appendTo("#customer-list");
        }
    });
}