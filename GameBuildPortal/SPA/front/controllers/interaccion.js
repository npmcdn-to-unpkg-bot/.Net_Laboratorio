(function () {
    'use strict';
    angular.module('atlas2-juego').controller('interaccionCtrl', ['$scope', '$q', '$routeParams', 'coloniaFactory', 'interaccionService', 'jugadorDestacamentoService', 'jugadorRecursoService', 'jugadorMapaService', interaccionCtrl]);

    function interaccionCtrl($scope, $q, $routeParams, coloniaFactory, interaccionService, jugadorDestacamentoService, jugadorRecursoService, jugadorMapaService) {
        var receiverId = $routeParams && $routeParams['receiverId'] ? $routeParams['receiverId'] : null;
        var interaccion = $routeParams && $routeParams['interaccion'] ? $routeParams['interaccion'].charAt(0).toUpperCase() + $routeParams['interaccion'].slice(1) : null;

        $scope.interaccion = { nombre: interaccion };
        $scope.destacamentos = null;
        $scope.recursos = null;
        $scope.destacamentosReceiver = null;
        $scope.recursosReceiver = null;

        var currentMapa = coloniaFactory.getCurrent();

        var initialize = function () {
            destacamentoByColonia(currentMapa.id).then(function (destacamentos) {
                $scope.destacamentos = destacamentos
            });

            recursoByColonia(currentMapa.id).then(function (recursos) {
                $scope.recursos = recursos
            });

            destacamentoByColonia(receiverId).then(function (destacamentos) {
                $scope.destacamentosReceiver = destacamentos
            });

            recursoByColonia(receiverId).then(function (recursos) {
                $scope.recursosReceiver = recursos
            });

            jugadorMapaService.getColoniaById(receiverId).then(function (colonia) {
                $scope.interaccion['receiver'] = colonia.jugador;
            });
        };

        var destacamentoByColonia = function (coloniaId) {
            var defer = $q.defer();

            jugadorDestacamentoService.getDestacamentoByColonia(coloniaId).then(function (jugadorDestacamento) {
                var destacamentoArray = [];
                for (var r in jugadorDestacamento) {
                    var rel = jugadorDestacamento[r];

                    rel.destacamento['relId'] = rel.id;

                    var cant = []
                    for (var c = 0; c <= rel.cantidad; c++) {
                        cant.push(c);
                    }

                    rel.destacamento['cantidad'] = cant;

                    destacamentoArray.push(rel.destacamento);
                }

                defer.resolve(destacamentoArray);
            });

            return defer.promise;
        };

        var recursoByColonia = function (coloniaId) {
            var defer = $q.defer();

            jugadorRecursoService.getRecursoByColonia(coloniaId).then(function (jugadorRecurso) {
                var recursoArray = [];
                for (var r in jugadorRecurso) {
                    var rel = jugadorRecurso[r];

                    rel.recurso['cantidad'] = rel.cantidadR;
                    rel.recurso['capacidad'] = rel.capacidad;

                    recursoArray.push(rel.recurso);
                }

                defer.resolve(recursoArray);
            });

            return defer.promise;
        };

        $scope.$on('mapa:current', function (event, data) {
            currentMapa = coloniaFactory.getCurrent();

            initialize();
        });

        if (currentMapa) {
            initialize();
        }
    }

})();