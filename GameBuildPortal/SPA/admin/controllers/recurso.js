(function () {
    'use strict';
    angular.module('atlas2').controller('recursoCtrl', ['$scope', '$routeParams', 'recursoService', recursoCtrl]);

    function recursoCtrl($scope, $routeParams, recursoService) {
        $scope.recursos     = [];

        recursoService.getAll().then(function (data) {
            console.log('data', data);
            $scope.recursos.push(data);
        });

        $scope.add = function(){
        	console.log('aaaddd')
        }

        $scope.edit = function(){
        	console.log('aaaddd')
        }

    }

})();