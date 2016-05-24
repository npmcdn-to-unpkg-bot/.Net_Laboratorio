(function () {
    'use strict';
    angular.module('atlas2').controller('investigacionCtrl', ['$scope', '$routeParams', 'investigacionService', 'recursoService', investigacionCtrl]);

    function investigacionCtrl($scope, $routeParams, investigacionService, recursoService) {
        $scope.investigaciones = [];
        $scope.recursos = null;
        $scope.investigacion = null;
        $scope.saving = false;

        recursoService.getAll().then(function (data) {
            $scope.recursos = data;
        });

        var initialize = function () {
            var id = $routeParams && $routeParams['id'] ? $routeParams['id'] : null
            if (id) {
                investigacionService.getId(id).then(function (data) {
                    $scope.investigacion = data;
                });
            } else {
                //investigacionService.getAll().then(function (data) {
                //    $scope.investigaciones = data;
                //});
            }
        }

        $scope.add = function () {
            $scope.saving = true;
            var investigacion = this.investigacion;

            investigacionService.add(investigacion).then(
                function (data) {
                    $scope.investigaciones.push(data);
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
            var investigacion = this.investigacion;

            investigacionService.edit(investigacion).then(
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
            var investigacion = this.investigacion;

            var r = confirm("Seguro que quiere borrar?");
            if (r == true) {
                investigacionService.borrar(investigacion.id).then(
                 function () {
                     $scope.investigaciones.splice(index, 1);
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