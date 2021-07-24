using CoffeMachine;
using System.Collections.Generic;

namespace CoffeMachineProject
{
   public static class FactoryCoffee
    {
        static Dictionary<string, CoffeeBase> dictionaryObj = null;
        static FactoryCoffee()
        {
            if (dictionaryObj == null)
            {
                dictionaryObj = new Dictionary<string, CoffeeBase>();
                dictionaryObj.Add("1", new Cappuccino());
                dictionaryObj.Add("2", new Latte());
                dictionaryObj.Add("3", new Coffee());
            }           
        }        
        public static CoffeeBase Create(string choice)
        {
            return choice!=string.Empty && dictionaryObj.ContainsKey(choice) ? dictionaryObj[choice] :null;
        }
    }
}
