(function () {
    'use strict'

    var app = angular.module('MainApp', []);

    app.controller('MainController', MainController);

    MainController.$inject = ['$http'];

    function MainController($http) {

        var vm = this;
        vm.editItemBtnClick = _editItemBtnClick

        $http({                     //oninit
            method: 'GET',
            url: '../api/surfboard'
        }).then(success, error)

        function success(res) {
            vm.items = res.data
        }

        function error(err) {
            console.log(err);
        }


        function _editItemBtnClick(item) {
            $(location).attr('href', '/content/create.html' + '?id=' + item.id);
        }

    }
})();