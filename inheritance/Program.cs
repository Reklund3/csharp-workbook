using System;

namespace inheritance
{
    public class Animal
    {
        protected int numAppendages;
        public Animal(int numAppendages)
        {
            this.numAppendages = numAppendages;
        }
        public virtual void makesNoise()
        {
            Console.WriteLine("Heavy Breathing");
        }
        public int getAppendages()
        {
            return this.numAppendages;
        }
    }

    public class Vertibrate : Animal
    {
        public Vertibrate(int numAppendages) : base(numAppendages)
        {

        }
    }

    public class Warmblooded : Vertibrate
    {
        public Warmblooded(int numAppendages) : base (numAppendages)
        {

        }
    }

    public class Mammal : Warmblooded
    {
        bool liveOnLine;
        public Mammal(int numAppendages) : base (numAppendages)
        {

        }
        
        public override void makesNoise()
        {
            Console.WriteLine("Stoic Silence!");
        }
    }

    public class Bird : Warmblooded
    {
        bool canFly;
        public Bird(int numAppendages, bool canFly) : base (numAppendages)
        {
            this.canFly = canFly;
        }
        public new void makesNoise()
        {
            Console.WriteLine("KAWW KAWW");
        }
    }


    public class Coldblooded : Vertibrate
    {
        public Coldblooded(int numAppendages) : base (numAppendages)
        {

        }
    }

    public class Fish : Coldblooded
    {
        public Fish(int numAppendages) : base (numAppendages)
        {

        }
    }

    public class Reptiles : Coldblooded
    {
        public Reptiles(int numAppendages) : base (numAppendages)
        {

        }
    }

    public class Amphibians : Coldblooded
    {
        public Amphibians(int numAppendages) : base (numAppendages)
        {

        }
    }

    public class Invertibrate : Animal
    {
        public Invertibrate(int numAppendages) : base (numAppendages)
        {

        }
    }

    public class WithLegs : Invertibrate
    {
        public WithLegs(int numAppendages) : base (numAppendages)
        {

        }
    }

    public class WithoutLegs : Invertibrate
    {
        public WithoutLegs(int numAppendages) : base (numAppendages)
        {

        }
    }

    public class WithThreePair : WithLegs
    {
        public WithThreePair(int numAppendages) : base (numAppendages)
        {

        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            Invertibrate aLadyBug = new Invertibrate(8);
            Bird aBird = new Bird(4,true);
            Warmblooded aPenguin = new Bird(4,false);
            Animal me = new Mammal(4);

            Console.Write("A ladybug makes the sound, ");
            aLadyBug.makesNoise();
            Console.WriteLine("A ladybug has {0} appendages", aLadyBug.getAppendages());

            Console.Write("A bird makes the sound, ");
            aBird.makesNoise();
            Console.WriteLine("A bird has {0} appendages", aBird.getAppendages());

            Console.Write("A penguin makes the sound, ");
            aPenguin.makesNoise();
            Console.WriteLine("A penguin has {0} appendages", aPenguin.getAppendages());
            
            Console.Write("I make the sound, ");
            me.makesNoise();
            Console.WriteLine("I have {0} Appendages, two of which are for weilding a keyboard and mouse!", me.getAppendages());
        }
    }
}