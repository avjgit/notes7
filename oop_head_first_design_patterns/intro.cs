using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Duck {
    public void swim()  { Console.WriteLine("all ducks can swim"); }
    public abstract void look(); //each duck has a look, although different
    public IFlyable flyBehavior; // some duck fly, some - not
    public IQuackable quackBehavior;
    public void performQuack() { quackBehavior.quack(); }
    public void performFly() { flyBehavior.fly(); }
}


public interface IFlyable{
    void fly();
}
class FlyWithWings : IFlyable{
    public void fly(){ Console.WriteLine("flying with the wings!"); }
}
class FlyNot : IFlyable{
    public void fly(){ Console.WriteLine("can not fly"); }
}


public interface IQuackable{
    void quack();
}
class Quack : IQuackable {
    public void quack() { Console.WriteLine("quack"); }
}
class QuackMute : IQuackable {
    public void quack() { Console.WriteLine("no quacking");}
}


class MallardDuck : Duck {
    public MallardDuck(){
        quackBehavior = new Quack();
        flyBehavior = new FlyWithWings();
    }
    public override void look() { Console.WriteLine("looking like Mallard"); }
}
class RedDuck : Duck {
    public override void look() { Console.WriteLine("this is Red one");}
}
class RubberDuck : Duck {
    public RubberDuck() {
        quackBehavior = new Quack();
        flyBehavior = new FlyNot();
    }
    public override void look() { Console.WriteLine("plain rubber duck");}
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
        Duck md = new MallardDuck();
        md.look();
        md.performQuack();

        RedDuck rd = new RedDuck();
        rd.look();
        rd.swim();

        RubberDuck bd = new RubberDuck();
        bd.performFly(); // rubber duck inherited flying, which shouldn't supposed to happen

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
