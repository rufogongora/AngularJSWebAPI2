'use strict';

angular.module('AngularJSApp')
    .config(['$stateProvider', function ($stateProvider) {
        $stateProvider
            .state('admin', {
                url: '/admin',
                template: '<admin></admin>',
            });
    }]);
