using PV178.Homeworks.HW02.Machine.ControlUnit;
using PV178.Homeworks.HW02.Model;
using System;

namespace PV178.Homeworks.HW02.Machine.States
{
    public class InsertCoinState : State
    {

        public InsertCoinState(IControlUnit controlUnit)
        {
            ControlUnit = controlUnit;
            Credit = 0;
        }

        public InsertCoinState(IControlUnit controlUnit, IState state)
        {

        }

        public override void RaiseCredit(decimal value)
        {
            try
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid inserted value.");
                }
                else
                {
                    Credit += value;
                }
            }
            catch (ArgumentException)
            {
                throw new ArgumentException();
            }

            Console.WriteLine($"Credit: {Credit},- CZK");

            ControlUnit.SwitchToState(new SelectCoordinatesState(ControlUnit.State, ControlUnit));
        }
        public override void SelectProduct(Coordinates coordinates)
        {
            Console.WriteLine("Insert coin first.");
        }

        public override void TryDeliverProduct()
        {
            Console.WriteLine("Insert coin first.");
        }
    }
}
