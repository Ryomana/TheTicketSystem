angular.module("umbraco.resources")
.factory("ticketTextResource", function ($http) {
    return {
        getById: function (id) {
            return $http.get("backoffice/theTicketSystem/TicketTextApi/GetById?id=" + id);
        },
        getByTicketId: function (id) {
            return $http.get("backoffice/theTicketSystem/TicketTextApi/GetByTicketId?id=" + id);
        },
        save: function (ticketText) {
            return $http.post("backoffice/theTicketSystem/TicketTextApi/PostSave", angular.toJson(ticketText));
        },
        deleteById: function (id) {
            return $http.delete("backoffice/theTicketSystem/TicketTextApi/DeleteById?id=" + id);
        }
    };
});