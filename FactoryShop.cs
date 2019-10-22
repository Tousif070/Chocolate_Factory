using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Chocolate_Factory
{
    class FactoryShop
    {
        private String path = @"D:\C#\Chocolate_Factory\Chocolate_Factory\Res\Data.txt";
        private String[] data;
        private String[] dataLine;
        private Item[] items = new Item[100];
        private double totalCost = 0;

        private void exitApplication()
        {
            Console.WriteLine("Data File Does Not Exist");
            System.Environment.Exit(0);
        }

        private void storeData()
        {
            int size = data.Length;
            
            for(int i=0;i<size;i++)
            {
                dataLine = data[i].Split(',');
                items[i] = new Item();
                items[i].setName(dataLine[0]);
                items[i].setShortCode(dataLine[1]);
                items[i].setPrice(Double.Parse(dataLine[2]));
            }
        }

        private void showMenu()
        {
            int size = data.Length;

            Console.WriteLine("Welcome to my Chocolate Factory !!!\nThe following chocolates are available for purchase:\n");

            for(int i=0;i<size;i++)
            {
                Console.WriteLine(" --> " + items[i].getName() + ", Short Code: " + items[i].getShortCode() + ", Price: Tk." + items[i].getPrice());
            }
            Console.Write("\n");
        }

        private bool checkShortCode(String inputShortCode, out int inputIndex)
        {
            int size = data.Length;
            for(int i=0;i<size;i++)
            {
                if(inputShortCode.Equals(items[i].getShortCode()))
                {
                    inputIndex = i;
                    return true;
                }
            }
            inputIndex = -1;
            return false;
        }

        private void purchase()
        {
            double price = 0;
            int quantity = 0;
            int typeCount = 0;
            int index = 0;

            Console.WriteLine("How many types of chocolates do you want to buy ?");
            typeCount = Int32.Parse(Console.ReadLine());

            for(int i=0;i<typeCount;i++)
            {
                Console.WriteLine("[" + (i+1) + "] Enter Short Code:");
                if(checkShortCode(Console.ReadLine(), out index))
                {
                    price = items[index].getPrice();
                    Console.WriteLine("Enter Quantity:");
                    quantity = Int32.Parse(Console.ReadLine());
                    totalCost += (quantity * price);
                }
                else
                {
                    Console.WriteLine("Invalid Short Code. You have to enter correct Short Code !!!\n");
                    i--;
                }
            }
        }

        public void startOperation()
        {
            if(File.Exists(path))
            {
                data = File.ReadAllLines(path);
                storeData();
                showMenu();
                purchase();
                Console.WriteLine("\nYour total cost is Tk." + totalCost + ". Thank you for your purchase. Have a great day !!!\n");
            }
            else
            {
                exitApplication();
            }
        }
    }
}
