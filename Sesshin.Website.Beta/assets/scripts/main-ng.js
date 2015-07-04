var app = angular.module('sesshinApp', []);

app.controller('ContactController', function ($scope, $http) {
    $scope.result = 'hidden';
    $scope.resultMessage= {};
    $scope.formData = {name:'',email:''}; //formData is an object holding the name, email, subject, and message
    $scope.submitButtonDisabled = false;
    $scope.submitted = false; //used so that form errors are shown only after the form has been submitted

    $scope.submit = function (contactform) {
        $scope.submitted = true;
        $scope.submitButtonDisabled = true;

        if (contactform.$valid) {
            
            $http
                .post("/api/contact", {
                     Name: contactform.name.$modelValue,
                     Phone: contactform.phone.$modelValue,
                     Email: contactform.email.$modelValue,
                     Remarks: contactform.remarks.$modelValue,
                      
                })
                .success(function (data) {
                      console.log(data);
                      if (data.IsSuccess) { //success comes from the return json object
                        $scope.submitButtonDisabled = true;
                        $scope.resultMessage = data.Message;
                        $scope.result = 'bg-success';
                    }
                }).error(function(data, status, headers, config) {
                 
                    $scope.submitButtonDisabled = false;
                    $scope.resultMessage = data;
                    $scope.result = 'bg-danger';
               
                debugger;
            });;
        } else {
            $scope.submitButtonDisabled = false;
            $scope.resultMessage = 'שדות חובה חסרים :(';
            $scope.result = 'bg-danger';
        }
    }
});