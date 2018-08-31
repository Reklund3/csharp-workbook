using System;
using System.Collections.Generic;

namespace Rainforest
{
    class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company("Rainforest");
            
            

            do
            {
                Console.WriteLine("welcome to {0} company catalog.", company.companyName);
                Console.WriteLine("1) list total inventory");
                Console.WriteLine("2) Search for a specific item");
                Console.WriteLine("Please select a what you would like to do");
                try
                {
                    company.outputFunc(Console.ReadLine(), ref company);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            } while(true);
        }

        
        

        

        public class Company
        {
            private List<Warehouse> warehouses;
            Dictionary<Item, Container> catalog;
            public string companyName {get; private set;}
            public Company(string companyName)
            {
                this.companyName = companyName;
                this.warehouses = new List<Warehouse>();
                Warehouse warehouseOne = new Warehouse("Austin", 5);
                Warehouse warehouseTwo = new Warehouse("New York", 2);
                Warehouse warehouseThree = new Warehouse("Montreal", 7);
                Container containerOne = new Container("Austin-01", 5);
                Container containerTwo = new Container("Austin-02", 5);
                Container containerThree = new Container("NewYork-01", 5);
                Container containerFour = new Container("Dallas-01", 5);
                Container containerFive = new Container("Dallas-02", 5);
                catalog = new Dictionary<Item, Container>();
                Item banana = new Item("Banana", 0.49);
                Item popTarts = new Item("Pop Tarts", 3.99);
                Item pizza = new Item("Frozen Pizza", 4.99);
                Item orangeJuice = new Item("Orange Juice", 2.49);
                Item bread = new Item("Bread", 0.79);
                Item drPepper = new Item("Dr Peper 12 Pack", 4.49);
                Item redbull = new Item("RedBull", 7.99);
                Item strawberries = new Item("Strawberries", 0.89);
                

                warehouses.Add(warehouseOne);
                warehouses.Add(warehouseTwo);
                warehouses.Add(warehouseThree);
                warehouseOne.addContainter(containerOne);
                warehouseOne.addContainter(containerTwo);
                warehouseTwo.addContainter(containerThree);
                warehouseThree.addContainter(containerFour);
                warehouseThree.addContainter(containerFive);

                catalog.Add(banana, containerOne);
                catalog.Add(popTarts, containerTwo);
                catalog.Add(pizza, containerTwo);
                catalog.Add(orangeJuice, containerThree);
                catalog.Add(bread, containerFour);
                catalog.Add(drPepper, containerFive);
                catalog.Add(redbull, containerFive);
                catalog.Add(strawberries, containerFive);
            }
            public string listWarehouses()
            {
                foreach(Warehouse warehouse in warehouses)
                {
                    Console.WriteLine("{0} warehouse has room for {1} containers.", warehouse.city, warehouse.warehouseSize);
                    warehouse.listContainers();
                }
                return "";
            }
            public void outputFunc(string userEntry, ref Company company)
            {   
                int userMenuSelection = 0;
                if (Int32.TryParse(userEntry, out userMenuSelection))
                {
                    if (userMenuSelection == 1)
                    {
                        Console.Clear();
                        Console.WriteLine(company.listWarehouses());
                    }
                    else if (userMenuSelection == 2)
                    {
                        Console.WriteLine("Please enter an item you would like to find.");
                        itemSearch(Console.ReadLine());
                    }
                    else
                    {
                        throw new Exception("Menu item doesn't exist.");
                    }
                }
                else
                {
                    throw new Exception("Not a valid entry");
                }
            }
            public void itemSearch(string seekItem)
            {
                List<string> locations = new List<string>();
                foreach (Item item in catalog.Keys)
                {
                    if (item.name.ToLower() == seekItem.ToLower())
                    {
                        locations.Add("Item located at in container " + catalog[item].containerID);
                    }
                }
                if (locations.Count == 0)
                {
                    throw new Exception("The item was not found in the store");
                }
                else
                {
                    foreach (string loc in locations)
                    {
                        Console.WriteLine(loc);
                    }
                }
            }
        }
        public class Warehouse
        {
            private List<Container> containers;
            public string city {get; private set;}
            public int warehouseSize {get; private set;}
            public Warehouse(string city, int warehouseSize)
            {
                this.city = city;
                this.warehouseSize = warehouseSize;
                this.containers = new List<Container>();
            }
            public void addContainter(Container container)
            {
                this.containers.Add(container);
            }
            public string listContainers()
            {
                foreach(Container container in containers)
                {
                    Console.WriteLine("{0} container has room for {1} items.", container.containerID, container.containerSize);
                    container.listItems();
                }
                Console.WriteLine("");
                return "";
            }
        }
        public class Container
        {
            private List<Item> items;
            public int containerSize {get; set;}
            public string containerID {get; set;}
            public Container(string containerID, int containerSize)
            {
                this.containerID = containerID;
                this.containerSize = containerSize;
                this.items = new List<Item>();
            }
            public void addItem(Item items)
            {
                this.items.Add(items);
            }
            public string listItems()
            {
                foreach(Item item in items)
                {
                    Console.WriteLine("{0} are $ {1} each.", item.name, item.price);
                }
                Console.WriteLine("");
                return "";
            }
        }
        public class Item
        {
            public string name {get; set;}
            public double price {get; set;}
            public Item(string name, double price)
            {
                this.name = name;
                this.price = price;
            }
        }
    }
}
