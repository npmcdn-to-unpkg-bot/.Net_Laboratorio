(function () {
    'use strict';
    angular.module('atlas2-juego').controller('chatCtrl', ['$scope', '$q', '$firebaseArray', 'chatService', 'meService', 'alianzaService', chatCtrl])

    .directive('onFinishRender', function ($timeout) {
        return {
            restrict: 'A',
            link: function (scope, element, attr) {
                if (scope.$last === true) {
                    $timeout(function () {
                        scope.$emit('ngRepeatFinished');
                    });
                }
            }
        }
    });

    function chatCtrl($scope, $q, $firebaseArray, chatService, meService, alianzaService) {
        $scope.hasAlianza = false;
        $scope.mensajes = null;
        $scope.me = null;

        meService.me().then(function (me) {
            $scope.me = me;
            alianzaService.getByUsuario(me.id).then(function (alianza) {
                if (alianza) {
                    $scope.hasAlianza = true;
                    var canal = alianza.nombre.trim().split(" ").join("_");
                    var ref = new Firebase('https://atlas2-ad386.firebaseio.com/' + canal);
                    
                    $scope.mensajes = $firebaseArray(ref);
                }
            });
        });

        $scope.addMensaje = function () {
            var that = this;
            meService.me().then(function (me) {
                var mensaje = {
                    mensaje: that.mensaje,
                    usuario: me.email
                };

                $scope.mensajes.$add(mensaje);

                that.mensaje = null;
            });
        };

        $scope.$on('ngRepeatFinished', function(ngRepeatFinishedEvent) {
            $('#chat-box').scrollTop($('#chat-box')[0].scrollHeight);
        });
    }

})();