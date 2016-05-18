(function () {
    'use strict';
    angular.module('atlas2').service('recursoService', ["$http", "$q", recursoService]);

    function recursoService($http, $q) {

        var getAll = function(){
            var defer = $q.defer();

            $http.get('/admin/api/recursos')
            .success(function (employees) {
                defer.resolve(employees);
            })
            .error(function(){
                defer.reject('server error')
            });

            return defer.promise;
        };

        return {
            getAll : getAll
        }

    }

})();