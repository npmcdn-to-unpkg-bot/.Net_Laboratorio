﻿(function () {

    angular.module('atlas2', ['ngRoute']);

    angular.module('atlas2').config(['$routeProvider', configFunction]);

    /*@ngInject*/
    function configFunction($routeProvider) {
        // Routes
        $routeProvider.when("/", {
            templateUrl : "/SPA/admin/views/home.html",
		    controller  : 'homeCtrl'
		}).otherwise({
            redirectTo 	: '/'
        });

        // ruta de recursos
        $routeProvider.when("/wizard", {
            templateUrl: "/SPA/admin/views/wizard/index.html",
            controller: 'wizardCtrl'
        });

		// ruta de recursos
		$routeProvider.when("/recurso", {
		    templateUrl : "/SPA/admin/views/recurso/list.html",
		    controller  : 'recursoCtrl'
		}).when("/recurso/add", {
		    templateUrl: "/SPA/admin/views/recurso/add.html",
		    controller  : 'recursoCtrl'
		}).when("/recurso/edit/:id", {
		    templateUrl: "/SPA/admin/views/recurso/edit.html",
		    controller  : 'recursoCtrl'
		});
    }

})();