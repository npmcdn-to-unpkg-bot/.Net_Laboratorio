(function () {

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

        // ruta de wizard
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

        // ruta de mapa
		$routeProvider.when("/mapa", {
		    templateUrl: "/SPA/admin/views/mapa/list.html",
		    controller: 'mapaCtrl'
		}).when("/mapa/add", {
		    templateUrl: "/SPA/admin/views/mapa/add.html",
		    controller: 'mapaCtrl'
		}).when("/mapa/edit/:id", {
		    templateUrl: "/SPA/admin/views/mapa/edit.html",
		    controller: 'mapaCtrl'
		});

        // ruta de investigacion
		$routeProvider.when("/investigacion", {
		    templateUrl : "/SPA/admin/views/investigacion/list.html",
		    controller  : 'investigacionCtrl'
		}).when("/investigacion/add", {
		    templateUrl: "/SPA/admin/views/investigacion/add.html",
		    controller  : 'investigacionCtrl'
		}).when("/investigacion/edit/:id", {
		    templateUrl: "/SPA/admin/views/investigacion/edit.html",
		    controller  : 'investigacionCtrl'
		});
    }

})();