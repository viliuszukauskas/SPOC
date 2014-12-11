var SpocApp = angular.module('SpocApp', []);

SpocApp.controller('SpocCtrl', function ($scope, $http) {
    $scope.isGenerated = false;

    $scope.SpocModel = {
        cssSelectorAtribute: "data-sel-id"
    };

    $scope.generate = function () {
        $http.post('/api/SpocApi', $scope.SpocModel)
            .success(function (SpocModel) {
                $scope.SpocModel = SpocModel;
            }).error(function (SpocModel) {
                $scope.returnMessage = "An Error has occured posting list";
            });
        $scope.isGenerated = true;
    };

    $scope.back = function () {
        $scope.isGenerated = false;
        $scope.SpocModel = $scope.SpocModel;
    }

    $scope.reset = function () {
        $scope.isGenerated = false;
        $scope.SpocModel = { cssSelectorAtribute: "data-sel-id" };
    };
});