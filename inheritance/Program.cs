using System;

namespace inheritance
{
    public class Animal
    {
        int numAppendages
        public Animal(int numAppendages)
        {
            this.numAppendages = numAppendages;
        }
    }

    public class Vertibrate : Animal
    {
        public Vertibrate() : base(int numAppendages)
        {

        }
    }

    public class Warmblooded : Vertibrate
    {

    }

    public class Mammal : Warmblooded
    {
        bool liveOnLine;
    }

    public class Bird : Warmblooded
    {
        bool canFly;
    }


    public class Coldblooded : Vertibrate
    {

    }

    public class Fish : Coldblooded
    {

    }

    public class Reptiles : Coldblooded
    {

    }

    public class Amphibians : Coldblooded
    {

    }

    public class Invertibrate : Animal
    {

    }

    public class WithLegs : Invertibrate
    {

    }

    public class WithoutLegs : Invertibrate
    {

    }

    public class WithThreePair : WithLegs
    {

    }

    class Program
    {

        static void Main(string[] args)
        {
            Invertibrate aLadyBug = new Invertibrate();
            Vertibrate me = new Vertibrate();
        }
    }
}
