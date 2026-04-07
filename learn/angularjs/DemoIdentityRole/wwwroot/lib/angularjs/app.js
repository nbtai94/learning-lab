(function () {
    'use strict';

    var app = angular.module('app', ['ui.router']);

    app.config(function ($stateProvider, $urlRouterProvider) {
        $stateProvider.state('main', {
            url: '/',
            templateUrl:'Home/Main'
        }).state('home', {
            url: '/home',
            controller: 'homeController',
            templateUrl: 'Home/Index',
        }).state('privacy', {
            url: '/privacy',
            controller: 'privacyController',
            templateUrl: 'Home/Privacy',
        });

        $urlRouterProvider.otherwise('/home');

        console.log("state config runing");
    });

    app.run();

})();