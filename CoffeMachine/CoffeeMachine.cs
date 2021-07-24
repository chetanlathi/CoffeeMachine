using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeMachine
{
    public class CoffeMachineBase
    {
        public static int TotalBeans;
        public static int TotalMilk;

        public CoffeeBase TypeOfCofee;

        static CoffeMachineBase()
        {
            CoffeMachineBase.TotalBeans = 25;
            CoffeMachineBase.TotalMilk = 20;
        }

        public static void CheckAvialbilityOfBeans()
        {
            if (CoffeMachineBase.TotalBeans <= 5)
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Warning : Low bean capacity !!!");
                Console.ForegroundColor = ConsoleColor.White;

            }
        }
    }
}
