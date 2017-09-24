'use strict';
angular.module('bossApp', ['ui.router'])
    .constant('ENDPOINT_URI', 'http://localhost:51941/api/')
    .constant('APP_ROOT_VIEWS', 'app/src/views')
    .service('requestDispacher', ['$http', 'ENDPOINT_URI', function requestDispacher($http, ENDPOINT_URI) {
        let service = this;
        service.create = (path, item) => {
            return $http.post(getUrl(path), item);
        };
        service.read = (path, id) => {
            return $http.get(getUrl(path, id));
        };
        service.update = (path, id, item) => {
            return $http.put(getUrl(path, id), item);
        };
        service.destroy = (path, id) => {
            return $http.delete(getUrl(path, id))
                .then(success, error)
                .finally(() => {
                    // handle loading spiners here
                });
        };

        function success(data) {
            return data;
        }

        function error(err) {
            // handle errors here
            throw err;
        }

        function getUrl(path, id) {
            if (typeof path == 'undefined') {
                throw new Error('invalid path');
            }
            let url = ENDPOINT_URI + path;
            if (typeof id !== 'undefined') {
                url += '/' + id;
            }
            return url;
        }
    }])
    .controller('assetsController', function assetsController() {
        // Handle browser caching here
        // Bind resoures hashed names
    })
    .controller('userController', ['$scope', 'requestDispacher', function userController($scope, requestDispacher) {
        $scope.user = {
            'userName': '',
            'firstName': '',
            'lastName':'',
            'email':'',
            'password': '',
            'confirmPassword': '',
        };
        $scope.error = '';

        $scope.userAdd = (user) => {
            if (user.password !== user.confirmPassword) {
                $scope.error = 'Password inputs mismatch';
            }
            requestDispacher.create('users', user).then(() => {
                $scope.success = 'Greate success';
                $scope.user = {
                    'userName': '',
                    'firstName': '',
                    'lastName': '',
                    'email': '',
                    'password': '',
                    'confirmPassword': '',
                };
            });
        }
    }])
    .config(['$stateProvider', 'APP_ROOT_VIEWS', function ($stateProvider, APP_ROOT_VIEWS) {
        $stateProvider
            .state('/', {
                url: '/',
                templateUrl: `${APP_ROOT_VIEWS}/register.html`,
                controller: 'userController'
            });
    }]);