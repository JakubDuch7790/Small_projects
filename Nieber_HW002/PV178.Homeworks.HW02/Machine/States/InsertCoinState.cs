using PV178.Homeworks.HW02.Machine.ControlUnit;
using PV178.Homeworks.HW02.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW02.Machine.States
{
    public class InsertCoinState : State
    {
        private IState ActualState { get; set; }

        public InsertCoinState(IControlUnit controlUnit)
        {
            ActualState = new InsertCoinState(controlUnit);

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
            catch (ArgumentException) when (value < 0)
            {
                Console.WriteLine("We do not serve on debt! ");
            }

            Console.WriteLine($"Credit: {Credit},- CZK");
        }

        public override void SelectProduct(Coordinates coordinates)
        {
            CheckCredit();

            Console.WriteLine("Unable to call this method in this state!");
        }

        public override void TryDeliverProduct()
        {
            CheckCredit();

            Console.WriteLine("Unable to call this method in this state!");
        }
    }
}
