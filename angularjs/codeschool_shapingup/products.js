(function() {
  var app = angular.module('store-products', []);

  app.directive("productGallery", function(){
    return {
      restrict: 'E',
      templateUrl: 'product-gallery.html',
      controller: function(){
        this.current = 0;
        this.setCurrent = function(imageNumber){
          this.current = imageNumber || 0;
        };
      },
      controllerAs: 'gallery'
    };
  });

  app.directive('productTabs', function(){
    return{
      restrict: 'E',
      templateUrl: 'product_tabs.html',
      controllerAs: 'tab',
      controller: function(){
        this.tab = 1;

        this.setTab = function(newValue){
          this.tab = newValue;
        };

        this.isSet = function(tabName){
          return this.tab === tabName;
        };
      });
    };
  });

  // dash in HTML translates to camelCase in js
  app.directive('productTitle', function(){
    return {
      restrict: 'E', //alternatively, 'A' for attribute directive
      templateUrl: 'product_with_price.html'
    };
  });

  app.directive('productDescription', function(){
    return {
      restrict: 'E',
      templateUrl: 'product_description.html'
    };
  });

  app.directive('productSpecs', function(){
    return {
      restrict: 'A',
      templateUrl: 'product_specs.html'
    };
  });

})();