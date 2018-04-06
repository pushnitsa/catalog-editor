var catalogApp = angular.module('catalogApp');

catalogApp.controller('catalogController', ['$scope', 'apiCommunicator', function ($scope, apiCommunicator) {
    
    apiCommunicator.getCategories($scope.categories = []);
    
    $scope.currentItem = {
        Image: 'empty.png',
        Name: 'Test1',
        Price: 0.5,
        Qty: 10
    };

    $scope.toggleVisible = function (category, elId) {
        
        category.visible = !category.visible;
        
        var el = $('#'+elId); 
        
        if (category.visible) {
            el.removeClass('glyphicon-plus');
            el.addClass('glyphicon-minus');
        } else {
            el.removeClass('glyphicon-minus');
            el.addClass('glyphicon-plus');
        }
        
    };
    
    $scope.uploadImage = function () {
        
    };
    
    $scope.selectedCategory = null;
    
    $scope.itemsWindowVisible = false;
    $scope.itemsLoaderVisible = false;
    
    $scope.selectCategory = function (category, elId) {
        $scope.itemsWindowVisible = true;
        
        purgeSelectedCategory();
        
        $scope.selectedCategory = category;
        
        var el = $('#'+elId);
        
        el.addClass('selected-category');
        
        $scope.itemsLoaderVisible = true;
        updateProducts();
    };
    
    function purgeSelectedCategory() {
        
        $scope.selectedCategory = null;
        
        $scope.items = null;
        
        var categoryElements = $('.category-name');

        categoryElements.each(function (key, value) {
            $(value).removeClass('selected-category');
        });
    }
    
    function updateProducts() {
        apiCommunicator.getProducts($scope.selectedCategory.Id, $scope.items = [], hideItemsLoader);
        $scope.itemsWindowVisible = true;
    }
    
    function hideItemsLoader() {
        $scope.itemsLoaderVisible = false;
    }
    
    $scope.hideItemsWindow = function () {
        $scope.itemsWindowVisible = false;
    };
    
    $scope.detailWindowVisible = false;
    $scope.detailLoaderVisible = false;
    
    function hideDetailLoader() {
        $scope.detailLoaderVisible = false;
    }
    
}]);
