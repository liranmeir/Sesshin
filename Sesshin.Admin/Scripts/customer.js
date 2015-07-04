$(document).ready(function () {
   

    $("#Address_City").typeahead({
        minLength: 2,
        source: function (query, process) {
            var cities = [];
            map = {};
             
            return $.get('/api/cities', { query: query }, function (data) {
             
                // Loop through and push to the array
                $.each(data, function (i, country) {
                    map[country.Name] = country;
                    cities.push(country.Name);
                });

                // Process the details
                process(cities);
            });
        },
        updater: function (item) {
         
            var selectedName = map[item].Name;
            var selectedId = map[item].Id;
             
            $("#Address_CityId").val(selectedId);
            return item;
        }
    });


    $("#Address_Street").typeahead({
        minLength: 2,
        source: function (query, process) {
            var streets = [];
            var cityId = $("#Address_CityId").val();
            map = {};

            return $.get('/Streets/GetStreetsByCityIdAndStreetName', { streetName: query, cityId: cityId }, function (data) {

                // Loop through and push to the array
                $.each(data, function (i, street) {
                    map[street.Name] = street;
                    streets.push(street.Name);
                });

                // Process the details
                process(streets);
            });
        },
        updater: function (item) {

            var selectedName = map[item].Name;
            var selectedId = map[item].Id;

            //$("#Address_City_Id").val(selectedId);
            return item;
        }
    });
});