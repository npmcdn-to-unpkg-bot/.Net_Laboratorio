(function () {
    'use strict';
    angular.module('atlas2').controller('recursoCtrl', ['$scope', '$routeParams', 'recursoService', recursoCtrl]);

    function recursoCtrl($scope, $routeParams, recursoService) {
        $scope.recursos     = [];
        $scope.showAlert    = false;

        console.log($routeParams);

        recursoService.getAll().then(function (data) {
            $scope.recursos = data;
        });

        $scope.add = function(){
        	console.log('aaaddd')
        }

        $scope.edit = function(){
        	console.log('aaaddd')
        }

    }

})();