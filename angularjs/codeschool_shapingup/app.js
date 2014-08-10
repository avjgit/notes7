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
      soldOut: false,
      images: [
        {
          full: 'dode-01-full.jpg',
          thumb: 'dode-01-thumb.jpg'
        },
        {
          full: 'dode-02-full.jpg',
          thumb: 'dode-02-thumb.jpg'
        }
      ]
    },
    {
      name: 'Pentagonal',
      price: 11.99,
      description: 'another best gem',
      canPurchase: true,
      soldOut: false
    }
  ]

  app.controller("PanelController", function(){
    this.tab = 1;

    this.selectTab = function(setTab){
      this.tab = setTab;
    };

  });

})();
