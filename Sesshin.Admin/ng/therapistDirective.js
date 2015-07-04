/// <reference path="C:\Users\Liran\Documents\Visual Studio 2010\Projects\NewSesshin\SesshinManagement\Sesshin.Admin\Views/Therapists/therapistTemplate.html" />
app.directive('therapistForm', function () {
    return {
        restrict: 'E',
        templateUrl: '/ng/therapistTemplate.html'
    };
});