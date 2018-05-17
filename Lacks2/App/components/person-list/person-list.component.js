'use strict';

var PersonListController = function ($scope, $filter) {
    //initialize the new foods array to 0
    $scope.newFoods = [];

    //get the data passed from the container ( this enables data sharing per component)
    this.$onInit = function () {
        $scope.editing = this.editing;
        this.persons.$promise.then(function (data) {
            $scope.persons = data;
            for (var i = 0; i < $scope.persons.length; i++)
                reOrderFoods($scope.persons[i]);
        });
        if ($scope.editing != 'true')
            $scope.sortableOptions.disabled = true;
    };

    //delete someone, ideally would like some confimration from a modal or something
    $scope.deletePerson = function (p) {
        p.$delete(function () {
            $scope.persons.splice($scope.persons.indexOf(p), 1);
        });
    }

    //options for the ui sortable options
    $scope.sortableOptions = {
        disabled: false,
        'ui-preserve-size': true,
        stop: function (t, ui) {
            var person = getById(ui.item.sortable.model.personId);
            person.foods = ui.item.sortable.sourceModel;
            updatePerson(person);
        }
    };

    //add food
    $scope.addFood = function (person, newFood) {
        person.foods.push(newFood);
        $scope.newFood = {};
        updatePerson(person);
    }

    //remove food
    $scope.removeFood = function (person, food) {
        person.foods.splice(person.foods.indexOf(food), 1);
        updatePerson(person);

    }

    //-- Start private functions --//
    //get person by id
    function getById(id) {
        for (var i = 0; i < $scope.persons.length; i++) {
            if ($scope.persons[i].id == id)
                return $scope.persons[i];
        }
    }

    //update the person on the db
    function updatePerson(person) {
        person.$update(function () {
            reOrderFoods(person);
        });
        
    }

    //apply a filter for ordering (this has to be done this way, due to how the ui.sortable plugin works)
    function reOrderFoods(person) {
        person.foods = $filter('orderBy')(person.foods, 'order');
    }

}


angular.module('AngularJSApp')
    .component('personlist', {
        bindings: {
            editing: '@',
            persons : '<'
        },
        templateUrl: 'App/components/person-list/person-list.html',
        controller: ['$scope', '$filter', PersonListController]
    });
