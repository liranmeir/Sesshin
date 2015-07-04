var app = angular.module('app', ['ngRoute', 'ui.bootstrap', 'datatables']);
//set and get the angular module

app.config(function ($routeProvider) {
    $routeProvider
        .when("/index",{
            templateUrl: "/ng/therapistIndex.html",
            controller: "indexController"
        })
        .when("/newTherapistFrom", {
            templateUrl: "/ng/therapistFormTemplate.html",
            controller:"therapistController"
        })
        .when("/updateTherapistFrom/:id", {
            templateUrl: "/ng/therapistFormTemplate.html",
            controller: "therapistController"
        })
        .otherwise({ redirectTo: "/index" });
});


