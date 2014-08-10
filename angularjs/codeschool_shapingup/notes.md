http://campus.codeschool.com/courses/shaping-up-with-angular-js/level/1/section/1/video/1

LEVEL 1: Get comfortable with expressions by beginning to build a gem store.
===============================================================================================
- easy to test
- response with json data
- directive: a marker in html tag to run js function
- module: pieces of application: var app = angular.module('store', []); // in [] goes list of dependencies
- expression: <p>Answer is {{40 + 2}}</p>

- controllers: where we define app's behaviour

LEVEL 2: Use directives to add a gallery and tabs to the gem store.
===============================================================================================
recap:
    ng-app, ng-controller, ng-show/ng-hide, ng-repeat
new:
    ng-click. example: <a href ng-click="somevar = 1">Click me!</a> {{somevar}}

built-in validation for emails, url, numbers

LEVEL 3: Give the gem store review functionality by using Angular.js forms.
===============================================================================================
ng-model for marking field as source for data binding

ng css: ng-pristine for untouched field, ng-dirty for edited, ng-valid or ng-invalid

app.css:
.ng-invalid.ng-dirty {
  border-color: red;
}

.ng-valid.ng-dirty {
  border-color:green
}

LEVEL 4: Create custom directives for more organized and maintainable Angular.js code.
===============================================================================================
like <dinosaur></dinosaur>

LEVEL 5: Create a new module and learn to use the $http service to get real data into the gem store.
===============================================================================================

$http({ method: 'GET', url: '/products.json' });
$http.get('/products.json', {apiKey: 'myApiKey'});

both return a Promise - with .success() and .error() (check jQuery)

this is dependency injection:
app.Controller('SomeController', ['$http', '$log', function($http, $log){

}]);