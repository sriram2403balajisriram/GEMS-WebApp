angular.module('myApp', []).
    controller('userController', function ($scope, $http) {
        $scope.usercred = {};
        $scope.UserID = 0;
        $scope.getUserDetails = function () {
            debugger;
            $('#rowEmpty').show();
            $.ajax({
                type: "GET",
                url: '/Dashboard/getUserDetails',
                success: function (data) {
                    $scope.UserList = data;
                    $('#rowEmpty').hide();
                    $scope.$apply();
                }
            });
        };
        $scope.getUserDetails();
        $scope.ShowPopup = function () {
            $scope.UserID = 0;
            $('#divNewUser').show();
        }
        $scope.Close = function () {
            $('#divNewUser').hide();
        }
        $scope.Delete = function (currnetrecord) {
            debugger;
            $('#rowEmpty').show();
            $.ajax({
                type: "DELETE",
                url: '/Dashboard/deleteUserDetails',
                data: { userdetails: currnetrecord },
                success: function (data) {
                    $scope.UserList = data;
                    $('#rowEmpty').hide();
                    $scope.$apply();
                }
            });
        };
        $scope.ShowEdit = function (currnetrecord) {
            $("#drpCustomers").val(currnetrecord.customer);
            $scope.Username = currnetrecord.username;
            $scope.Firstname = currnetrecord.firstname;
            $scope.Lastname = currnetrecord.lastname;
            $scope.Email = currnetrecord.email;
            $scope.Trialuser = currnetrecord.trialuser;
            $scope.UserID = currnetrecord.id;
            if (currnetrecord.role == 'Global Gleason Admin') {
                $scope.GGAdmin = true;
            }
            else if (currnetrecord.role == 'User') {
                $scope.GGAdmin = true;
            }
            else if (currnetrecord.role == 'Customer Admin') {
                $scope.GUser = true;
            }
            else if (currnetrecord.role == 'Gleason Regional Sales Manager(RSM)') {
                $scope.CAdmin = true;
            }
            else if (currnetrecord.role == 'Gleason Internal Sales') {
                $scope.GRS = true;
            }
            else if (currnetrecord.role == 'Gleason Engineer / Service Engineer') {
                $scope.GIS = true;
            }
            $('#divNewUser').show();
        }
        $scope.Add = function () {
            debugger;
            $('#rowEmpty').show();
            $scope.Userdetails = {};
            $scope.Userdetails.Username = $scope.Username;
            $scope.Userdetails.Firstname = $scope.Firstname;
            $scope.Userdetails.Lastname = $scope.Lastname;
            $scope.Userdetails.Email = $scope.Email;
            $scope.Userdetails.Trialuser = $scope.Trialuser;
            $scope.Userdetails.Cid = $('#drpCustomers').val();
            $scope.Userdetails.ID = $scope.UserID;
            if ($scope.GGAdmin) {
                $scope.Userdetails.Roleid = $('#chkGGAdmin').val();
            }
            else if ($scope.GUser) {
                $scope.Userdetails.Roleid = $('#chkUser').val();
            }
            else if ($scope.CAdmin) {
                $scope.Userdetails.Roleid = $('#chkCAdmin').val();
            }
            else if ($scope.GRS) {
                $scope.Userdetails.Roleid = $('#chkGRS').val();
            }
            else if ($scope.GIS) {
                $scope.Userdetails.Roleid = $('#chkGIS').val();
            }
            else if ($scope.GE) {
                $scope.Userdetails.Roleid = $('#chkGE').val();
            }
            $.ajax({
                type: "POST",
                url: '/Dashboard/saveUserDetails',
                data: { userdetails: $scope.Userdetails },
                success: function (data) {
                    $scope.UserList = data;
                    $('#divNewUser').hide();
                    $('#rowEmpty').hide();
                    $scope.$apply();
                }
            });
        }
});