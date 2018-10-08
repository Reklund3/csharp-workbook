using System;

namespace starWars
{
    public class Program
    {
        public static void Main()
        {
            Person leia = new Person("Leia", "Organa", "Rebel");
			Person luke = new Person("Luke", "Skywalker","Rebel Jedi");
            Person darth = new Person("Darth", "Vader", "Imperial");
            Ship falcon = new Ship("Millennium Falcon", "Rebel", "Smuggling", 2);
            Ship tie = new Ship("Tie Fighter", "Tie", "Fighter", 1);
			Station spaceStationOne = new Station("Rebel Space Station","Rebel",5);
			falcon.EnterShip(leia, 0);
			falcon.EnterShip(luke,1);
			tie.EnterShip(darth,0);
			spaceStationOne.dockShip(falcon,0);
			spaceStationOne.dockShip(tie,1);
			Console.WriteLine(spaceStationOne.Ships);
			spaceStationOne.undock(0);
			Console.WriteLine(spaceStationOne.Ships);

        }
    }
}
// Definition of Person Class
class Person
{
	private string firstName;
	private string lastName;
	private string alliance;
	// Person constructor, takes in First and Last name, and alliance 
	// then sets variables for the created object
	public Person(string firstName, string lastName, string alliance)
	{
		this.firstName = firstName;
		this.lastName = lastName;
		this.alliance = alliance;
	}
	// function to return the Persons full name
	public string FullName
	{
		get
		{
			return this.firstName + " " + this.lastName;
		}
		// set name handler to convert a single string name to
		// first and last, for example if "Luke Skywalker" is passed in.
		set
		{
			string[] names = value.Split(' ');
			this.firstName = names[0];
			this.lastName = names[1];
		}
	}
}
class Ship
{
	private Person[] passengers;
	// Ship constructor, takes in ship name, ship alliance, ship type or modus operandi,
	// and ships capacity to seat Persons
	public Ship(string ship, string alliance, string type, int size)
	{
        this.shipName = ship;
		this.Type = type;
		this.Alliance = alliance;
		this.passengers = new Person[size];
		
	}
    public string shipName { get; private set; }
	public string Type { get; private set; }
	public string Alliance { get; private set; }
	// Lists each people currently aboard the ship and displays this on the console
	public string Passengers
	{
		get
		{
			foreach (var person in this.passengers)
			{
				if (person != null)
				{
					Console.WriteLine(String.Format("{0}", person.FullName));
				}
			}

			return "";
		}
	}
	public void EnterShip(Person person, int seat)
	{
		this.passengers[seat] = person;
	}
	public void ExitShip(int seat)
	{
		this.passengers[seat] = null;
	}
}
class Station
{
	private Ship[] ships;
	public Station(string station, string alliance, int size)
	{
        this.stationName = station;
		this.Alliance = alliance;
		this.ships = new Ship[size];
	}
    public string stationName { get; set; }
	public string Alliance { get; set; }
	// displays the ships, and their crew, docked at the station
	public string Ships
	{
		get
		{
			Console.WriteLine("The ships docked on the {0} are:", stationName);
			foreach (var ship in ships)
			{
				if (ship != null)
				{
					Console.WriteLine(String.Format("{0}", ship.shipName));
					Console.WriteLine("Crew:");
					Console.WriteLine(ship.Passengers);
				}
			}

			return "That's all the ships and their crew.";
		}
	}
	public void dockShip(Ship ship, int landingPad)
	{
		this.ships[landingPad] = ship;
	}
	public void undock(int landingPad)
	{
		this.ships[landingPad] = null;
	}
}