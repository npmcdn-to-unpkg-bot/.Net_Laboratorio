(function () {
    'use strict';
    angular.module('atlas2').service('agrupacionService', ["$http", "$q", agrupacionService]);

    function agrupacionService($http, $q) {

        var getAll = function () {
            var defer = $q.defer();

            $http.get('/admin/api/agrupacion')
            .success(function (agrupaciones) {
                defer.resolve(agrupaciones);
            })
            .error(function () {
                defer.reject('server error')
            });

            return defer.promise;
        };

        var add = function (agrupacion) {
            var defer = $q.defer();

            $http.post('/admin/api/agrupacion', agrupacion)
            .success(function (agrupacion) {
                defer.resolve(agrupacion);
            })
            .error(function () {
                defer.reject('server error')
            });

            return defer.promise;
        };

        var edit = function (agrupacion) {
            var defer = $q.defer();

            $http.put('/admin/api/agrupacion?id=' + agrupacion.id, agrupacion)
            .success(function (agrupacion) {
                defer.resolve(agrupacion);
            })
            .error(function () {
                defer.reject('server error')
            });

            return defer.promise;
        };

        var borrar = function (id) {
            var defer = $q.defer();

            $http.delete('/admin/api/agrupacion?id=' + id)
            .success(function (agrupacion) {
                defer.resolve(agrupacion);
            })
            .error(function () {
                defer.reject('server error')
            });

            return defer.promise;
        };

        var getId = function (id) {
            var defer = $q.defer();

            $http.get('/admin/api/agrupacion?id=' + id)
            .success(function (agrupacion) {
                defer.resolve(agrupacion);
            })
            .error(function () {
                defer.reject('server error')
            });

            return defer.promise;
        };

        return {
            getAll: getAll,
            getId: getId,
            add: add,
            borrar: borrar,
            edit: edit,
        }

    }

})();