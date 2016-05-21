(function () {
    'use strict';
    angular.module('atlas2').controller('recursoCtrl', ['$scope', '$routeParams', 'recursoService', recursoCtrl]);

    function recursoCtrl($scope, $routeParams, recursoService) {
        $scope.recursos = [];

        recursoService.getAll().then(function (data) {
            $scope.recursos = data;
        });

        $scope.add = function(){
        	console.log('aaaddd')
        }

        $scope.edit = function(){
        	console.log('aaaddd')
        }

        new PNotify({
            title: 'Regular Success',
            text: 'That thing that you were trying to do worked!',
            type: 'success'
        });

    }

})();