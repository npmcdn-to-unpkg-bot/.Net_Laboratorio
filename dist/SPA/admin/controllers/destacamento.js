(function () {
    'use strict';
    angular.module('atlas2').controller('destacamentoCtrl', ['$scope', '$routeParams', '$location', 'destacamentoService', 'recursoService', destacamentoCtrl]);

    function destacamentoCtrl($scope, $routeParams, $location, destacamentoService, recursoService) {
        $scope.destacamentos    = [];
        $scope.costos           = [];

        $scope.recursos = null;
        var recursos    = [];
        $scope.saving   = false;

        $scope.destacamento = null;
        $scope.costo        = null;

        var path = $location.path();

        var initialize = function () {
            recursoService.getAll().then(function (data) {
                $scope.recursos = data;
                recursos        = angular.copy(data);
            });

            if (path.indexOf('edit') > -1 || path.indexOf('add') > -1) {
                var id = $routeParams && $routeParams['id'] ? $routeParams['id'] : null
                if (id) {
                    destacamentoService.getId(id).then(function (data) {
                        $scope.destacamento = data;
                    });
                }
            } else {
                destacamentoService.getAll().then(function (data) {
                    $scope.destacamentos = data;
                });
            }
        }

        $scope.add = function () {
            $scope.saving    = true;
            var destacamento = this.destacamento;

            destacamento['costos'] = $scope.costos;

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

        $scope.addCosto = function () {
            var costo = this.costo;

            for (var rec in $scope.recursos) {
                var recurso = $scope.recursos[rec];
                if (parseInt(costo.recurso) == recurso.id) {
                    var costoGuardar = {
                        recurso         : costo.recurso,
                        nombreRecurso   : recurso.nombre,
                        valor           : costo.valor,
                        incrementoNivel : costo.incrementoNivel
                    }

                    $scope.costos.push(costoGuardar);
                    $scope.recursos.splice(rec, 1);

                    this.costo = null;
                }
            }
        }

        $scope.removeCosto = function (index) {
            var costo = $scope.costos[index];
            for (var rec in recursos) {
                var recurso = recursos[rec];

                if (parseInt(costo.recurso) == recurso.id) {
                    $scope.recursos.push(recurso);
                    $scope.costos.splice(index, 1);
                }
            }
        }

        initialize();

    }

})();