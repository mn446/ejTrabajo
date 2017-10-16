﻿    // Modulo
    var myApp = angular.module('myApp', []);

    // Controlador
    myApp.controller
    (
        // directiva (identificador del controlador)

        'myCtrl',

        // funcion de asignacion de propiedades (existe un contenedor de datos llamado scope en el cual se van agregando una a una las variables a utilizar)

        function ($scope, $http)
        {
            // Puedo guardar 

            // Variables
            $scope.firstName = "Loco";
            $scope.lastName = "Lopez";
            $scope.fullName = "Nombre completo";
            //$scope.arrayNames["nombre1", "nombre2", "nombre3"];

            //// Funciones con las variables
            //$scope.funcion1 = function () {$scope.firstName = $scope.arrayNames[1]};
            //$scope.funcion2 = function() { $scope.fullName = $scope.firstName + " " + $scope.lastName;}

            $scope.usuarios = "";

            $http.get("/User/Details")
            .success(function (result){
                    $scope.usuarios = result;
                })
            .error(function (result){
                    console.log().result;
                })
            }

    );


    