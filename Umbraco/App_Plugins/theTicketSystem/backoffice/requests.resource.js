angular.module("umbraco.resources")
.factory("requestResource", function ($http) {
    return {
        getAll: function () {
            return $http.get("backoffice/theTicketSystem/RequestsApi/GetAll");
        },
        getById: function (id) {
            return $http.get("backoffice/theTicketSystem/RequestsApi/GetById?id=" + id);
        },
        save: function (request) {
            return $http.post("backoffice/theTicketSystem/RequestsApi/PostSave", angular.toJson(request));
        },
        deleteById: function (id) {
            return $http.delete("backoffice/theTicketSystem/RequestsApi/DeleteById?id=" + id);
        },
        accept: function (id) {
            return $http.post("backoffice/theTicketSystem/RequestsApi/AcceptRR?id=" + id);
        },
        decline: function (id) {
            return $http.post("backoffice/theTicketSystem/RequestsApi/DeclineRR?id=" + id);
        }
    }
});