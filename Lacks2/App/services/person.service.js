'use strict';

(function () {

    function PersonResource($resource) {
        return $resource('api/persons/:id', {
            id: '@id'
        }, {
                update: {  method : 'PUT' }
            });
    }

    angular.module('AngularJSApp')
        .factory('Person', ['$resource', PersonResource]);

})();
