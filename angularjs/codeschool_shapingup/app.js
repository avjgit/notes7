(function(){

  var app = angular.module('gemStore', []); // in [] goes list of dependencies

  //important to keep upper case and word "controller"
  app.controller('StoreController', function(){

    // 'product' is property of contoller
    this.products = gem;
  });

  var gem = [
    {
      name: 'Dodeblablabla',
      price: 2,
      description: 'best gem',
      canPurchase: true,
      soldOut: false
    },
    {
      name: 'Pentagonal',
      price: 11.99,
      description: 'another best gem',
      canPurchase: true,
      soldOut: false
    }
  ]

})();
