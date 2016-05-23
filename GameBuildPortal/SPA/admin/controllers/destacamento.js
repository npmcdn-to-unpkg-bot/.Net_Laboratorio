(function () {
    'use strict';
    angular.module('atlas2').controller('destacamentoCtrl', ['$scope', '$routeParams', 'destacamentoService', destacamentoCtrl]);

    function destacamentoCtrl($scope, $routeParams, destacamentoService) {
        $scope.destacamentos = [];
        $scope.destacamento = null;
        $scope.saving = false;

        var initialize = function () {
            var id = $routeParams && $routeParams['id'] ? $routeParams['id'] : null
            if (id) {
                destacamentoService.getId(id).then(function (data) {
                    $scope.destacamento = data;
                });
            } else {
                destacamentoService.getAll().then(function (data) {
                    $scope.destacamentos = data;
                });
            }
        }

        $scope.add = function () {
            $scope.saving = true;
            var destacamento = this.destacamento;

            destacamentoService.add(destacamento).then(
                function (data) {
                    $scope.destacamentos.push(data);
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
            var destacamento = this.destacamento;

            destacamentoService.edit(destacamento).then(
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
            var destacamento = this.destacamento;

            var r = confirm("Seguro que quiere borrar?");
            if (r == true) {
                destacamentoService.borrar(destacamento.id).then(
                 function () {
                     $scope.destacamentos.splice(index, 1);
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