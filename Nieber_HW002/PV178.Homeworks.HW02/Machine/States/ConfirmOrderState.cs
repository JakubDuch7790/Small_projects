using PV178.Homeworks.HW02.Machine.ControlUnit;
using PV178.Homeworks.HW02.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PV178.Homeworks.HW02.Machine.States
{
    public class ConfirmOrderState : State
    {
        public override void RaiseCredit(decimal value)
        {
            throw new NotImplementedException();
        }

        public override void SelectProduct(Coordinates coordinates)
        {
            throw new NotImplementedException();
        }

        public ConfirmOrderState(IState state, IControlUnit controlUnit)
        {
            ControlUnit = controlUnit;

            Credit = state.Credit;

            SelectedCoordinates = state.SelectedCoordinates;
        }

        public override void TryDeliverProduct()
        {
            CheckCredit();

            if (SelectedCoordinates == null)
            {
                Console.WriteLine("No coordinates were given.");
            }

            if (Credit < ControlUnit.GetStockFromCoordinates(SelectedCoordinates).Product.Price)
            {
                Console.WriteLine("Not enough credit.");
            }

        }
    }
}
