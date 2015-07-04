
app.controller('therapistController',
    function ($scope, $window, $routeParams, DataService, $http) {
   
    if ($routeParams.id)
        $scope.therapist = DataService.getTherapist($routeParams.id);
    else
        $scope.therapist = { id: 0 , isActive:0};
 
    $scope.editableTherapist = angular.copy($scope.therapist);

    $scope.threatmentTypes = ["שבדי", "תאילנדי", "סיני"];

    $scope.cities = ["תל אביב", "אזור"];

    $scope.getCities = function(val) {
        return DataService.getCities(val);
    };

            

    $scope.submitForm = function () {
        if ($scope.ediitableTherapist.id == 0) {
            DataService.insertTherapist($scope.editableTherapist);
        } else {
            DataServoce.updateTherapist($scope.editableTherapist);
        }


        $scope.therapist = angular.copy($scope.editableTherapist);
        $window.history.back();
    };

    $scope.cancelForm = function () {
        $window.history.back();
    };
});     

//angularjs controller method
//function customerController($scope, $http) {

//    //declare variable for mainain ajax load and entry or edit mode
//    $scope.loading = true;
//    $scope.addMode = false;

//    //get all customer information
//    $http.get('/api/therapistapi/').success(function (data) {
//        $scope.therapists = data;
//        $scope.loading = false;
//    })
//    .error(function () {
//        $scope.error = "An Error has occured while loading posts!";
//        $scope.loading = false;
//    });

//    //by pressing toggleEdit button ng-click in html, this method will be hit
//    //$scope.toggleEdit = function () {
//    //    this.customer.editMode = !this.customer.editMode;
//    //};

//    ////by pressing toggleAdd button ng-click in html, this method will be hit
//    //$scope.toggleAdd = function () {
//    //    $scope.addMode = !$scope.addMode;
//    //};

//    ////Inser Customer
//    //$scope.add = function () {
//    //    $scope.loading = true;
//    //    $http.post('/api/Customer/', this.newcustomer).success(function (data) {
//    //        alert("Added Successfully!!");
//    //        $scope.addMode = false;
//    //        $scope.customers.push(data);
//    //        $scope.loading = false;
//    //    }).error(function (data) {
//    //        $scope.error = "An Error has occured while Adding Customer! " + data;
//    //        $scope.loading = false;
//    //    });
//    //};

//    ////Edit Customer
//    //$scope.save = function () {
//    //    alert("Edit");
//    //    $scope.loading = true;
//    //    var frien = this.customer;
//    //    alert(frien);
//    //    $http.put('/api/Customer/' + frien.Id, frien).success(function (data) {
//    //        alert("Saved Successfully!!");
//    //        frien.editMode = false;
//    //        $scope.loading = false;
//    //    }).error(function (data) {
//    //        $scope.error = "An Error has occured while Saving customer! " + data;
//    //        $scope.loading = false;
//    //    });
//    //};

//    ////Delete Customer
//    //$scope.deletecustomer = function () {
//    //    $scope.loading = true;
//    //    var Id = this.customer.Id;
//    //    $http.delete('/api/Customer/' + Id).success(function (data) {
//    //        alert("Deleted Successfully!!");
//    //        $.each($scope.customers, function (i) {
//    //            if ($scope.customers[i].Id === Id) {
//    //                $scope.customers.splice(i, 1);
//    //                return false;
//    //            }
//    //        });
//    //        $scope.loading = false;
//    //    }).error(function (data) {
//    //        $scope.error = "An Error has occured while Saving Customer! " + data;
//    //        $scope.loading = false;
//    //    });
//    //};

//}