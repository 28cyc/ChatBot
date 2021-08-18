var app = angular.module('app', [])
    .controller('AdUserCtrl', function ($scope, $rootScope, $http, $window) {
        debugger

        $scope.adUsers = [{
            "Cn": "",
            "Sn": "",
            "GivenName": "",
            "DisplayName": "",
            "Status": ""
        }];

        jQuery.support.cors = true;

        //AngularJS寫法
        $window.jQuery.connection.hub.url = $rootScope.SignalRUrl;
        var myHub = $window.jQuery.connection.updateModifiedAdUsersHub;
        $window.jQuery.connection.hub.start();

        //一般寫法
        //$.connection.hub.url = $rootScope.SignalRUrl;
        //var myHub = $.connection.updatemodifiedadusershub;
        //$.connection.hub.start();

        myHub.client.updateModifiedAdUsers = function (data) {
            $scope.adUsers = data;
            $scope.$apply();
        };
    }
    );