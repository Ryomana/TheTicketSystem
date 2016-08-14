angular.module("umbraco.resources")
.factory("clientResource", function ($http) {
    return {
        getAll: function() {
            return $http.get("backoffice/theTicketSystem/ClientApi/GetAll");
        },
        getById: function (id) {
            return $http.get("backoffice/theTicketSystem/ClientApi/GetById?id=" + id);
        },
        save: function (client) {
            return $http.post("backoffice/theTicketSystem/ClientApi/PostSave", angular.toJson(client));
        },
        deleteById: function (id) {
            return $http.delete("backoffice/theTicketSystem/ClientApi/DeleteById?id=" + id);
        }
    }
});