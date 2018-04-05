var catalogApp = angular.module('catalogApp');

catalogApp.controller('catalogController', ['$scope', function ($scope) {
    $scope.categories = [
        {
            title: 'Test1',
            id : 1,
            childs: null
        },
        {
            title: 'Test2',
            id : 2,
            childs: [
                {
                    title: 'ChildTest1',
                    id: 4,
                    childs: [
                        {
                            title: 'ChildChildTest1',
                            id: 6,
                            childs: null
                        }
                    ]
                },
                {
                    title: 'ChildTest2',
                    id: 5,
                    childs: null
                }
            ]
        },
        {
            title: 'Test3',
            id : 3,
            childs: null
        }
    ];
    
    $scope.items = [
        {
            Name: 'Test1',
            Price: 0.5,
            Qty: 10
        },
        {
            Name: 'Test2',
            Price: 0.4,
            Qty: 9
        },
        {
            Name: 'Test3',
            Price: 0.3,
            Qty: 8
        }
    ];
    
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
    
    $scope.uploadImage = function (){
        
    };
}]);
