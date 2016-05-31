(function () {
    'use strict';
    angular.module('atlas2-juego').controller('edificioCtrl', ['$scope', '$filter', 'jugadorEdificioService', 'coloniaFactory', edificioCtrl]);

    function edificioCtrl($scope, $filter, jugadorEdificioService, coloniaFactory) {
        $scope.edificios = null;
        var currentMapa = null;

        $scope.$on('mapa:current', function (event, data) {
            currentMapa = coloniaFactory.getCurrent();

            jugadorEdificioService.getAllEdificios().then(function (edificios) {

                console.log('edificios', edificios, currentMapa);

                jugadorEdificioService.getEdificioByColonia(currentMapa.id).then(function (jugadorEdificio) {
                    console.log('data', jugadorEdificio);

                    for (var e in edificios) {
                        var ediData = edificios[e];
                        var edi = $filter('filter')(edificios, { 'id': ediData.id });

                        if (edi) {
                            ediData['nivel']= edi.nivelE;
                        }
                    }

                    $scope.edificios = edificios;
                });

            });
        });

        $scope.subirNivel = function (id) {
            console.log('subirNivel', id);

            var edificio = {
                colonia: currentMapa.id,
                edificio: id
            }

            jugadorEdificioService.add(edificio).then(
                function (data) {

                }, function () {

                }
            );
        }
    }

})();