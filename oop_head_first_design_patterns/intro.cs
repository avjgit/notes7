using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

abstract class Duck {
    public void quack() { Console.WriteLine("quack-quack"); }
    public void swim()  { Console.WriteLine("see, I'm swimming!"); }
    public void fly()   { Console.WriteLine("flying in the sky!"); }
    public abstract void look();
}

class MallardDuck : Duck {
    public override void look(){
        Console.WriteLine("looking like Mallard");
    }
}

class RedDuck : Duck {
    public override void look(){
        Console.WriteLine("this is Red one");
    }
}

class RubberDuck : Duck {
    public override void look(){
        Console.WriteLine("plain rubber duck");
    }
    public void fly(){
        Console.WriteLine("not flying");
    }
}

class DecoyDuck : Duck {
    // need heavily override inherited behaviour
    public void fly()   { Console.WriteLine("not flying"); }
    public void quack() { Console.WriteLine("not quicking either"); }
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
    }
}
