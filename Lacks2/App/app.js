'use strict';

angular.module('AngularJSApp',
    ['ui.router',
        'ngResource',
    'ui.sortable'])

    .config(['$urlRouterProvider', '$locationProvider', function ($urlRouterProvider, $locationProvider) {
        $urlRouterProvider
            .otherwise('/home');

        $locationProvider.html5Mode(true);
    }]);
