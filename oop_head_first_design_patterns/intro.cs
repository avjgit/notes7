using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

abstract class Duck {
    public void swim()  { Console.WriteLine("see, I'm swimming!"); }
    public virtual void look() {Console.WriteLine("some common look");}
}
public interface IFlyable{
    void fly();
}
class FlyWithWings : IFlyable{
    public void fly(){
        Console.WriteLine("flying with the wings!");
    }
}
class FlyNot : Duck, IFlyable{
    public void fly(){
        Console.WriteLine("can not fly");
    }
}
public interface IQuackable{
    void quack();
}
class MallardDuck : Duck, IQuackable {
    public override void look() { Console.WriteLine("looking like Mallard");}
    public void quack()         { Console.WriteLine("quicking"); }
}
class RedDuck : Duck {
    public override void look() { Console.WriteLine("this is Red one");}
}
class RubberDuck : FlyNot {
    public override void look() { Console.WriteLine("plain rubber duck");}
    // public void fly() { Console.WriteLine("not flying"); }
}
class DecoyDuck : Duck {
    // need to heavily override inherited behaviour
    public void fly() { Console.WriteLine("not flying"); }
    public void quack() { Console.WriteLine("not quicking either"); }
    public override void look() { Console.WriteLine("typical decoy"); }
}

abstract class Animal{
    public abstract void makeSound();
}
class Dog : Animal{
    public void bark() {Console.WriteLine("bark");}
    public override void makeSound() { bark(); }
}

class Program {
    static void Main(string[] args) {
        MallardDuck md = new MallardDuck();
        md.look();
        md.quack();

        RedDuck rd = new RedDuck();
        rd.look();
        rd.swim();

        RubberDuck bd = new RubberDuck();
        bd.fly(); // rubber duck inherited flying, which shouldn't supposed to happen

        // "programming to implementation"
        Dog d = new Dog();
        d.bark();
        // "programming to interface"
        Animal a = new Dog();
        a.makeSound();
        // "programming to interface" even better
        // Animal aa = getAnimal();
        // aa.makeSound();

    }
}
