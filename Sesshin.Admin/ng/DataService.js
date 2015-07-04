app.factory('DataService', function($http) {
    var getAllTherapists = function () {
         
        return [
            {
                id: "111",
                firstName: "joe",
                lastName: "pritchet",
                phone: "021231231",
                threatmentType: "סיני",
                isActive: "0",
                dateHired: "July 11 2015",
            }
        ];
    };


    var getTherapist = function (id) {

        if (id == 123) {

            return { 
                    id: "123",
                    firstName: "joe",
                    lastName: "pritchet",
                    phone: "021231231",
                    threatmentType: "סיני",
                    isActive: "0",
                    dateHired:"July 11 2015"
            };
        }

        return undefined;
    };

    var insertTherapist = function (newTherapist) {
        return true;
    };

    var updateTherapist = function (therapist) {
        return true;
    };

    var getCities = function (val) {
        return $http.get('/api/cities', {
            params: {
                query: val
            }
        }).then(function (response) {
            return response.data.map(function (item) {
                return item.Name;
            });
        });
    };

    return {
        insertTherapist : insertTherapist,
        updateTherapist: updateTherapist,
        getTherapist: getTherapist,
        getCities: getCities,
        getAllTherapists: getAllTherapists
    };
});