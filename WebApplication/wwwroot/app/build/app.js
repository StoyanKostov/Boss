/******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, {
/******/ 				configurable: false,
/******/ 				enumerable: true,
/******/ 				get: getter
/******/ 			});
/******/ 		}
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "";
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = 0);
/******/ })
/************************************************************************/
/******/ ([
/* 0 */
/***/ (function(module, exports, __webpack_require__) {

"use strict";


angular.module('bossApp', []).constant('ENDPOINT_URI', 'http://localhost:51941/api/').constant('APP_ROOT_VIEWS', 'app/src/views').service('requestDispacher', ['$http', 'ENDPOINT_URI', function requestDispacher($http, ENDPOINT_URI) {
    var service = this;
    service.create = function (path, item) {
        return $http.post(getUrl(path), item);
    };
    service.read = function (path, id) {
        return $http.get(getUrl(path, id));
    };
    service.update = function (path, id, item) {
        return $http.put(getUrl(path, id), item);
    };
    service.destroy = function (path, id) {
        return $http.delete(getUrl(path, id)).then(success, error).finally(function () {
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
        var url = ENDPOINT_URI + path;
        if (typeof id !== 'undefined') {
            url += '/' + id;
        }
        return url;
    }
}]).controller('assetsController', function assetsController() {
    // Handle browser caching here
    // Bind resoures hashed names
}).controller('userController', ['$scope', function userController($scope) {
    $scope.userAdd = function (user) {
        alert(JSON.stringify(user));
    };
}]).config(['$stateProvider', 'APP_ROOT_VIEWS', function ($stateProvider, APP_ROOT_VIEWS) {
    $stateProvider.state('home', {
        url: '/home',
        templateUrl: APP_ROOT_VIEWS + '/home.html',
        controller: 'homeController'
    }).state('about', {
        url: '/about',
        templateUrl: APP_ROOT_VIEWS + '/about.html',
        controller: 'aboutController'
    }).state('contacts', {
        abstract: true,
        url: '/contacts',
        templateUrl: APP_ROOT_VIEWS + '/contact.html',
        controller: function controller($scope) {
            $scope.contacts = [{ id: 0, name: "Alice" }, { id: 1, name: "Bob" }];
        }
    }).state('contacts.list', {
        url: '/list',
        templateUrl: APP_ROOT_VIEWS + '/contacts.list.html'
    }).state('contacts.details', {
        url: '/:id',
        templateUrl: APP_ROOT_VIEWS + '/contacts.details.html',
        controller: function controller($scope, $stateParams) {
            $scope.person = $scope.contacts[$stateParams.id];
        }
    });
}]);

/***/ })
/******/ ]);