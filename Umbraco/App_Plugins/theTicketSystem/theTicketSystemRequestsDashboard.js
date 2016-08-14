angular.module("umbraco").controller("ttsRequests",
    function ($scope, requestResource, notificationsService) {
        $scope.loaded = false;

        $scope.accept = function (id) {
            requestResource.accept(id);
            notificationsService.success("Client was successfully accepted.");
            for (var i = 0; i < $scope.requestList.length; i++) {
                if ($scope.requestList[i].Id == id) {
                    $scope.requestList.splice(i,1);
                }
            }
        }

        $scope.decline = function (id) {
            requestResource.decline(id);
            notificationsService.success("Client was successfully declined.");
            for (var i = 0; i < $scope.requestList.length; i++) {
                if ($scope.requestList[i].Id == id) {
                    $scope.requestList.splice(i, 1);
                }
            }
        }

        requestResource.getAll().then(
            function (response) {
                console.log(response.data);
                $scope.requestList = response.data;
            }
        );

        $scope.loaded = true;
    });

