(function () {
    'use strict';

    angular.module("app")
        .controller('homeController', homeController);

    homeController.$inject = ['$scope'];

    function homeController($scope) {
        $scope.title = "homcontroller ne";
        activate();

        function activate() {
            console.log("home controller runing");
        }
    }
})();
