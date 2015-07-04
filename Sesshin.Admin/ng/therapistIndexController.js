app.controller('indexController',
    function ($scope, $location, DataService) {

        $scope.therapists = null;
        $scope.currentPage = 1;
        $scope.pageSize = 10;
        debugger;


        //todo sopping point
        $scope.therapists = DataService.getAllTherapists();
        //DataService.getAllTherapists().then(function (d) {
        //    debugger;
        //    $scope.therapists = d;
        //}, function(error) {
        //    alert('ERROR');
        //});

        $scope.showCreateTherapistForm = function () {
            $location.path('/newTherapistFrom');
        };

        $scope.showUpdateTherapistForm = function (id) {
            $location.path('/updateTherapistFrom/' + id);
        };
    });