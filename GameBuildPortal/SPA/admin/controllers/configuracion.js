(function () {
    'use strict';
    angular.module('atlas2').controller('confCtrl', ['$scope', 'confService', confCtrl]);

    function confCtrl($scope, confService) {
        $scope.conf = null;

        $scope.saving = false;

        confService.getId('1').then(
            function (data) {
                $scope.conf = data;
            }, function () {
                $scope.conf = { css: '' , nombre: '', titulo: '', idAppFace: '', claveAppFace: ''};
            }
        );

        $scope.guardar = function () {
            var conf = this.conf;

            if (conf.id) {
                edit(conf);
            } else {
                add(conf);
            }
        }

        var add = function (conf) {
            $scope.saving = true;

            confService.add(conf).then(
                function (data) {
                    $scope.saving = false;

                    mostrarNotificacion('success');
                }, function () {
                    $scope.saving = false;

                    mostrarNotificacion('error');
                }
            );
        }

        var edit = function (conf) {
            $scope.saving = true;

            confService.edit(conf).then(
                function (data) {
                    $scope.saving = false;

                    mostrarNotificacion('success');
                }, function () {
                    $scope.saving = false;

                    mostrarNotificacion('error');
                }
            );
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
    }

})();