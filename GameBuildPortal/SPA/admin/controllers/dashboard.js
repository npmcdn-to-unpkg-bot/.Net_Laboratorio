(function () {
    'use strict';
    angular.module('atlas2').controller('dashboardCtrl', ['$scope', 'dashboardService', dashboardCtrl]);

    function dashboardCtrl($scope, dashboardService) {

        dashboardService.getByNuevos().then(function (data) {
            Morris.Bar({
                element: 'porNuevos',
                data: data,
                xkey: 'month',
                hideHover: 'auto',
                barColors: ['#26B99A', '#34495E', '#ACADAC', '#3498DB'],
                ykeys: ['amount', 'sorned'],
                labels: ['amount', 'SORN'],
                xLabelAngle: 60,
                resize: true
            });
        });

        dashboardService.getByNuevos().then(function (data) {
            Morris.Bar({
                element: 'porSesion',
                data: data,
                xkey: 'month',
                hideHover: 'auto',
                barColors: ['#26B99A', '#34495E', '#ACADAC', '#3498DB'],
                ykeys: ['amount', 'sorned'],
                labels: ['amount', 'SORN'],
                xLabelAngle: 60,
                resize: true
            });
        });
    }

})();