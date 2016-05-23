(function () {
    'use strict';
    angular.module('atlas2').controller('agrupacionCtrl', ['$scope', '$routeParams', 'agrupacionService', agrupacionCtrl]);

    function agrupacionCtrl($scope, $routeParams, agrupacionService) {
        $scope.agrupaciones = [];
        $scope.agrupacion = null;
        $scope.saving = false;

        var initialize = function () {
            var id = $routeParams && $routeParams['id'] ? $routeParams['id'] : null
            if (id) {
                agrupacionService.getId(id).then(function (data) {
                    $scope.agrupacion = data;
                });
            } else {
                agrupacionService.getAll().then(function (data) {
                    $scope.agrupaciones = data;
                });
            }
        }

        $scope.add = function () {
            $scope.saving = true;
            var agrupacion = this.agrupacion;

            agrupacionService.add(agrupacion).then(
                function (data) {
                    $scope.agrupaciones.push(data);
                    $scope.saving = false;

                    mostrarNotificacion('success');
                    window.history.back();
                }, function () {
                    $scope.saving = false;

                    mostrarNotificacion('error');
                }
            );
        }

        $scope.edit = function () {
            $scope.saving = true;
            var agrupacion = this.agrupacion;

            agrupacionService.edit(agrupacion).then(
                function (data) {
                    $scope.saving = false;

                    mostrarNotificacion('success');
                    window.history.back();
                }, function () {
                    $scope.saving = false;

                    mostrarNotificacion('error');
                }
            );
        }

        $scope.borrar = function (index) {
            $scope.saving = true;
            var agrupacion = this.agrupacion;

            var r = confirm("Seguro que quiere borrar?");
            if (r == true) {
                agrupacionService.borrar(agrupacion.id).then(
                 function () {
                     $scope.agrupaciones.splice(index, 1);
                     $scope.saving = false;

                     mostrarNotificacion('success');
                 }, function () {
                     $scope.saving = false;

                     mostrarNotificacion('error');
                 }
             );
            }
        }

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