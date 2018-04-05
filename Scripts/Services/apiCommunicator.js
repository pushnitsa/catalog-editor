var catalogApp = angular.module('catalogApp');

catalogApp.factory('apiCommunicator', ['$http', function ($http) {
    return {
        
        getCategories: function (categories) {
            $http
                .get('/api/category')
                .then(function success(response) {
                    response.data.forEach(function (value){
                        categories.push(value); 
                    });
                });
        },
        
        getProducts: function (categoryId, products) {
            $http
                .get('/api/category/' + categoryId + '/products')
                .then(function success(response) {
                    response.data.forEach(function (value) {
                        products.push(value);
                    })
                });
        }
    }
}]);