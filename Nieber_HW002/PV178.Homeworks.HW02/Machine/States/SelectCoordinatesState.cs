using PV178.Homeworks.HW02.Machine.ControlUnit;
using PV178.Homeworks.HW02.Model;
using System;

namespace PV178.Homeworks.HW02.Machine.States
{
    public class SelectCoordinatesState : State
    {
        public SelectCoordinatesState(IControlUnit controlUnit)
        {
            ControlUnit = controlUnit;
        }

        public SelectCoordinatesState(IState state, IControlUnit controlUnit)
        {
            ControlUnit = controlUnit;

            Credit = state.Credit;

            SelectedCoordinates = state.SelectedCoordinates;
        }

        public override void RaiseCredit(decimal value)
        {
            throw new NotImplementedException();
        }

        public override void SelectProduct(Coordinates coordinates)
        {
            CheckCredit();

            if (Credit > 0)
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
                    throw new ArgumentException(String.Format($"{coordinates} are not valid coordinates."));
                }
            }
        }

        public override void TryDeliverProduct()
        {
            throw new NotImplementedException();
        }
    }
}
