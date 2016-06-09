(function () {
    'use strict';
    angular.module('atlas2-juego').controller('alianzaCtrl', ['$scope', '$q', 'alianzaService', alianzaCtrl]);

    function alianzaCtrl($scope, $q, alianzaService) {
        $scope.alianzas = null;

        alianzaService.getAll().then(function (alianzas) {
            $scope.alianzas = alianzas;
        });

        $scope.crearAlianza = function () {
            var alianza = this.alianza;

            alianzaService.add(alianza).then(function (data) {
                window.history.back();
            });
        }

        $scope.unirse = function (alianzaId) {
            alianzaService.unirse(alianza).then(function (data) {
                $('#mensaje-union').fadeIn();

                setTimeout(function () {
                    $('#mensaje-union').fadeOut();
                }, 3000);
            });
        }
    }

})();