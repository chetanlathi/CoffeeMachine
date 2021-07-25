using System;
using System.Threading;

namespace CoffeMachine
{
    public class CoffeeBase
    {
        public int Beans { get; set; }
        public int Milk { get; set; }
        public int Sugar { get; set; }
        
        public virtual bool CheckBeansAndMilkAvialblility() {
            return false;
        }

        public virtual void PrepareDrink()
        {
            Console.WriteLine(".........Prepareing your drink...........");
            Thread.Sleep(2000);
            Console.WriteLine("!!!!! Your drink is reday !!!!!!!!");
            Console.WriteLine();
            Console.WriteLine("====================================================");
            Console.WriteLine("Total Beans : " + CoffeMachineBase.TotalBeans + " Total Milk : " + CoffeMachineBase.TotalMilk);
            Console.WriteLine("====================================================");
            Console.WriteLine("Please select the Coffee you like to have ...");
            Console.WriteLine("Enter 1 for Cappuccino...");
            Console.WriteLine("Enter 2 for Latte...");
            Console.WriteLine("Enter 3 for Coffee....");
            Console.WriteLine("Enter off to stop");
        }
    }
    public class Cappuccino : CoffeeBase
    {
        public Cappuccino()
        {
            this.Milk = 3;
            this.Beans = 5;
        }
        public override void PrepareDrink()
        {
            Console.WriteLine("Please enter the sugar required...");
            this.Sugar = Convert.ToInt32(Console.ReadLine());
            CoffeMachineBase.TotalBeans = CoffeMachineBase.TotalBeans - this.Beans;
            CoffeMachineBase.TotalMilk = CoffeMachineBase.TotalMilk - this.Milk;
            base.PrepareDrink();
        }

        public override bool CheckBeansAndMilkAvialblility()
        {
            if(CoffeMachineBase.TotalBeans < 5)
            {
                Console.WriteLine("Insufficient Beans");
                return false;
            }
            if (CoffeMachineBase.TotalMilk < 3)
            {
                Console.WriteLine("Insufficient Milk");
                return false;
            }
            return true;
        }
    }
    public class Latte : CoffeeBase
    {
        public Latte()
        {
            this.Milk = 2;
            this.Beans = 3;
        }
        public override void PrepareDrink()
        {
            CoffeMachineBase.TotalBeans = CoffeMachineBase.TotalBeans - this.Beans;
            CoffeMachineBase.TotalMilk = CoffeMachineBase.TotalMilk - this.Milk;
            base.PrepareDrink();
        }

        public override bool CheckBeansAndMilkAvialblility()
        {
            if (CoffeMachineBase.TotalBeans < 3)
            {
                Console.WriteLine("Insufficient Beans");
                return false;
            }
            if (CoffeMachineBase.TotalMilk < 2)
            {
                Console.WriteLine("Insufficient Milk");
                return false;
            }
            return true;
        }
    }
    public class Coffee : CoffeeBase
    {
        public Coffee()
        {
            this.Milk = 1;
            this.Beans = 2;
        }
        public override void PrepareDrink()
        {
            CoffeMachineBase.TotalBeans = CoffeMachineBase.TotalBeans - this.Beans;           
            Console.WriteLine("Do you required Milk ? Please type (Y/N)");
            string _requiredMilk = Console.ReadLine();
            if (_requiredMilk.ToUpper().Equals("Y"))
                CoffeMachineBase.TotalMilk = CoffeMachineBase.TotalMilk - this.Milk;
            base.PrepareDrink();
        }

        public override bool CheckBeansAndMilkAvialblility()
        {
            if (CoffeMachineBase.TotalBeans < 2)
            {
                Console.WriteLine("Insufficient Beans");
                return false;
            }
            if (CoffeMachineBase.TotalMilk < 1)
            {
                Console.WriteLine("Insufficient Milk");
                return false;
            }
            return true;
        }
    }
}
