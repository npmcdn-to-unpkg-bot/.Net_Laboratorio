(function () {
    'use strict';
    angular.module('atlas2-juego').controller('appCtrl', ['$scope', 'jugadorMapaService', 'jugadorRecursoService', 'coloniaFactory', appCtrl]);

    function appCtrl($scope, jugadorMapaService, jugadorRecursoService, coloniaFactory) {
        $scope.recursos = null;

        jugadorRecursoService.getAllRecursos().then(function (data) {
            $scope.recursos = data;
        });

        jugadorMapaService.getAll().then(function (data) {
            coloniaFactory.set(data);
        });
    }

})();