using CoffeMachine;
using System;

namespace CoffeMachineProject
{
    class Program
    {
        static void Main(string[] args)
        {
            string choice = string.Empty;

                CoffeMachineBase machine = new CoffeMachineBase();
                Console.WriteLine("====================================================");
                Console.WriteLine("......Welcome to CL Coffee Shop......");
                Console.WriteLine("How are you feeling today, lets have cup of coffee!!!");
                Console.WriteLine("====================================================");
                Console.WriteLine("Total Beans : " + CoffeMachineBase.TotalBeans + " Total Milk : " + CoffeMachineBase.TotalMilk);
                Console.WriteLine("====================================================");
                Console.WriteLine("Please select the Coffee you like to have ...");
                Console.WriteLine("Enter 1 for Cappuccino...");
                Console.WriteLine("Enter 2 for Latte...");
                Console.WriteLine("Enter 3 for Coffee....");
                Console.WriteLine("Enter off to stop");
                Console.WriteLine();
            do
            {
                choice = Console.ReadLine();
                if (!string.IsNullOrEmpty(choice) && choice.ToUpper() != "OFF")
                {                    
                    machine.TypeOfCofee = FactoryCoffee.Create(choice);
                    if (machine.TypeOfCofee !=null)
                    {
                        if (machine.TypeOfCofee.CheckBeansAndMilkAvialblility())
                        {
                            machine.TypeOfCofee.PrepareDrink();
                            CoffeMachineBase.CheckAvialbilityOfBeans();
                        }                       
                    } 
                    else
                    {
                        Console.WriteLine("Invalid Choice, please enter the valid value");
                    }
                }
            } while (choice.ToUpper() != "OFF");
        }
    }
}
