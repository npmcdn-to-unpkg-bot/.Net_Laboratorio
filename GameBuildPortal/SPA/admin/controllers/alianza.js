(function () {
    'use strict';
    angular.module('atlas2').controller('alianzaCtrl', ['$scope', '$routeParams', 'alianzaService', alianzaCtrl]);

    function alianzaCtrl($scope, $routeParams, alianzaService) {
        $scope.alianzas = [];
        $scope.alianza = null;
        $scope.saving = false;

        var initialize = function () {
            var id = $routeParams && $routeParams['id'] ? $routeParams['id'] : null
            if (id) {
                alianzaService.getId(id).then(function (data) {
                    $scope.alianza = data;
                });
            } else {
                alianzaService.getAll().then(function (data) {
                    $scope.alianzas = data;
                });
            }
        }

        $scope.add = function () {
            $scope.saving = true;
            var alianza = this.alianza;

            alianzaService.add(alianza).then(
                function (data) {
                    $scope.alianzas.push(data);
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
            var alianza = this.alianza;

            alianzaService.edit(alianza).then(
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
            var alianza = this.alianza;

            var r = confirm("Seguro que quiere borrar?");
            if (r == true) {
                alianzaService.borrar(alianza.id).then(
                 function () {
                     $scope.alianzas.splice(index, 1);
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