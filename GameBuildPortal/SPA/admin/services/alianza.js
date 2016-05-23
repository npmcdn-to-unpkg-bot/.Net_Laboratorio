(function () {
    'use strict';
    angular.module('atlas2').service('alianzaService', ["$http", "$q", alianzaService]);

    function alianzaService($http, $q) {

        var getAll = function () {
            var defer = $q.defer();

            $http.get('/admin/api/alianza')
            .success(function (alianzas) {
                defer.resolve(alianzas);
            })
            .error(function () {
                defer.reject('server error')
            });

            return defer.promise;
        };

        var add = function (alianza) {
            var defer = $q.defer();

            $http.post('/admin/api/alianza', alianza)
            .success(function (alianza) {
                defer.resolve(alianza);
            })
            .error(function () {
                defer.reject('server error')
            });

            return defer.promise;
        };

        var edit = function (alianza) {
            var defer = $q.defer();

            $http.put('/admin/api/alianza?id=' + alianza.id, alianza)
            .success(function (alianza) {
                defer.resolve(alianza);
            })
            .error(function () {
                defer.reject('server error')
            });

            return defer.promise;
        };

        var borrar = function (id) {
            var defer = $q.defer();

            $http.delete('/admin/api/alianza?id=' + id)
            .success(function (alianza) {
                defer.resolve(alianza);
            })
            .error(function () {
                defer.reject('server error')
            });

            return defer.promise;
        };

        var getId = function (id) {
            var defer = $q.defer();

            $http.get('/admin/api/alianza?id=' + id)
            .success(function (alianza) {
                defer.resolve(alianza);
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