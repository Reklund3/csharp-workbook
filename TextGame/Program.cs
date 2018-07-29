using System;

namespace TextGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            bool alive = true;
            string ch1 = "";
            string ch2 = "";
            string ch3 = "";
            int stick;
            int edmg1;
            int fdmg1;
            int complete = 2;
            
            do {
                string check = "";
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                Console.WriteLine("Welcome to the cavern of secrets!");
                Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

                Console.WriteLine("You enter a dark cavern out of curiosity. It is dark and you can only make out a small stick on the floor.");
                Console.WriteLine("Do you take it? [y/n]: ");
                ch1 = Console.ReadLine();

                // STICK TAKEN
                if (ch1 == "y" || ch1 == "Y" || ch1 == "YES" || ch1 == "Yes" || ch1 == "yes") {

                    Console.WriteLine("You have taken the stick!");
                    stick = 1;
                }
            
                // STICK NOT TAKEN
                else {
                    Console.WriteLine("You did not take the stick");
                    stick = 0;
                }

                Console.WriteLine("As you proceed further into the cave, you see a small glowing object");
                Console.WriteLine("Do you approach the object? [y/n]");
                ch2 = Console.ReadLine();

                // APPROACH SPIDER
                if (ch2 == "y" || ch2 == "Y" || ch2 == "YES" || ch2 == "Yes" || ch2 == "yes") {
                    Console.WriteLine("You approach the object...");
                    Console.WriteLine("As you draw closer, you begin to make out the object as an eye!");
                    Console.WriteLine("The eye belongs to a giant spider!");
                    Console.WriteLine("Do you try to fight it? [Y/N]");
                    ch3 = Console.ReadLine();
                

                    // FIGHT SPIDER
                    if (ch3 == "y" || ch3 == "Y" || ch3 == "YES" || ch3 == "Yes" || ch3 == "yes") {
                        // WITH STICK
                        if (stick == 1) {
                            Console.WriteLine("You only have a stick to fight with!");
                            Console.WriteLine("You quickly jab the spider in it's eye and gain an advantage");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine("                  Fighting...                   ");
                            Console.WriteLine("   YOU MUST HIT ABOVE A 5 TO KILL THE SPIDER    ");
                            Console.WriteLine("IF THE SPIDER HITS HIGHER THAN YOU, YOU WILL DIE");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            fdmg1 = rnd.Next(3, 10);
                            edmg1 = rnd.Next(1, 5);
                            Console.WriteLine("you hit a {0}", fdmg1);
                            Console.WriteLine("the spider hits a {0}", edmg1);

                            if (edmg1 > fdmg1) {
                                Console.WriteLine("The spider has dealt more damage than you!");
                                complete = 0;
                                //return complete;
                            }
                            else if (fdmg1 < 5) {
                                Console.WriteLine("You didn't do enough damage to kill the spider, but you manage to escape");
                                complete = 1;
                                //return complete;
                            }
                            else {
                                Console.WriteLine("You killed the spider!");
                                complete = 1;
                                //return complete;
                            }
                        }

                        // WITHOUT STICK
                        else {
                            Console.WriteLine("You don't have anything to fight with!");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            Console.WriteLine("                  Fighting...                   ");
                            Console.WriteLine("   YOU MUST HIT ABOVE A 5 TO KILL THE SPIDER    ");
                            Console.WriteLine("IF THE SPIDER HITS HIGHER THAN YOU, YOU WILL DIE");
                            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                            edmg1 = rnd.Next(1, 5);
                            fdmg1 = rnd.Next(1, 8);
                            Console.WriteLine("you hit a {0}", fdmg1);
                            Console.WriteLine("the spider hits a {0}", edmg1);

                            if (edmg1 > fdmg1) {
                                Console.WriteLine("The spider has dealt more damage than you!");
                                complete = 0;
                                //return complete;
                            }
                            else if (fdmg1 < 5) {
                                Console.WriteLine("You didn't do enough damage to kill the spider, but you manage to escape");
                                complete = 1;
                                //return complete;
                            }
                            else {
                                Console.WriteLine("You killed the spider!");
                                complete = 1;
                                //return complete;
                            }
                        }
                    }
                    else {
                        //DON'T FIGHT SPIDER
                        Console.WriteLine("You choose not to fight the spider.");
                        Console.WriteLine("As you turn away, it ambushes you and impales you with it's fangs!!!");
                        complete = 0;
                        //return complete;
                    } 
                }
                // DON'T APPROACH SPIDER
                else {
                        Console.WriteLine("You turn away from the glowing object, and attempt to leave the cave...");
                        Console.WriteLine("But something won't let you....");
                        complete = 0;
                        //return complete;
                }
                //CreateWebHostBuilder(args).Build().Run();

                // Check if playeer wants to go again
                if (complete == 1) {
                    Console.WriteLine("You managed to escape the cavern alive! Would you like to play again? [y/n]: ");
                    check = Console.ReadLine();
                    if (check == "y" || check == "Y" || check == "YES" || check == "Yes" || check == "yes") {
                        alive = true;
                    }
                    else {
                        break;
                    }
                }

                else {
                    Console.WriteLine("You have died! Would you like to play again? [y/n]: ");
                    check = Console.ReadLine();
                    if (check == "y" || check == "Y" || check == "YES" || check == "Yes" || check == "yes") {
                        alive = true;
                    }
                    else {
                        break;
                    }
                }
            // game loop
            } while (alive == true);
        }
    }
}
