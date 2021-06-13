angular.module('gemsApp', []).
    controller('loginController', function ($scope) {
        $scope.usercred = {};
        $scope.Signin = function () {
            var url = "/Login/Authenticate";
            debugger;
            $.ajax({
                type: "POST",
                url: '/Login/Authenticate',
                data: { usercred: $scope.usercred },
                success: function (data) {
                    if (data) {
                        window.open("http://localhost:5000/Dashboard/Usermanagement", "_self");
                    }
                    else {
                        document.getElementById("lblError").innerHTML='Enter Valid Credentials';
                        $scope.ErrorMsg='Enter Valid Credentials';
                        $('#divError').show();
                    }
                    $scope.$apply();
                }
            });
        }
});