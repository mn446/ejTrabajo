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
        $scope.usuario = "inicial";
        $scope.modif = 0;
        $scope.otro = "lkjhlkjh";

        // Obtener datos de usuarios en un Json
        $http.get("/User/GetUsers")
        .then(function (response) {
            $scope.usuarios = response.data;
        });

        // Modificar usuario
        $scope.modificar = function(){
            $scope.modif = 1;
            //console.log($scope.usuario.Nombre);

        }

        
        $scope.selectUser = function (id) {
            $http.post("User/GetUserByMail", { mail: id })
                .then(function successCallback(response)
                {
                    $scope.usuario = response.data;
                    console.log($scope.usuario);
                }
            )
        }

        // Funcion para filtrar si tiene una expresion al comienzo
        $scope.startsWith = function (actual, expected) {
            var lowerStr = (actual + "").toLowerCase();
            return lowerStr.indexOf(expected.toLowerCase()) === 0;
        }
    }

);

