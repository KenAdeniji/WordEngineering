var bibleWordApp = angular.module('bibleWordApp', []);

bibleWordApp.controller('bibleWordCtrl', ['$scope', '$http',
  function ($scope, $http) {
    $http.get('phones/phones.json').success(function(data) {
      $scope.phones = data;
    });
  }]);
