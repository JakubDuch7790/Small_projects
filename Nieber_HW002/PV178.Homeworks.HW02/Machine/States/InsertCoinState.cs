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
                Credit += value;
            }
            catch (ArgumentException) when (value <= 0)
            {
                Console.WriteLine("We do not serve on debt! ");
            }

            Console.WriteLine($"Credit: {Credit},- CZK");

            ControlUnit.SwitchToState(new SelectCoordinatesState(ControlUnit.State, ControlUnit));
        }

        public override void SelectProduct(Coordinates coordinates)
        {
            CheckCredit();

            throw new InvalidOperationException(message: "Unable to call this method in this state!");
        }

        public override void TryDeliverProduct()
        {
            CheckCredit();

            throw new InvalidOperationException(message: "Unable to call this method in this state!");
        }
    }
}
