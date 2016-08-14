angular.module("umbraco.resources")
.factory("ticketResource", function ($http) {
    return {
        getById: function (id) {
            return $http.get("backoffice/theTicketSystem/TicketApi/GetById?id=" + id);
        },
        getByClientId: function (id) {
            return $http.get("backoffice/theTicketSystem/TicketApi/GetByClientId?id=" + id);
        },
        save: function (client) {
            return $http.post("backoffice/theTicketSystem/TicketApi/PostSave", angular.toJson(client));
        },
        deleteById: function (id) {
            return $http.delete("backoffice/theTicketSystem/TicketApi/DeleteById?id=" + id);
        },
        setStatus: function (id, statusId) {
            return $http.post("backoffice/theTicketSystem/TicketApi/SetStatus?id=" + id + "&statusId=" + statusId);
        }
    }
});