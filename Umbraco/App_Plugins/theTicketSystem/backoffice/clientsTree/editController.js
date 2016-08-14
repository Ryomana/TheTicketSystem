angular.module("umbraco").controller("Clients.ClientEditController", 
    function ($scope, $routeParams, clientResource, statusResource, ticketResource,notificationsService, $window) {
        $scope.loaded = false;
        $scope.ticketLoaded = false;

        statusResource.getAll().then(
            function (response) {
                console.log(response.data);
                $scope.statusList = response.data;
            }
        );

        if ($routeParams.id == -1) {
            $scope.client = {};
            $scope.loaded = true;
        } else {
            // get Person id -> service
            clientResource.getById($routeParams.id).then(
                function (response) {
                    $scope.client = response.data;
                    $scope.loaded = true;
                });

            ticketResource.getByClientId($routeParams.id).then(
                function (response) {
                    $scope.tickets = response.data;
                    for (var i = 0; i < $scope.tickets.length; i++) {
                        $scope.tickets[i].Status = $scope.statusList[$scope.tickets[i].fiStatus - 1].Name;
                    }
                }
            );
        }

        $scope.save = function (client) {
            clientResource.save(client).then(
                function (response) {
                    $scope.client = response.data;

                    notificationsService.success("Success", client.Name + "has been saved");
                });
        };

        $scope.showTicket = function (id) {
            $window.location.href = "#/theTicketSystem/clientsTree/ticketView/" + id;
        }
    });