var gastos = angular.module("GastosApp", []);


//    Our GET request function
gastos.controller("GastosController", function ($scope, $http) {
    $scope.home = "This is the homepage of Gastos";

    $scope.getRequest = function () {
        console.log("Welcome. Probando 1..2..3");
        $http.get('api/Gastos/GetTipo').then(
            function successCallback(response) {
                $scope.response = response;
            },
            function errorCallback(response) {
                console.log("Unable to perform get tipo Gasto");
            }
        );
    };
});


//    Our POST request function
$scope.postRequest = function () {
    $http.post('api/Gastos/PostGastos', data).then(
        function successCallback(response) {
            console.log("Successfully POST. Ingreso datos");
        },
        function errorCallback(response) {
            console.log("POST-ing of data failed. Datos NO Ingresados");
        }
    );
};
