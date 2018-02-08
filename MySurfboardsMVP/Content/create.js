// main module
(function () {
    angular.module('MainApp', ['uiCropper']);
})();



// blog service
(function () {
    "use strict";
    angular.module('MainApp')
        .factory('postService', postService);



    postService.$inject = ['$http', '$q'];



    function postService($http, $q) {

        var vm = this;


        return {
            post: _post,
            getById: _getById,
            put: _put,
            delete: _delete
        };

        // post
        function _post(item) {
            var settings = {
                method: "POST"
                , url: "/api/surfboard" 
                , headers: {
                    'Content-Type': "application/json"
                }
                , dataType: "JSON"
                , data: item
                , withCredentials: true
            };

            return $http(settings)
                .then(_postRegistrationSuccess, _postRegistrationError)


            function _postRegistrationSuccess(res) {
                return res.data
            }

            function _postRegistrationError(res) {
                console.log(error);
                return res.error
            }
        }



        function _getById(id) {
            var settings = {
                method: "GET"
                , url: "/api/surfboard/" + id
                , headers: {
                    'Content-Type': "application/json"
                }
                , dataType: "JSON"
                , withCredentials: true
            };

            return $http(settings)
                .then(_getByIdSuccess, _getByIdError)


            function _getByIdSuccess(res) {
                return res.data
            }

            function _getByIdError(res) {
                console.log(error);
                return res.error
            }
        }



        // put
        function _put(item) {
            var settings = {
                method: "PUT"
                , url: "/api/surfboard"
                , headers: {
                    'Content-Type': "application/json"
                }
                , dataType: "JSON"
                , data: item
                , withCredentials: true
            };

            return $http(settings)
                .then(_putRegistrationSuccess, _putRegistrationError)


            function _putRegistrationSuccess(res) {
                console.log(res)
                return res.data
            }

            function _putRegistrationError(res) {
                console.log(error);
                return res.error
            }
        }

        function _delete(id) {
            var settings = {
                method: "DELETE"
                , url: "/api/surfboard/" + id
                , withCredentials: true
            };

            return $http(settings)
                .then(_deleteSuccess, _deleteError)


            function _deleteSuccess(res) {
                console.log(res);
                alert('item deleted')
                $(location).attr('href', '/content/index.html');
                return res.data
            }

            function _deleteError(res) {
                console.log(error);
                return res.error
            }
        }

    }

})();



angular.module('MainApp')
    .controller('PostController', PostController);


PostController.$inject = ['postService', '$scope'];

function PostController(postService, $scope) {

    var vm = this;

    vm.save = _save;
    vm.edit = _edit;
    vm.delete = _delete;
    vm.showEdit = false;
    vm.showValidationError = _showValidationError;
    vm.handleFileSelect = _handleFileSelect;
    vm.submitClicked = false; // when mouse hovers over submit, this is set to true.
    vm.savePhoto = _savePhoto;
    vm.savedId = "";
    vm.$onInit = _getUrlParams;
    vm.item = {
    }




    function _savePhoto(imageNum) {
        console.log('save')


        switch (imageNum) {
            case 1:
                vm.item.image1 = vm.item.croppedImage1;
                break;
            case 2:
                vm.item.image2 = vm.item.croppedImage2;
                break;
            case 3:
                vm.item.image3 = vm.item.croppedImage3;
                break;
            case 4:
                vm.item.image4 = vm.item.croppedImage4;
                break;
        }
    }



    function _handleFileSelect(imageNum, evt) {

        console.log(imageNum)

        var file = evt.currentTarget.files[0];
        var reader = new FileReader();
        reader.onload = function (evt) {
            $scope.$apply(function ($scope) {
                switch (imageNum) {
                    case 1:
                        vm.startImage1 = evt.target.result;
                        break;
                    case 2:
                        vm.startImage2 = evt.target.result;
                        break;
                    case 3:
                        vm.startImage3 = evt.target.result;
                        break;
                    case 4:
                        vm.startImage4 = evt.target.result;
                        break;
                }



            });
        };
        reader.readAsDataURL(file);
    };

    angular.element(document.querySelector('#fileInput')).on('change', _handleFileSelect.bind(null, 1));
    angular.element(document.querySelector('#fileInput2')).on('change', _handleFileSelect.bind(null, 2));
    angular.element(document.querySelector('#fileInput3')).on('change', _handleFileSelect.bind(null, 3));
    angular.element(document.querySelector('#fileInput4')).on('change', _handleFileSelect.bind(null, 4));










    function _getUrlParams() {
        //  var paramValue = $location.search().Id;
        var urlParams = new URLSearchParams(window.location.search);
        vm.item.id = urlParams.get('id');
        if (vm.item.id) { // double check that the urlParams are present, then grab them
            vm.showEdit = true; // set to edit rather than save
            postService.getById(vm.item.id).then(_getByIdSuccess, _getByIdError);
        }
    }

    function _getByIdSuccess(res) {
        vm.item = res;


        if (vm.item.image1) {
            vm.startImage1 = vm.item.image1
        }
        if (vm.item.image2) {
            vm.startImage2 = vm.item.image2
        }
        if (vm.item.image3) {
            vm.startImage3 = vm.item.image3
        }
        if (vm.item.image4) {
            vm.startImage4 = vm.item.image4
        }

        if (vm.item.location) {
            vm.item.city = vm.item.location
        }

        if (vm.item.height) {
            vm.item.height1 = (Math.floor(vm.item.height / 12)).toString()
            vm.item.height2 = (vm.item.height % 12).toString()
        }

        if (vm.item.width) {
            vm.item.width1 = (Math.floor(vm.item.width)).toString()
            vm.item.width2 = (vm.item.width - vm.item.width1).toString()
        }
        

    }




    function _getByIdError(err) {
        console.log(err);
    }


    function _save(form) {
        vm.submitClicked = true;
        alert('save clicked')

        if (form.$valid) {
            alert(vm.item)
            vm.showEdit = true; // form saved - toggle to edit
            vm.item.height = parseInt(vm.item.height1 * 12) + parseInt(vm.item.height2)
            vm.item.width = parseInt(vm.item.width1) + parseFloat(vm.item.width2)

            alert(vm.item.width)

            postService.post(vm.item).then(_postSuccess, _postError);
        }
    }

    function _postSuccess(res) {
        console.log(res);
        $(location).attr('href', '/content/index.html');
    }

    function _postError(err) {
        console.log(err);
    }
    function _edit(form) {
        vm.submitClicked = true;
        if (form.$valid) {
            vm.item.height = parseInt(vm.item.height1 * 12) + parseInt(vm.item.height2)
            vm.item.width = parseInt(vm.item.width1) + parseFloat(vm.item.width2)

            postService.put(vm.item).then(_editSuccess, _editError);
        }

    }

    function _editSuccess(res) {
        console.log(res);
    }

    function _editError(err) {
        console.log(err);
    }




    function _delete(form) {
        postService.delete(vm.item.id).then(_deleteSuccess, _deleteError);
    }


    function _deleteSuccess(res) {
         console.log(res);
       // vm.alertService.success("successfully posted");
    }

    function _deleteError(error) {
        console.log(error);
     //   vm.alertService.error("error" + error)
    }


    function _showValidationError(inputProperty) {
        var result = (/*(vm.registrationForm[inputProperty].$invalid && !vm.registrationForm[inputProperty].$pristine) || */(vm.registrationForm[inputProperty].$invalid && vm.submitClicked))

        return result;
    }
}


angular.module('MainApp').directive('equals', function () {
    return {
        restrict: 'A', // only activate on element attribute
        require: '?ngModel', // get a hold of NgModelController
        link: function (scope, elem, attrs, ngModel) {
            if (!ngModel) return; // do nothing if no ng-model

            // watch own value and re-validate on change
            scope.$watch(attrs.ngModel, function () {
                validate();
            });

            // observe the other value and re-validate on change
            attrs.$observe('equals', function (val) {
                validate();
            });

            var validate = function () {
                // values
                var val1 = ngModel.$viewValue;
                var val2 = attrs.equals;

                // set validity
                ngModel.$setValidity('equals', !val1 || !val2 || val1 === val2);
            };
        }
    }
});