//var mainServive = require("./service");

var ViewModel = function () {
    var self = this;
    self.customers=ko.observableArray();
    self.error = ko.observable();
    var customerUri = '/api/Customers/';
    self.detail = ko.observable();
    self.newCustomer = {
        customerName: ko.observable(),
        customerAddress: ko.observable(),
        customerNumber: ko.observable()
    }

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllCustomers() {
      //  var mainServive = new mainServive();

        ajaxHelper(customerUri,'GET').done(function(data){
            self.customers(data);
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    self.getCustomer = function (item) {
        ajaxHelper(booksUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }

    self.addCustomer = function (formElement) {
        var customer = {
           
            CustomerName: self.newCustomer.customerName(),
            CustomerAddress: self.newCustomer.customerAddress(),
            CustomerNumber: self.newCustomer.customerNumber(),
        };

        ajaxHelper(customerUri, 'POST', customer).done(function (item) {
            self.customers.push(item);
        });
    }

    getAllCustomers();
}

ko.applyBindings(new ViewModel());