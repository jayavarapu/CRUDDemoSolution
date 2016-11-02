/// <reference path="../angular.js" />
var app = angular.module('CurdDemoApp', ['CrudDemoApp.Controllers', 'ngRoute']);
app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider.
    when('/', {
        controller: 'MainController',
        templateUrl: '/partials/listpayers.html'
    }).
        when('/addplayer', {
            controller: "AddPlayerController",
            templateUrl: '/partials/addplayer.html'
        }).
        when('/editplayer/:id', {
            controller: "EdiPlayerController",
            templateUrl: '/partials/editplayer.html'
        }).
    
    otherwise({
        redirectTo: '/'
    });
}]);
