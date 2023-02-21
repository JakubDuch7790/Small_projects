using PV178.Homeworks.HW02.Exceptions;
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
        public override void SelectProduct(Coordinates coordinates)
        {

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

            if (Credit < GetProduct(SelectedCoordinates).Price)
            {
                Console.WriteLine("Not enough credit.");
            }

            try
            {
                Console.WriteLine($"Delivered {GetProduct(SelectedCoordinates)}," +
                    $" returned {Credit - GetProduct(SelectedCoordinates).Price},-CZK.");

                ControlUnit.GetStockFromCoordinates(SelectedCoordinates).DispatchStock();

                ControlUnit.SwitchToState(new InsertCoinState(ControlUnit));
            }
            catch (StockUnavailableException ex)
            {
                Console.WriteLine(ex.Message);

                SelectedCoordinates = Coordinates.Empty;

                ControlUnit.SwitchToState(new SelectCoordinatesState(ControlUnit.State, ControlUnit));
            }
        }
    }
}
