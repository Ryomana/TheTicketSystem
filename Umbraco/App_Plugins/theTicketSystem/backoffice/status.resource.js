angular.module("umbraco.resources")
.factory("statusResource", function ($http) {
    return {
        getAll: function () {
            return $http.get("backoffice/theTicketSystem/StatusApi/GetAll");
        },
        getById: function (id) {
            return $http.get("backoffice/theTicketSystem/StatusApi/GetById?id=" + id);
        }
    }
});