angular.module("umbraco.resources")
.factory("customUserService", function ($http) {
    return {
        getUserById: function (id) {
            return $http.get("backoffice/theTicketSystem/customUserService/getUserById?id=" + id);
        },
        getAll: function() {
            return $http.get("backoffice/theTicketSystem/customUserService/getAll");
        }
    }
});