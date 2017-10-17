// Modulo
var myApp = angular.module('myApp', []);

// Controlador
myApp.controller
(
    // directiva (identificador del controlador)

    'myCtrl',

    // funcion de asignacion de propiedades (existe un contenedor de datos llamado scope en el cual se van agregando una a una las variables a utilizar)

    function ($scope, $http) {

        $scope.usuarios = "";

        $http.get("/User/PostIndex")
        .then(function (response) {
            $scope.usuarios = response.data;
        });

        // Funcion para filtrar si tiene una expresion al comienzo
        $scope.startsWith = function (actual, expected) {
            var lowerStr = (actual + "").toLowerCase();
            return lowerStr.indexOf(expected.toLowerCase()) === 0;
        }
    }

);

