//
// dependency injection
//

// why container?
// to move from:
var svc = new ShippingService(new ProductLocator(),
   new PricingService(), new InventoryService(),
   new TrackingRepository(new ConfigProvider()),
   new Logger(new EmailLogger(new ConfigProvider())));
// to:
var svc = IoC.Resolve<IShippingService>();
// from
public class UglyCustomer : INotifyPropertyChanged
{
    private string _firstName;
    public string FirstName
    {
        get { return _firstName; }
        set
        {
            string oldValue = _firstName;
            _firstName = value;
            if(oldValue != value)
                OnPropertyChanged("FirstName");
        }
    }
    ...
// to
var bindingFriendlyInstance = IoC.Resolve<Customer>(new NotifyPropertyChangedWrapper());
// http://stackoverflow.com/questions/871405/why-do-i-need-an-ioc-container-as-opposed-to-straightforward-di-code


// Dependency injection means giving an object its instance variables.
// http://www.jamesshore.com/Blog/Dependency-Injection-Demystified.html
public class Example {
    private SomeDbClass mydb;

    public Example(){
        mydb = new SomeDeClass();
    }

    public void DoStuff(){
        //...
        mydb.getdata();
        //...
    }
}