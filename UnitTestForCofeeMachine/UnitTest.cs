
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeMachineProject;
using System.IO;
using System;
using CoffeMachine;

namespace UnitTestForCofeeMachine
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void When_BeansAreLessThan5_AND_MilkIsLessThan3_Expect_CheckBeansAndMilkAvialblilityAsFalse_ForCappuccino()
        {
            // Arrange
            CoffeMachineBase.TotalBeans = 4;
            CoffeMachineBase.TotalMilk = 2;
            CoffeeBase coffee = FactoryCoffee.Create("1");
            //Act             
            //Assert
            Assert.IsFalse(coffee.CheckBeansAndMilkAvialblility());          
        }
        [TestMethod]
        public void When_BeansAreMoreThan5_AND_MilkIsMoreThan3_Expect_CheckBeansAndMilkAvialblilityAsTrue_ForCappuccino()
        {
            // Arrange
            CoffeMachineBase.TotalBeans = 6;
            CoffeMachineBase.TotalMilk = 4;
            CoffeeBase coffee = FactoryCoffee.Create("1");
            //Act             
            //Assert
            Assert.IsTrue(coffee.CheckBeansAndMilkAvialblility());
        }
        [TestMethod]
        public void When_BeansAreLessThan3_AND_MilkIsLessThan2_Expect_CheckBeansAndMilkAvialblilityAsFalse_ForLatte()
        {
            // Arrange
            CoffeMachineBase.TotalBeans = 2;
            CoffeMachineBase.TotalMilk = 1;
            CoffeeBase coffee = FactoryCoffee.Create("2");
            //Act             
            //Assert
            Assert.IsFalse(coffee.CheckBeansAndMilkAvialblility());
        }
        [TestMethod]
        public void When_BeansAreMoreThan3_AND_MilkIsMoreThan2_Expect_CheckBeansAndMilkAvialblilityAsTrue_ForLatte()
        {
            // Arrange
            CoffeMachineBase.TotalBeans = 4;
            CoffeMachineBase.TotalMilk = 3;
            CoffeeBase coffee = FactoryCoffee.Create("2");
            //Act             
            //Assert
            Assert.IsTrue(coffee.CheckBeansAndMilkAvialblility());
        }
        [TestMethod]
        public void When_BeansAreLessThan2_AND_MilkIsLessThan1_Expect_CheckBeansAndMilkAvialblilityAsFalse_ForCoffee()
        {
            // Arrange
            CoffeMachineBase.TotalBeans = 1;
            CoffeMachineBase.TotalMilk = 0;
            CoffeeBase coffee = FactoryCoffee.Create("3");
            //Act             
            //Assert
            Assert.IsFalse(coffee.CheckBeansAndMilkAvialblility());
        }
        [TestMethod]
        public void When_BeansAreMoreThan2_AND_MilkIsMoreThan1_Expect_CheckBeansAndMilkAvialblilityAsTrue_ForCoffee()
        {
            // Arrange
            CoffeMachineBase.TotalBeans = 3;
            CoffeMachineBase.TotalMilk = 2;
            CoffeeBase coffee = FactoryCoffee.Create("3");
            //Act             
            //Assert
            Assert.IsTrue(coffee.CheckBeansAndMilkAvialblility());
        }
        [TestMethod]        
        public void Check_MilkAndBeansRequired_To_PrepareDrink_Cappuccino()
        {
            // Arrange
            CoffeMachineBase.TotalBeans = 25;
            CoffeMachineBase.TotalMilk = 20;
            CoffeeBase coffee = FactoryCoffee.Create("1");
            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader("5"))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);
                    //Act
                    coffee.PrepareDrink();

                     //Assert - Check the amount of milk & beans consume
                    Assert.AreEqual(25 - coffee.Beans, CoffeMachineBase.TotalBeans);
                    Assert.AreEqual(20 - coffee.Milk, CoffeMachineBase.TotalMilk);
                }
            }
        }
        [TestMethod]
        public void Check_MilkAndBeansRequired_To_PrepareDrink_Latte()
        {
            // Arrange
            CoffeMachineBase.TotalBeans = 25;
            CoffeMachineBase.TotalMilk = 20;
            CoffeeBase coffee = FactoryCoffee.Create("2");
            //Act
            coffee.PrepareDrink();
            //Assert - Check the amount of milk & beans consume
            Assert.AreEqual(25 - coffee.Beans, CoffeMachineBase.TotalBeans);
            Assert.AreEqual(20 - coffee.Milk, CoffeMachineBase.TotalMilk);
        }

        [TestMethod]
        public void Check_MilkAndBeansRequired_To_PrepareDrink_Coffe_WithMilk()
        {
            // Arrange
            CoffeMachineBase.TotalBeans = 25;
            CoffeMachineBase.TotalMilk = 20;
            CoffeeBase coffee = FactoryCoffee.Create("3");
            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader("Y"))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);
                    //Act
                    coffee.PrepareDrink();
                    //Assert - Check the amount of milk & beans consume
                    Assert.AreEqual(25 - coffee.Beans, CoffeMachineBase.TotalBeans);
                    Assert.AreEqual(20 - coffee.Milk, CoffeMachineBase.TotalMilk);
                }
            }
        }

        [TestMethod]
        public void Check_BeansRequired_To_PrepareDrink_Coffe_WithOutMilk()
        {
            // Arrange
            CoffeMachineBase.TotalBeans = 25;
            CoffeMachineBase.TotalMilk = 20;
            CoffeeBase coffee = FactoryCoffee.Create("3");
            using (var sw = new StringWriter())
            {
                using (var sr = new StringReader("N"))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);
                    //Act
                    coffee.PrepareDrink();
                    //Assert - Check the amount of milk & beans consume
                    Assert.AreEqual(25 - coffee.Beans, CoffeMachineBase.TotalBeans);
                    Assert.AreEqual(20, CoffeMachineBase.TotalMilk);                    
                }
            }
        }
    }
}
