var SpocApp = angular.module('SpocApp', []);

SpocApp.controller('SpocCtrl', function ($scope, $http) {
    $scope.isGenerated = false;
    $scope.SpocModel = {};

    $scope.generate = function () {
        $http.post('/api/SpocApi', $scope.SpocModel).success(function (SpocModel) {
            $scope.SpocModel = SpocModel;
            $scope.generatedCode = $scope.SpocModel.generatedCode;
        }).error(function () {
            $scope.returnMessage = "An Error has occured posting list";
        });
        $scope.isGenerated = !$scope.isGenerated;
    };

    $scope.reset = function () {
        $scope.isGenerated = false;
        $scope.generatedCode = "";
        $scope.SpocModel = {};
    };
});