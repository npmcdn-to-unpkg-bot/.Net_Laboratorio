(function () {
    'use strict';
    angular.module('atlas2-juego').controller('destacamentoCtrl', ['$scope', 'jugadorDestacamentoService', 'coloniaFactory', destacamentoCtrl]);

    function destacamentoCtrl($scope, jugadorDestacamentoService, coloniaFactory) {
        $scope.destacamentos = null;
        $scope.destacamento = null;
        $scope.showLoading = null;

        var currentMapa = coloniaFactory.getCurrent();

        var initialize = function () {
            jugadorDestacamentoService.getDestacamentoByColonia(currentMapa.id).then(function (jugadorDestacamento) {
                var destacamentoArray = [];
                for (var r in jugadorDestacamento) {
                    var rel = jugadorDestacamento[r];

                    rel.destacamento['cantidad'] = rel.cantidad;
                    rel.destacamento['relId'] = rel.id;

                    destacamentoArray.push(rel.destacamento);
                }

                $scope.destacamentos = destacamentoArray;
            });
        };

        $scope.$on('mapa:current', function (event, data) {
            currentMapa = coloniaFactory.getCurrent();

            initialize();
        });

        if (currentMapa) {
            initialize();
        }

        $scope.subirCantidad = function (edificio) {
            $scope.showLoading = edificio.id;

            setTimeout(function () {
                jugadorDestacamentoService.subirCantidad(edificio.relId).then(
                    function (data) {
                        $scope.showLoading = null;
                        edificio.nivel++;
                    }, function () {
                        $scope.showLoading = null;
                    }
                );
            }, 3000);

        }

        $scope.bajarCantidad = function (destacamento) {
            $scope.showLoading = destacamento.id;

            setTimeout(function () {
                jugadorDestacamentoService.bajarCantidad(destacamento.relId).then(
                    function (data) {
                        $scope.showLoading = null;
                        //edificio.nivel--;
                    }, function () {
                        $scope.showLoading = null;
                    }
                );
            }, 3000);
        }

        $scope.mostrarInfo = function (destacamento) {
            $scope.destacamento = destacamento;
            $('#modal-info-destacamento').modal('show');
        }

        $('#modal-info-destacamento').on('hidden.bs.modal', function (e) {
            $scope.destacamento = null;
        })
    }

})();