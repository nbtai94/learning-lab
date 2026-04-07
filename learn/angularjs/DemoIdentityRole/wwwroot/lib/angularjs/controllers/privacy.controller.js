(function () {
    'use strict';

    angular
        .module('app')
        .controller('privacyController', privacyController);

    privacyController.$inject = ['$scope'];

    function privacyController($scope) {
        $scope.title = 'privacy';

        activate();

        function activate() {
            console.log("privacy controller runing!")
        };
    }
})();
