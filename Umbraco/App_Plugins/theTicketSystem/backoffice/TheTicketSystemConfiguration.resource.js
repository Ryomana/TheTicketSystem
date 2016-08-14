angular.module("umbraco.resources")
.factory("TheTicketSystemConfigurationResource", function ($http) {
    return {
        getConfig: function() {
            return $http.get("backoffice/theTicketSystem/TheTicketSystemConfig/GetConfig");
        },
        setAttributeValue: function (attr, value) {
            return $http.post("backoffice/theTicketSystem/TheTicketSystemConfig/SetAttributeValue?attrName="+ attr +"&value=" + value);
        }
    }
});