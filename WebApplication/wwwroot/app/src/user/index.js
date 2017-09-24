import userController from './userController';

export default angular.module('user', [])
    .controller('userController', userController)
    .name;