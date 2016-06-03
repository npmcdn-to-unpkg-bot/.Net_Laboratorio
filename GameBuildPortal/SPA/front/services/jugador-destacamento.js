(function () {
    'use strict';
    angular.module('atlas2-juego').service('jugadorDestacamentoService', ['$http', '$q', jugadorDestacamentoService]);

    function jugadorDestacamentoService($http, $q) {

        var getDestacamentoByColonia = function (colonia) {
            var defer = $q.defer();

            $http.get('/api/jugadorDestacamento/ByColonia?id=' + colonia)
            .success(function (jugadorDestacamentos) {
                defer.resolve(jugadorDestacamentos);
            })
            .error(function () {
                defer.reject('server error')
            });

            return defer.promise;
        };

        var subirCantidad = function (id) {
            var defer = $q.defer();

            $http.put('/api/jugadorDestacamento/SubirCantidad?id=' + id)
            .success(function (jugadorDestacamento) {
                defer.resolve(jugadorDestacamento);
            })
            .error(function () {
                defer.reject('server error')
            });

            return defer.promise;
        };

        var bajarCantidad = function (id) {
            var defer = $q.defer();

            $http.delete('/api/jugadorDestacamento/BajarCantidad?id=' + id)
            .success(function (jugadorDestacamento) {
                defer.resolve(jugadorDestacamento);
            })
            .error(function () {
                defer.reject('server error')
            });

            return defer.promise;
        };

        var getId = function (id) {
            var defer = $q.defer();

            $http.get('/api/jugadorDestacamento/' + id)
            .success(function (jugadorDestacamento) {
                defer.resolve(jugadorDestacamento);
            })
            .error(function () {
                defer.reject('server error')
            });

            return defer.promise;
        };

        return {
            getDestacamentoByColonia: getDestacamentoByColonia,
            getId: getId,
            subirCantidad: subirCantidad,
            bajarCantidad: bajarCantidad,
        }

    }

})();