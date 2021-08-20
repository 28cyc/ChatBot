var app = angular.module('app')
    .run(function ($rootScope) {
        $rootScope.SignalRUrl = "http://localhost:9929/SignalR";
    });