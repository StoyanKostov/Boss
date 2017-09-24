export default function userController($scope) {
    $scope.userAdd = (user) => {
        alert( JSON.stringify(user) )
    }
}