using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

abstract class Duck {
    public void swim()  { Console.WriteLine("see, I'm swimming!"); }
    public abstract void look();
}
public interface IFlyable{
    void fly();
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
class RubberDuck : Duck {
    public override void look() { Console.WriteLine("plain rubber duck");}
    public new void fly()       { Console.WriteLine("not flying"); }
}
class DecoyDuck : Duck {
    // need to heavily override inherited behaviour
    public new void fly()       { Console.WriteLine("not flying"); }
    public new void quack()     { Console.WriteLine("not quicking either"); }
    public override void look() { Console.WriteLine("typical decoy"); }
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
