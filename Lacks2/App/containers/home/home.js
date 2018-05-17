'use strict';

angular.module('AngularJSApp')
    .config(['$stateProvider', function ($stateProvider) {
        $stateProvider
            .state('home', {
                url: '/home',
                template: '<home></home>',
            });
    }]);
