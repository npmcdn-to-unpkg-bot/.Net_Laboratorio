(function () {
    'use strict';
    angular.module('atlas2').controller('mapaCtrl', ['$scope', '$routeParams', 'mapaService', mapaCtrl]);

    function mapaCtrl($scope, $routeParams, mapaService) {
        $scope.mapas = [];
        $scope.mapa = null;
        $scope.saving = false;

        var initialize = function () {
            var id = $routeParams && $routeParams['id'] ? $routeParams['id'] : null
            if (id) {
                mapaService.getId(id).then(function (data) {
                    $scope.mapa = data;
                });
            } else {
                mapaService.getAll().then(function (data) {
                    $scope.mapas = data;
                });
            }
        }

        $scope.add = function () {
            $scope.saving = true;
            var mapa = this.mapa;

            mapaService.add(mapa).then(
                function (data) {
                    $scope.mapas.push(data);
                    $scope.saving = false;

                    mostrarNotificacion('success');
                    window.history.back();
                }, function () {
                    $scope.saving = false;

                    mostrarNotificacion('error');
                }
            );
        }

        //$scope.edit = function () {
        //    $scope.saving = true;
        //    var recurso = this.recurso;

        //    mapaService.edit(recurso).then(
        //        function (data) {
        //            $scope.saving = false;

        //            mostrarNotificacion('success');
        //            window.history.back();
        //        }, function () {
        //            $scope.saving = false;

        //            mostrarNotificacion('error');
        //        }
        //    );
        //}

        //$scope.borrar = function () {
        //    $scope.saving = true;
        //    var recurso = this.recurso;

        //    var r = confirm("Seguro que quiere borrar?");
        //    if (r == true) {
        //        mapaService.borrar(recurso.id).then(
        //         function (data) {
        //             $scope.recursos.pop(data);
        //             $scope.saving = false;

        //             mostrarNotificacion('success');
        //         }, function () {
        //             $scope.saving = false;

        //             mostrarNotificacion('error');
        //         }
        //     );
        //    }
        //}

        var mostrarNotificacion = function (tipo) {
            var title = '';
            var text = '';

            if (tipo == 'success') {
                var title = 'Exito!';
                var text = 'Acción realizada con exito.';
            } else if (tipo == 'error') {
                var title = 'Oh No!';
                var text = 'Ha ocurrido un error.';
            }

            new PNotify({
                title: title,
                text: text,
                type: tipo,
                nonblock: {
                    nonblock: true
                }
            });
        }

        initialize();
    }

})();