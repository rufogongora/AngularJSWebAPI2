'use strict';

var HomeController = function ($scope, Person) {
    $scope.loading = true;
    $scope.persons = Person.query(function () { $scope.loading = false; });
}


angular.module('AngularJSApp')
    .component('home', {
        templateUrl: 'App/containers/home/home.html',
        controller: ['$scope', 'Person', HomeController]
});
