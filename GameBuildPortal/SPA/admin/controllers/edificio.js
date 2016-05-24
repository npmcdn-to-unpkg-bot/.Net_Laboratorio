(function () {
    'use strict';
    angular.module('atlas2').controller('edificioCtrl', ['$scope', '$routeParams', '$location', 'edificioService', 'recursoService', edificioCtrl]);

    function edificioCtrl($scope, $routeParams, $location, edificioService, recursoService) {
        $scope.edificios = [];
        $scope.recursos = null;
        $scope.edificio = null;
        $scope.saving = false;

        var path = $location.path();

        var initialize = function () {
            recursoService.getAll().then(function (data) {
                $scope.recursos = data;
            });

            if (path.indexOf('edit') > -1 || path.indexOf('add') > -1) {
                var id = $routeParams && $routeParams['id'] ? $routeParams['id'] : null
                if (id) {
                    edificioService.getId(id).then(function (data) {
                        $scope.edificio = data;
                    });
                } 
            } else {
                edificioService.getAll().then(function (data) {
                    $scope.edificios = data;
                });
            }
        }

        $scope.add = function () {
            $scope.saving = true;
            var edificio = this.edificio;

            edificioService.add(edificio).then(
                function (data) {
                    $scope.edificios.push(data);
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
            var edificio = this.edificio;

            edificioService.edit(edificio).then(
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
            var edificio = this.edificio;

            var r = confirm("Seguro que quiere borrar?");
            if (r == true) {
                edificioService.borrar(edificio.id).then(
                 function () {
                     $scope.edificios.splice(index, 1);
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