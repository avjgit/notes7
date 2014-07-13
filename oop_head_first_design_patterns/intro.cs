using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

abstract class Duck {
    public void quack() { Console.WriteLine("quack-quack"); }
    public void swim()  { Console.WriteLine("see, I'm swimming!"); }
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

class Program {
    static void Main(string[] args) {
        MallardDuck md = new MallardDuck();
        md.look();
        md.quack();

        RedDuck rd = new RedDuck();
        rd.look();
        rd.swim();
    }
}
