(function () {
    'use strict';
    angular.module('atlas2-juego').controller('chatCtrl', ['$scope', '$q', '$firebaseObject', 'chatService', 'meService', 'alianzaService', chatCtrl]);

    function chatCtrl($scope, $q, $firebaseObject, chatService, meService, alianzaService) {
        $scope.chats = null;
        $scope.hasAlianza = false;

        meService.me().then(function (me) {

            alianzaService.getByUsuario(me.id).then(function (alianza) {
                
                if (alianza){
                    $scope.hasAlianza = true;
                    var ref = new Firebase('https://atlas2-ad386.firebaseio.com');
                    $scope.chats = $firebaseObject(ref);
                }

            });

        });
        
    }

})();