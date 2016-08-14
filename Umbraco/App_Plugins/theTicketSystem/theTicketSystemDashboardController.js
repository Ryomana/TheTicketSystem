angular.module("umbraco").controller("ttsDashboardController", function ($scope, TheTicketSystemConfigurationResource, notificationsService) {
    $scope.loaded = false; // is everything loaded ?
    $scope.formChanged = false; // was form changed ?

    // Check if form was changed
    $("form :input").change(function () {
        $scope.formChanged = true;
    });

    TheTicketSystemConfigurationResource.getConfig().then(
        function (response) {
            console.log(response.data);
            $scope.isClient = response.data.isClient.Value;
            $scope.isServer = response.data.isServer.Value;
            $scope.serverUrl = response.data.serverUrl.Value;
            $scope.username = response.data.username.Value;
            $scope.password = response.data.password.Value;

            if ($scope.isClient == "true") {
                var cb = document.getElementById("isClient");
                cb.checked = true;
            }

            if ($scope.isServer == "true") {
                var cb = document.getElementById("isServer");
                cb.checked = true;
            }
        }
    );
    $scope.loaded = true; // finished loading


    // save function
    $scope.save = function () {
        if ($scope.formChanged == true) {
            if (document.getElementById("isClient").checked == true) {
                TheTicketSystemConfigurationResource.setAttributeValue("isClient", "true");
            } else {
                TheTicketSystemConfigurationResource.setAttributeValue("isClient", "false");
            }
            if (document.getElementById("isServer").checked == true) {
                TheTicketSystemConfigurationResource.setAttributeValue("isServer", "true");
            } else {
                TheTicketSystemConfigurationResource.setAttributeValue("isServer", "false");
            }
            TheTicketSystemConfigurationResource.setAttributeValue("serverUrl", encodeURIComponent($scope.serverUrl));
            TheTicketSystemConfigurationResource.setAttributeValue("username", $scope.username);
            TheTicketSystemConfigurationResource.setAttributeValue("password", $scope.password);
            
            $scope.formChanged = false;
            notificationsService.success("Configuration was successfully saved.");
        }
    }
});