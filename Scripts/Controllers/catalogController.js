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

    $scope.$watch( 'abc.currentNode', function( newObj, oldObj ) {
        if( $scope.abc && angular.isObject($scope.abc.currentNode) ) {
            console.log( 'Node Selected!!' );
            console.log( $scope.abc.currentNode );
        }
    }, false);
}]);
