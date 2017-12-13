(function () {
    'use strict'

    var app = angular.module('MainApp', []);

    app.controller('MainController', MainController);

    MainController.$inject = ['$http', '$window'];

    function MainController($http, $window) {

        var vm = this;
        vm.editItemBtnClick = _editItemBtnClick;
        vm.boardSearch = _boardSearch;
        vm.$onInit = _boardSearch;
        vm.displayHeight = _displayHeight;
        vm.plusPage = _plusPage;
        vm.minusPage = _minusPage;
        vm.dataLoading = true;
        vm.criteria = {
            currentPage: 1,
            itemsPerPage : 40
        };









        function _displayHeight(height) {
            return Math.floor(height / 12) + "'" + (height % 12)
        }


        function _boardSearch() {

            var url = '../api/surfboard/search/?ItemsPerPage=' + vm.criteria.itemsPerPage + '&CurrentPage=' + vm.criteria.currentPage

            // var url = 'http://surfengine.apphb.com/api/surfboard/search/?CurrentPage=1'


            if (vm.criteria.location) {
                url += '&Location=' + vm.criteria.location
            }
            if (vm.criteria.brand) {
                url += '&Brand=' + vm.criteria.brand
            }
            if (vm.criteria.minHeight) {
                url += '&MinHeight=' + vm.criteria.minHeight
            }
            if (vm.criteria.maxHeight) {
                url += '&MaxHeight=' + vm.criteria.maxHeight
            }
            if (vm.criteria.minPrice) {
                url += '&MinPrice=' + vm.criteria.minPrice
            }
            if (vm.criteria.maxPrice) {
                url += '&MaxPrice=' + vm.criteria.maxPrice
            }
            // do the rest of the criteria here - price, brand, name, and so forth

            $http({                     //oninit
                method: 'GET',
                url: url,
                withCredentials: true

            }).then(success, error)

            function success(res) {
                vm.items = res.data
                vm.dataLoading = false;


                console.log(res.data);
            }

            function error(err) {
                console.log(err);
            }
        }





        function _editItemBtnClick(item) {
            if (item.fromInternalUser == true) {
                $(location).attr('href', '/content/create.html' + '?id=' + item.id);
            }
            else {
                window.open(item.link, '_blank') // new tab with third party site. 
            }
        }





        function _plusPage() {
            vm.criteria.currentPage += 1
            console.log(vm.criteria.currentPage)
            _boardSearch();
            $window.scrollTo(0, 0);
        }

        function _minusPage() {
            vm.criteria.currentPage -= 1
            _boardSearch();
        }

    }
})();