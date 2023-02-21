using PV178.Homeworks.HW02.Machine.ControlUnit;
using PV178.Homeworks.HW02.Model;
using System;

namespace PV178.Homeworks.HW02.Machine.States
{
    public abstract class State : IState
    {
        public IControlUnit ControlUnit { get; protected set; }

        public decimal Credit { get; protected set; }

        public Coordinates SelectedCoordinates { get; protected set; }

        public virtual void RaiseCredit(decimal value)
        {
            try
            {
                Credit += value;
            }
            catch (ArgumentException) when (value < 0)
            {
                Console.WriteLine("We do not serve on debt! ");
            }

            Console.WriteLine($"Credit: {Credit},- CZK");
        }

        public abstract void SelectProduct(Coordinates coordinates);

        public abstract void TryDeliverProduct();

        protected void CheckCredit()
        {
            if (Credit <= 0)
            {
                Console.WriteLine("Insert coins first!");
            }
        }

        protected bool AreCoordinatesValid(Coordinates coordinates)
        {
            return ControlUnit.GetStocksDictionary().ContainsKey(coordinates);
        }

        protected Product GetProduct(Coordinates coordinates)
        {
            return ControlUnit.GetStockFromCoordinates(coordinates).Product;
        }
    }
}
