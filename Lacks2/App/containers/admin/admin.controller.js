'use strict';

var AdminController = function ($scope, Person) {
    $scope.persons = Person.query();
    $scope.addPerson = function () {
        Person.save($scope.newPerson, function (newP) {
            $scope.persons.push(newP);
            $scope.newPerson = {};
            window.scrollTo(0, document.body.scrollHeight);
        });
    }
}


angular.module('AngularJSApp')
    .component('admin', {
        templateUrl: 'App/containers/admin/admin.html',
        controller: ['$scope', 'Person', AdminController]
});
