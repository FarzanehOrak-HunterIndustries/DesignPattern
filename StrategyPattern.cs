using System;
using System.Collections.Generic;
using System.Text;
 
namespace InterviewPractices
{
    public abstract class Car
    {
        IFuel fuel;
        IStyle style;
        public Car(IFuel f, IStyle s)
        {
            this.fuel = f;
            this.style = s;
        }
        public void CarFuel()
        {
            this.fuel.FuelType();
        }
        public void AvailableCarStyle()
        {
            this.style.CarStyle();
        }
        public abstract void Display();
   
    }
 
    public interface IFuel
    {
         void FuelType();
    }
 
    public interface IStyle
    {
        void CarStyle();
    }
 
    public class Electric : IFuel
    {
        public void FuelType()
        {
            Console.WriteLine("Using Electric as a fuel. Plug it and get fuel it up..... ");
        }
    }
 
    public class Gas : IFuel
    {
        public void FuelType()
        {
            Console.WriteLine("Using gas as a fuel. Take the gas pump and fuwl it up....");
        }
    }
 
    public class Convertable : IStyle
    {
        public void CarStyle()
        {
            Console.WriteLine("This car has convertable style.");
        }
    }
 
    public class NoConvertable : IStyle
    {
        public void CarStyle()
        {
            Console.WriteLine("This car does not have a convertable style.");
        }
    }
 
    class Tesla : Car
    {
        public Tesla(IFuel f, IStyle s) : base(f, s)
        {
           
        }
 
        public override void Display()
        {
            Console.WriteLine("This is a Tesla");
        }
    }
 
    class BMW : Car
    {
        public BMW(IFuel f, IStyle s) : base(f, s)
        {
 
        }
 
        public override void Display()
        {
            Console.WriteLine("This is a BMW");
        }
    }
 
 
    class CarSpacifications
    {
        public static void Main(string[] arg)
        {
            Car tesla = new Tesla(new Electric(), new NoConvertable());
            tesla.Display();
            tesla.CarFuel();
            tesla.AvailableCarStyle();
            Console.WriteLine("****************************");
            Car bmw = new BMW(new Gas(), new Convertable());
            bmw.Display();
            bmw.CarFuel();
            bmw.AvailableCarStyle();
            Console.WriteLine("****************************");
            Console.ReadLine();
        }
    }
 
 
}