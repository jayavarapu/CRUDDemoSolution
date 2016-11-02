/// <reference path="../angular.js" />
angular.module('CrudDemoApp.Controllers', [])
.controller('MainController', function ($scope) {
    $scope.message = "Welcome to Crud Demo";
}).controller('AddPlayerController', ['$scope', function ($scope) {
    $scope.message="Add Player Controller message"

}]).controller('EdiPlayerController', ['$scope', function ($scope) {
    $scope.message = "Edit Player Controller message"
}]).factory('PlayerService', ['$http', function ($http) {
    var fact = {};

    fact.GetplayersFromDb = function () {
        return $http.get('/player/GetPlayers');
    };
    fact.GetplayerByPayerId = function (id) {
        return $http.get('/player/GetPlayerById', { params: { id: id } });
    };
    fact.AddPlayer = function (player) {
        return $http.post('/player/AddPlayer', player).success(function (response) {
            alert(response.status);
        });
    };
    fact.UpdatePlayer = function (player) {
        return $http.post('/player/UpdatePlayer', player).success(function (response) {
            alert(response.status);
        });
    };
    fact.DeletePlayer = function (id) {
        return $http.post('/player/Delete', { payerId: id }).success(function (response) {
            alert(response.status);
        });
    };
    return fact;
}]);
