using Dependency1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Dependency Injection is a design pattern used to achieve Inversion of Control (IoC) between
//classes and their dependencies.
//Instead of a class creating its own dependencies, they are provided from the outside.


namespace Dependency1
{
    //below example is without DI
    //public class Hammer
    //{
    //   public void use()
    //    {
    //        Console.WriteLine("Hammering nails");
    //    }
    //}
    //public class Saw
    //{
    //    public void use()
    //    {
    //        Console.WriteLine("Sawing wood");
    //    }
    //}
    //public class Builder 
    //{
    //    private Hammer _hammer;
    //    private Saw _saw;
    //    public Builder()
    //    {
    //        _hammer = new Hammer();//Builder responsible for creating its dependencies[ hammer and saw are dependencied]
    //        _saw = new Saw();
    //    }
    //    public void BuildHouse()
    //    {   _hammer.use();
    //        _saw.use();
    //        Console.WriteLine("house built");
    //    }
    //}

    //now Dependency Injection in the above example: Instead of builder going out to buy tools, someone brings the tool to builder
    //This way the builder can focus on building and not worrying about how to bring the tool.

    //below is the example of DI

    public interface IToolUser
    {
        void SetHammer(Hammer hammer);
        void SetSaw(Saw saw);
    }
    public class Hammer
    {
        public void use()
        {
            Console.WriteLine("Hammering nails");
        }
    }
    public class Saw
    {
        public void use()
        {
            Console.WriteLine("Sawing wood");
        }
    }
    //public class Builder
    //{
    //1.Constructor DI
    //private Hammer _hammer;
    //private Saw _saw;

    //public Builder(Hammer hammer, Saw saw)// we are prviding the tool to the builder
    //{
    //    _hammer = hammer;// in this we are injecting the hammer to the builder
    //    _saw = saw;
    //}
    //public void BuildHouse()
    //{
    //    _hammer.use();
    //    _saw.use();
    //    Console.WriteLine("house built");
    //}

    //2.Property DI: for setter DI we dont have to call the constructor, we have default
    //public Hammer Hammer { get; set; } //we have hammer and saw dependencies
    //public Saw Saw { get; set; }
    //public void BuildHouse()
    //{
    //    Hammer.use();
    //    Saw.use();
    //    Console.WriteLine("house built");
    //}

    //}
    //3.Interface DI: interface defines the method to set the dependencies
    public class Builder : IToolUser
    {
        private Hammer _hammer; //builder needs to set the hammer and saw
        private Saw _saw;
        public void BuildHouse()
        {
            _hammer.use();
            _saw.use();
            Console.WriteLine("house built");
        }
        public void SetHammer(Hammer hammer)
        {
            _hammer = hammer;
        }

        public void SetSaw(Saw saw)
        {
            _saw = saw;
        }
    }

 


    internal class Program
    {
        static void Main(string[] args)
        {
            Hammer hammer = new Hammer();//create dependencies outside
            Saw saw = new Saw();

            //Builder builder = new Builder(hammer, saw);//constructor DI
            
            //Builder builder = new Builder();//using setter DI
            //builder.Hammer = hammer;//we are passing the hammer to the builder: basically we are injecting dependency via setter
            //builder.Saw = saw;

            Builder builder = new Builder();//using interface
            builder.SetHammer(hammer);
            builder.SetSaw(saw);


            builder.BuildHouse();

        }
    }
}
