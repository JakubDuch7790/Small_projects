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
        public abstract void TryDeliverProduct();
        public virtual void RaiseCredit(decimal value)
        {
            try
            {
                Credit += value;
            }
            catch (ArgumentException) when (value <= 0)
            {
                Console.WriteLine("We do not serve on debt! ");
            }

            Console.WriteLine($"Credit: {Credit},- CZK");
        }
        public virtual void SelectProduct(Coordinates coordinates)
        {

            if (!CheckCredit())
            {
                throw new InvalidOperationException("Insert coin first.");
            }
            else
            {
                if (AreCoordinatesValid(coordinates) && ControlUnit.GetStocksDictionary()[coordinates] != null)
                {
                    Console.WriteLine($"Row: {coordinates.RowIndex} and column: {coordinates.ColumnIndex} are now selected.");

                    SelectedCoordinates = coordinates;

                    ControlUnit.SwitchToState(new ConfirmOrderState(ControlUnit.State, ControlUnit));
                }
                else if (AreCoordinatesValid(coordinates) && ControlUnit.GetStocksDictionary()[coordinates] == null)
                {
                    Console.WriteLine($"There is no stock available at {coordinates}");
                }
                else
                {
                    throw new ArgumentException(String.Format($"Insert coin first."));
                }
            }
        }

        protected bool CheckCredit()
        {
            return Credit > 0;
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
