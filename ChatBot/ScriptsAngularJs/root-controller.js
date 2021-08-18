var app = angular.module('app')
    .run(function ($rootScope) {
        $rootScope.SignalRUrl = "https://chatbott.azurewebsites.net/SignalR";
    });