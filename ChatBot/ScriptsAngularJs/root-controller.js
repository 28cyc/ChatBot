var app = angular.module('app')
    .run(function ($rootScope) {
        $rootScope.SignalRUrl = getURL() + "/SignalR";
    });

function getURL() {
    return url = location.origin;
}