'use strict';

var NavbarController = function ($scope) {
    $scope.links = [{
        name: 'Home',
        state: 'home'
    }, {
        name: 'Admin',
        state: 'admin'
    }]
}


angular.module('AngularJSApp')
    .component('navbar', {
        templateUrl: 'App/components/navbar/navbar.html',
        controller: ['$scope', NavbarController]
    });
